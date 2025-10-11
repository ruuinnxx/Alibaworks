﻿using Project2_Builder;
using Project2_Builder.Конкертеные_стрители;

var director = new ReportDirector();

var style1 = new ReportStyle { BackgroundColor = "White", FontColor = "Black", FontSize = 14 };
var style2 = new ReportStyle { BackgroundColor = "LightGray", FontColor = "Blue", FontSize = 16 };

IReportBuilder textBuilder = new TextReportBuilder();
IReportBuilder htmlBuilder = new HtmlReportBuilder();
IReportBuilder pdfBuilder = new PdfReportBuilder();

var textReport = director.ConstructReport(textBuilder, style1);
var htmlReport = director.ConstructReport(htmlBuilder, style2);
var pdfReport = director.ConstructReport(pdfBuilder, style1);

textReport.Export("Text");
htmlReport.Export("HTML");
pdfReport.Export("PDF");