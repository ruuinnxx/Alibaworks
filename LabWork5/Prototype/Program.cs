﻿using Project3_Prototype;

var originalDoc = new Document("Отчет по проекту", "Основное содержание документа");
originalDoc.AddSection(new Section("Введение", "Описание проекта"));
originalDoc.AddSection(new Section("Заключение", "Выводы по проекту"));
originalDoc.AddImage(new Image("http://example.com/image1.png"));

Console.WriteLine("Оригинальный документ:");
Console.WriteLine(originalDoc);

var manager = new DocumentManager();
var clonedDoc = manager.CreateDocument(originalDoc);

clonedDoc.Title = "Копия отчета по проекту";
clonedDoc.Content = "Измененное содержание документа";
clonedDoc.AddSection(new Section("Дополнение", "Новые данные"));
clonedDoc.AddImage(new Image("http://example.com/image2.png"));

Console.WriteLine("Клонированный и измененный документ:");
Console.WriteLine(clonedDoc);

Console.WriteLine("Оригинал после клонирования и изменений клона:");
Console.WriteLine(originalDoc);