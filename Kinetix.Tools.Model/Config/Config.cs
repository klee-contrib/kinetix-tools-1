﻿namespace Kinetix.Tools.Model.Config
{
    public class Config : RootConfig
    {
        public ProceduralSqlConfig? ProceduralSql { get; set; }
        public SsdtConfig? Ssdt { get; set; }
        public JavascriptConfig? Javascript { get; set; }
        public CSharpConfig? Csharp { get; set; }
    }
}
