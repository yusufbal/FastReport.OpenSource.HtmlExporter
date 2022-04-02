# FastReport.OpenSource.HtmlExporter

FastReport provides open source report generator for .NET6/.NET Core/.NET Framework 4.x. You can use the FastReport in MVC, Web API applications. FastReport Open Source is based on the FastReport.Net project. You can find more information at https://github.com/FastReports/FastReport.Documentation

FastReport Open Source can save documents in HTML, BMP, PNG, JPEG, GIF, TIFF, EMF. 

When you want to export report with PDF format, you must use FastReport.OpenSource.Export.PdfSimple plugin. You can find more information at https://github.com/FastReports/FastReport/tree/master/Extras/OpenSource/FastReport.OpenSource.Export.PdfSimple

PdfSimple plugin exports pdf files as images. For example, if you have 10 pages of an exported report, PdfSimple converts every page as an image then it merges all images in one pdf file. Therefore, with this plugin, the size of your pdf output is too large and you cannot copy the texts from the pdf output. 

# How can we solve this problem?
FastReport's solution for this is to switch to the paid version: https://github.com/FastReports/FastReport/issues/86
You can compare versions from: https://www.fast-report.com/en/fast-report-comparison/

If you want to find a solution for this problem without going to the paid version, you can solve the problem by getting help from the itext7 library.

In this application, we will create the report outputs that we will create with FastReport as html and convert them to pdf with the itext7 library.
