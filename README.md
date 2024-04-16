# FastReport.OpenSource.HtmlExporter: Generate FastReport PDF Files Without PdfSimple Plugin
## Overview
FastReport provides open source report generator for ..NET8/.NET6/.NET Core/.NET Framework 4.x. You can use the FastReport in MVC, Web API applications. FastReport Open Source is based on the FastReport.Net project. You can find more information at https://github.com/FastReports/FastReport.Documentation

FastReport Open Source can save documents in HTML, BMP, PNG, JPEG, GIF, TIFF, EMF. 

When you want to export report with PDF format, you must use FastReport.OpenSource.Export.PdfSimple plugin. You can find more information at https://github.com/FastReports/FastReport/tree/master/Extras/OpenSource/FastReport.OpenSource.Export.PdfSimple

PdfSimple plugin exports pdf files as images. For example, if you have 10 pages of an exported report, PdfSimple converts every page as an image then it merges all images in one pdf file. Therefore, with this plugin, the size of your pdf output is too large and you cannot copy the texts from the pdf output. 

## How can we solve this problem?
FastReport's solution for this is to switch to the paid version: https://github.com/FastReports/FastReport/issues/86
You can compare versions from: https://www.fast-report.com/en/fast-report-comparison/

If you want to find a solution for this problem without going to the paid version, you can solve the problem by getting help from the itext7 library.

In this application, we will create the report outputs that we will create with FastReport as html and convert them to pdf with the itext7 library.

## Versions
### Initial Version (.NET 5 & FastReport 2022.2.2)
The initial version of the library, developed using .NET 5 and FastReport 2022.2.2, incorporated the GeneratePdfFromHtml method within the FastReportGenerator class. This method utilized FastReport's HTML export tool to convert reports to HTML, which were then transformed into PDFs using the iText7 library. One limitation of this version was that it standardized all pages to a single size regardless of the original report specifications, with default margins set to zero.

### Latest Version (.NET 8.0 & Latest FastReport)
The library has been upgraded to .NET 8.0 and uses the latest FastReport libraries. Improvements include ensuring each page in the PDF retains the size and margins defined in the original report template. This version facilitates the creation of PDFs where each page can vary in dimensions according to the specifications within the report template.

## Features
FastReport.OpenSource.HtmlExporter provides significant improvements over the basic functionalities offered by FastReport's PdfSimple tool, particularly in terms of file size optimization and text accessibility:

* **Enhanced File Size Optimization:** Unlike the free version of FastReport's PdfSimple tool, which only allows creation of large-sized PDF files, FastReport.OpenSource.HtmlExporter efficiently generates much smaller PDF files. This reduction in file size does not compromise the quality or the detail of the reports, making it an ideal solution for extensive data reporting.

* **Text Selectability in PDFs:** One of the major limitations of the PdfSimple tool in its free version is that it converts report pages into images within the PDF, which prevents text from being selectable. Our library overcomes this issue by retaining text as selectable elements within the PDF. This feature greatly enhances usability, allowing for text to be copied directly from the PDF files, which is crucial for report documentation and accessibility.

* **Cost-Effective Solution:** FastReport provides advanced PDF generation features such as smaller file sizes and selectable text only in its paid versions. FastReport.OpenSource.HtmlExporter, on the other hand, offers these advanced features for free. This makes it an invaluable tool for developers and companies looking to optimize their reporting solutions without additional cost.

By using FastReport.OpenSource.HtmlExporter, users gain access to professional-level PDF generation features at no cost, providing a robust alternative to the limited free functionalities of FastReport's PdfSimple tool.

## Getting Started
To start using FastReport.OpenSource.HtmlExporter, clone the repository and include it in your .NET projects or you can add nuget package to your project.

## Nuget
https://www.nuget.org/packages/PdfExporter.FastReport.OpenSource v1.0.0


## Usage
Here's how to use the library with an example:

```cs
// Create an instance of the FastReportGenerator with the path to the report designer and the report file
var fastReportGenerator = new FastReportGenerator<TestReportDataModel>(ReportUtils.DesignerPath, "test.frx");

// Generate the PDF from the provided data model
var report = fastReportGenerator.GeneratePdfFromHtml(data);
```

## License
FastReport.OpenSource.HtmlExporter is licensed under the MIT License. See the LICENSE file for more details.
