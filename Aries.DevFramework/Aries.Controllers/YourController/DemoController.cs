using Aries.Core.Config;
using Aries.Core.Extend;
using CYQ.Data;
using CYQ.Data.Table;
using CYQ.Data.Tool;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace Aries.Controllers
{
    public class DemoController : Aries.Core.Controller
    {
        public string Upload() {
            if (context.Request.Files.Count > 0)
            {
                // 创建OSSClient实例。
                //var client = new OssClient(endpoint, accessKeyId, accessKeySecret);
                foreach (string file in context.Request.Files)
                {
                    var uploadingfile= context.Request.Files[file];
                    //Bitmap filebitmap = new Bitmap(uploadingfile.InputStream);
                    new ImageClass(uploadingfile.InputStream).GetReducedImage(100,100, context.Server.MapPath("~/缩略图/") + uploadingfile.FileName);
                    //getThumImage(uploadingfile.InputStream,1,3,"d:/缩略图/"+uploadingfile.FileName);

                    
                    //Bitmap bitmap = new Bitmap(100, 100, PixelFormat.Format32bppArgb);
                    ////从指定的Image对象创建新Graphics对象 
                    //Graphics graphics = Graphics.FromImage(bitmap);
                    ////清除整个绘图面并以透明背景色填充 
                    //graphics.Clear(Color.Transparent);
                    ////在指定位置并且按指定大小绘制原图片对象 
                    //graphics.DrawImage(filebitmap, new Rectangle(0, 0, 100, 100));
                    //bitmap.Save("d:/压缩图片.png");
                    uploadingfile.SaveAs("d:/"+ uploadingfile.FileName);
                    using (MAction action = new MAction("Files"))
                    {
                        action.Set("Files.id", new Guid());
                        action.Set("filename", uploadingfile.FileName);
                        action.Set("sort", Query<string>("sort"));
                        action.Set("filepath", "/Img/"+ uploadingfile.FileName);
                        action.Set("thumbnailpath", "/缩略图/"+ uploadingfile.FileName);
                        action.Insert();
                    }

                    //try
                    //{
                    //    // 上传文件。
                    //    var result = client.PutObject(bucketName, uploadingfile.FileName, uploadingfile.InputStream);
                    //    Console.WriteLine("Put object succeeded, ETag: {0} ", result.ETag);
                    //}
                    //catch (Exception ex)
                    //{
                    //    Console.WriteLine("Put object failed, {0}", ex.Message);
                    //}
                    
                }
                return JsonHelper.OutResult(true, "文件成功上传");
            }
            else
            {
                return JsonHelper.OutResult(true, "文件上传失败");
            }
        }

        public void GetData()
        {
            var page = Query<int>("page");
            var sort = Query<string>("sort");
            MDataTable dt;
            using (MAction action = new MAction("Files"))
            {
                dt=action.Select(page, 20, string.IsNullOrEmpty(sort) ? null : "sort='"+sort+"'");
            }
            jsonResult= dt.ToJson();
        }

        public void GetSort() {
            MDataTable dt;
            using (MAction action = new MAction("sort"))
            {
                dt = action.Select();
            }
            jsonResult = dt.ToJson();
        }

        /**/
        /// <summary>  
        /// 生成缩略图  
        /// </summary>  
        /// <param name="source">原始图片文件</param>  
        /// <param name="quality">质量压缩比</param>  
        /// <param name="multiple">收缩倍数</param>  
        /// <param name="outputFile">输出文件名</param>  
        /// <returns>成功返回true,失败则返回false</returns>  
        public static bool getThumImage(Stream source, long quality, int multiple, String outputFile)
        {
            try
            {
                long imageQuality = quality;
                Bitmap sourceImage = new Bitmap(source);
                ImageCodecInfo myImageCodecInfo = GetEncoderInfo("image/jpeg");
                System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                EncoderParameters myEncoderParameters = new EncoderParameters(1);
                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, imageQuality);
                myEncoderParameters.Param[0] = myEncoderParameter;
                float xWidth = sourceImage.Width;
                float yWidth = sourceImage.Height;
                Bitmap newImage = new Bitmap((int)(xWidth / multiple), (int)(yWidth / multiple));
                Graphics g = Graphics.FromImage(newImage);

                g.DrawImage(sourceImage, 0, 0, xWidth / multiple, yWidth / multiple);
                g.Dispose();
                newImage.Save(outputFile, myImageCodecInfo, myEncoderParameters);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /**/
        /// <summary>  
        /// 获取图片编码信息  
        /// </summary>  
        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }

        protected override MDataRow GetOne()
        {
            switch (ObjName)
            {
                case "V_Test"://处理Demo中文本数据库
                    if (AppConfig.DB.DefaultDataBaseType == DataBaseType.Txt)
                    {
                        return Select(GridConfig.SelectType.Show).Rows[0];
                    }
                    break;
            }
            return base.GetOne();
        }
        protected override MDataTable Select(GridConfig.SelectType st)
        {
            switch (ObjName)
            {
                case "V_Test"://处理Demo中文本数据库
                    MDataTable dt = null;
                    using (MAction action = new MAction("Demo_TestA"))
                    {
                        dt = action.Select();
                    }
                    dt.JoinOnName = "id";
                    MDataTable joinDt = dt.Join("Demo_TestB", "id");
                    return joinDt.Select(PageIndex, PageSize, GetWhere() + GetOrderBy("id"), GridConfig.GetSelectColumns(ObjName, st));
            }
            return base.Select(st);
        }

    }
}
