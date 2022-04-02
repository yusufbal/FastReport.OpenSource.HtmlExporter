using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastReport.OpenSource.HtmlExporter
{
    public static class ReportUtils
    {
        private static string ProjectDirPath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\..\"));


        public static string DesignerPath
        {
            get
            {
                return Path.Combine(ProjectDirPath, "ReportDesigns");
            }
        }

        public static string ExportPath
        {
            get
            {
                return Path.Combine(ProjectDirPath, "ReportExports");
            }
        }
    }
}
