using iText.Html2pdf.Attach;
using iText.Html2pdf.Attach.Impl.Tags;
using iText.Html2pdf.Html;
using iText.Layout;
using iText.StyledXmlParser.Node;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastReport.OpenSource.HtmlExporter.Core.Workers
{
    public class CustomPageTagWorker : DivTagWorker
    {
        public CustomPageTagWorker(IElementNode element, ProcessorContext context) : base(element, context)
        {
        }

        public override void ProcessEnd(IElementNode element, ProcessorContext context)
        {
            base.ProcessEnd(element, context);
            IPropertyContainer elementResult = GetElementResult();
            if (elementResult != null && !String.IsNullOrEmpty(element.GetAttribute(AttributeConstants.CLASS)) && element.GetAttribute(AttributeConstants.CLASS).StartsWith("frpage"))
            {
                elementResult.SetProperty(Utils.PageDivProperty, element.GetAttribute(AttributeConstants.CLASS));
            }
        }
    }
}
