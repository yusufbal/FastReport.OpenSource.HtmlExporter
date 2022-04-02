using iText.Html2pdf;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastReport;
using System.IO;
using iText.Html2pdf.Resolver.Font;
using iText.Layout.Font;
using FastReport.OpenSource.HtmlExporter.Core.Workers;
using iText.Layout;
using FastReport.Export.Html;
using FastReport.Export.PdfSimple;

namespace FastReport.OpenSource.HtmlExporter.Core
{
    public class FastReportGenerator<T> where T : class
    {
        public string DesignPath { get; set; }

        public string DesignFileName { get; set; }

        public FastReportGenerator(string designPath, string DesignFileName)
        {
            this.DesignPath = designPath;
            this.DesignFileName = DesignFileName;
        }

        private Report CreateReportWithData(List<T> model)
        {
            var fileName = System.IO.Path.Combine(DesignPath, DesignFileName);
            var report = new Report();
            report.Load(fileName);
            report.RegisterData(model, typeof(T).Name, 10);
            return report;
        }

        public byte[] GenerateWithPDFSimplePlugin(T model, int duplicateCount = 1)
        {
            var data = new List<T>();
            for (int i = 0; i < duplicateCount; i++)
            {
                data.Add(model);
            }
            return GenerateWithPDFSimplePlugin(data);
        }

        public byte[] GenerateWithPDFSimplePlugin(List<T> model)
        {
            var report = CreateReportWithData(model);
            if (report.Report.Prepare())
            {
                var pdfExport = new PDFSimpleExport();
                var stream = new MemoryStream();
                report.Report.Export(pdfExport, stream);
                report.Dispose();
                pdfExport.Dispose();
                stream.Position = 0;
                return stream.ToArray();
            }
            else
            {
                return new byte[0];
            }
        }

        public string GenerateHtml(List<T> model)
        {
            var report = CreateReportWithData(model);
            if (report.Report.Prepare())
            {
                HTMLExport export = new HTMLExport();
                export.Layers = true;
                using (MemoryStream ms = new MemoryStream())
                {
                    export.EmbedPictures = true;
                    export.Export(report, ms);
                    ms.Flush();
                    return Encoding.UTF8.GetString(ms.ToArray());
                }
            }
            return string.Empty;
        }

        public byte[] GeneratePdfFromHtml(T model, PageSize pageSize)
        {
            var data = new List<T>();
            data.Add(model);
            return GeneratePdfFromHtml(data, pageSize);
        }

        public byte[] GeneratePdfFromHtml(List<T> model, PageSize pageSize)
        {
            var reportHtml = GenerateHtml(model);
            if (string.IsNullOrEmpty(reportHtml))
            {
                return null;
            }
            using (var workStream = new MemoryStream())
            {
                using (var pdfWriter = new PdfWriter(workStream))
                {
                    FontProvider fontProvider = new DefaultFontProvider(true, true, true);
                    var converterProperties = new ConverterProperties();
                    converterProperties.SetTagWorkerFactory(new CustomTagWorkerFactory());
                    converterProperties.SetFontProvider(fontProvider);
                    var pdfDocument = new PdfDocument(pdfWriter);
                    pdfDocument.SetDefaultPageSize(pageSize);
                    var elements = HtmlConverter.ConvertToElements(reportHtml, converterProperties);
                    var document = new Document(pdfDocument, pageSize);
                    document.SetMargins(0, 0, 0, 0);
                    int elementIndex = 0;
                    foreach (IElement element in elements)
                    {
                        if (element.HasProperty(Utils.PageDivProperty) && elementIndex > 0)
                        {
                            document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
                        }
                        document.Add((IBlockElement)element);
                        elementIndex++;
                    }
                    document.Close();
                    return workStream.ToArray();
                }
            }
        }

    }
}
