{"ColumnName":"ExcelID","SqlType":"System.Guid","IsAutoIncrement":false,"IsCanNull":false,"MaxSize":36,"Scale":0,"IsPrimaryKey":true,"DefaultValue":[#GUID],"Description":"主键","TableName":"Config_Excel","IsUniqueKey":false,"IsForeignKey":false,"FKTableName":""},
{"ColumnName":"ExcelName","SqlType":"System.String","IsAutoIncrement":false,"IsCanNull":true,"MaxSize":50,"Scale":0,"IsPrimaryKey":false,"DefaultValue":"","Description":"Excel名称","TableName":"Config_Excel","IsUniqueKey":false,"IsForeignKey":false,"FKTableName":""},
{"ColumnName":"Description","SqlType":"System.String","IsAutoIncrement":false,"IsCanNull":true,"MaxSize":100,"Scale":0,"IsPrimaryKey":false,"DefaultValue":"","Description":"模板描述","TableName":"Config_Excel","IsUniqueKey":false,"IsForeignKey":false,"FKTableName":""},
{"ColumnName":"TableNames","SqlType":"System.String","IsAutoIncrement":false,"IsCanNull":true,"MaxSize":400,"Scale":0,"IsPrimaryKey":false,"DefaultValue":"","Description":"关联表名，逗号分隔","TableName":"Config_Excel","IsUniqueKey":false,"IsForeignKey":false,"FKTableName":""},
{"ColumnName":"StartIndex","SqlType":"System.Int32","IsAutoIncrement":false,"IsCanNull":true,"MaxSize":10,"Scale":0,"IsPrimaryKey":false,"DefaultValue":"(0)","Description":"起始索引","TableName":"Config_Excel","IsUniqueKey":false,"IsForeignKey":false,"FKTableName":""},
{"ColumnName":"HeadCrossRowNum","SqlType":"System.Int32","IsAutoIncrement":false,"IsCanNull":true,"MaxSize":10,"Scale":0,"IsPrimaryKey":false,"DefaultValue":"(1)","Description":"列头跨几行","TableName":"Config_Excel","IsUniqueKey":false,"IsForeignKey":false,"FKTableName":""},
{"ColumnName":"WhereType","SqlType":"System.Byte","IsAutoIncrement":false,"IsCanNull":true,"MaxSize":3,"Scale":0,"IsPrimaryKey":false,"DefaultValue":"(0)","Description":"条件方式（and、or）","TableName":"Config_Excel","IsUniqueKey":false,"IsForeignKey":false,"FKTableName":""},
{"ColumnName":"AcceptType","SqlType":"System.Byte","IsAutoIncrement":false,"IsCanNull":true,"MaxSize":3,"Scale":0,"IsPrimaryKey":false,"DefaultValue":"(0)","Description":"操作类型（0：插入或更新；1；仅插入；2；仅更新）","TableName":"Config_Excel","IsUniqueKey":false,"IsForeignKey":false,"FKTableName":""},
{"ColumnName":"CreateTime","SqlType":"System.DateTime","IsAutoIncrement":false,"IsCanNull":true,"MaxSize":23,"Scale":3,"IsPrimaryKey":false,"DefaultValue":[#GETDATE],"Description":"创建时间","TableName":"Config_Excel","IsUniqueKey":false,"IsForeignKey":false,"FKTableName":""}