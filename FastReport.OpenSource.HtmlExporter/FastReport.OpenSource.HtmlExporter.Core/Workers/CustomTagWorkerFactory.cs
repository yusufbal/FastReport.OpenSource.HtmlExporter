using iText.Html2pdf.Attach;
using iText.Html2pdf.Attach.Impl;
using iText.Html2pdf.Html;
using iText.StyledXmlParser.Node;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastReport.OpenSource.HtmlExporter.Core.Workers
{
    public class CustomTagWorkerFactory : DefaultTagWorkerFactory
    {
        public override ITagWorker GetCustomTagWorker(IElementNode tag, ProcessorContext context)
        {
            if (TagConstants.DIV.Equals(tag.Name().ToLower()))
            {
                return new CustomPageTagWorker(tag, context);
            }
            return base.GetCustomTagWorker(tag, context);
        }
    }
}
