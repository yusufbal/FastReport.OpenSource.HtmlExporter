using iText.Kernel.Geom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastReport.OpenSource.HtmlExporter.Core
{
    public static class Utils
    {
        public const int PageDivProperty = -10;

        public static PageSize GetPageSizeFromMilimeters(float width, float height)
        {
            width = (float)Math.Round(width);
            height = (float)Math.Round(height);
            if (width == 841 && height == 1189) return PageSize.A0;
            if (width == 594 && height == 841) return PageSize.A1;
            if (width == 420 && height == 594) return PageSize.A2;
            if (width == 297 && height == 420) return PageSize.A3;
            if (width == 210 && height == 297) return PageSize.A4;
            if (width == 148 && height == 210) return PageSize.A5;
            if (width == 105 && height == 148) return PageSize.A6;
            if (width == 74 && height == 105) return PageSize.A7;
            if (width == 52 && height == 74) return PageSize.A8;
            if (width == 37 && height == 52) return PageSize.A9;
            if (width == 26 && height == 37) return PageSize.A10;
            if (width == 1000 && height == 1414) return PageSize.B0;
            if (width == 707 && height == 1000) return PageSize.B1;
            if (width == 500 && height == 707) return PageSize.B2;
            if (width == 353 && height == 500) return PageSize.B3;
            if (width == 250 && height == 353) return PageSize.B4;
            if (width == 176 && height == 250) return PageSize.B5;
            if (width == 125 && height == 176) return PageSize.B6;
            if (width == 88 && height == 125) return PageSize.B7;
            if (width == 62 && height == 88) return PageSize.B8;
            if (width == 44 && height == 62) return PageSize.B9;
            if (width == 31 && height == 44) return PageSize.B10;
            return PageSize.DEFAULT;
        }

    }
}
