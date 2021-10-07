﻿using Microsoft.Office.Interop.Word;
using System.IO;
using System.Linq;
using VentWPF.ViewModel;
using Word = Microsoft.Office.Interop.Word;


namespace VentWPF.DocX
{
    class DocX_Main
    {
        object missing = System.Reflection.Missing.Value;
        Application winword = new Application();
        public string imageLogo = Path.GetFullPath("Assets/Images/DocXImages/logo.png");
        public string imageQR = Path.GetFullPath("Assets/Images/DocXImages/qr-code.gif");


        #region[testStrArea]
        string HdrText = "Заказ №25564-2";
        string[] testData = { "Падение давления:", "Падение супер крутого давления:", "Падение ещё большего упадка самого давления:" };
        string[] dataName = { "123", "123", "123" };
        #endregion


        public void DocX_Initialization()
        {
            winword.ShowAnimation = false;
            winword.Visible = false;
            Document document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);
            CreateDocument(document, HdrText, testData, dataName);
            document.Save();
            document = null;
            winword.Quit(ref missing, ref missing, ref missing);
            winword = null;
        }


        public void HeaderINIT(Document document)
        {
            foreach (Section section in document.Sections)
            {

                Word.Range headerRange = section.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                Table Table = document.Tables.Add(headerRange, 1, 3, ref missing, ref missing);
                Table.Borders.Enable = 0; //для тестов




                Table.Rows[1].Cells[2].Range.Text = "  170025, Тверская область, г. Тверь \n  ул. Бочкина, д.18, строение 3 офис 3 \n  Тел.: +7(4822)74-42-87 \n  ivv@vega-air.com";
                Table.Rows[1].Cells[2].Range.Font.Bold = 1;
                Table.Rows[1].Cells[2].Range.Font.Size = 10;
                Table.Rows[1].Cells[2].Range.Font.Name = "verdana";
                Table.Rows[1].Cells[1].Range.Frames.Add(headerRange);
                //настройки отображения
                Table.Rows[1].Cells[3].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                Table.Rows[1].Cells[1].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                Table.Rows[1].Cells[2].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;


                object docRange = Table.Rows[1].Cells[1].Range;
                string imagePath = imageLogo;
                document.InlineShapes.AddPicture(imageLogo, LinkToFile: true, SaveWithDocument: true, Range: docRange);
                docRange = Table.Rows[1].Cells[3].Range;
                imagePath = imageQR;
                document.InlineShapes.AddPicture(imageQR, LinkToFile: true, SaveWithDocument: true, Range: docRange);

            }
        }
        public void OrderStatistics(Document document, Paragraph para1, string HText)
        {

            para1.Range.Text = HText;


        }

        public void shemeInit(Document document, Paragraph para1)
        {
            Table Table = document.Tables.Add(para1.Range, 1, 1, ref missing, ref missing);
            Table.Borders.Enable = 0;
            //object docRange = para1.Range;
            object docRange = Table.Rows[1].Cells[1].Range;
            string imagePath = @"C:\Users\stig1\Desktop\testShema.jpg";
            document.InlineShapes.AddPicture(imagePath, LinkToFile: true, SaveWithDocument: true, Range: docRange);
        }

        //создаёт таблицы
        public void CreateTables(Document document)
        {
            foreach (Element i in ProjectVM.Current.Grid.Elements)
            {
                var list = InfoLine.GenerateInfoLines(i, i.DeviceType, i.InfoProperties).ToList();
                int count = list.Count;

                
                if (i.Name != "" && count != 0)
                {
                    Paragraph para0 = document.Content.Paragraphs.Add(ref missing);
                    para0.Range.Text = i.Name;
                    para0.Range.InsertParagraphAfter();
                    TableStructor(document, i);
                }
            }


            //var el = ProjectVM.Current.Grid.Elements[0];
            //TableStructor(document, el);

        }

        //заполняет одну таблицу
        public void TableStructor(Document document, Element el)
        {

            var list = InfoLine.GenerateInfoLines(el, el.DeviceType, el.InfoProperties).ToList();
            int count = list.Count;
            int target;
            if (count % 2 == 1)
            {
                target = (count / 2) + 1;
            }
            else
            {
                target = (count / 2);
            }

            
            Paragraph para1 = document.Content.Paragraphs.Add(ref missing);
            Table firstTable = document.Tables.Add(para1.Range, target, 4, ref missing, ref missing);
            firstTable.Borders[WdBorderType.wdBorderLeft].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
            firstTable.Borders[WdBorderType.wdBorderRight].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
            firstTable.Borders[WdBorderType.wdBorderTop].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
            firstTable.Borders[WdBorderType.wdBorderBottom].LineStyle = Word.WdLineStyle.wdLineStyleSingle;

            int target2 = count - target;
            for (int i = 0; i < target; i++)
            {
                firstTable.Rows[i + 1].Cells[1].Width = 170;
                firstTable.Rows[i + 1].Cells[2].Width = 60;
                firstTable.Rows[i + 1].Cells[3].Width = 170;
                firstTable.Rows[i + 1].Cells[4].Width = 60;
                var korteg = list[i].ToStrings();
                var data = korteg.prop;
                var val = korteg.value;
                firstTable.Rows[i + 1].Cells[1].Range.Text = data;
                firstTable.Rows[i + 1].Cells[2].Range.Text = val;
            }
            for (int i = 0; i < target2; i++)
            {
                firstTable.Rows[i + 1].Cells[3].Width = 170;
                firstTable.Rows[i + 1].Cells[4].Width = 60;
                var korteg = list[i + target].ToStrings();
                var data = korteg.prop;
                var val = korteg.value;
                firstTable.Rows[i + 1].Cells[3].Range.Text = data;
                firstTable.Rows[i + 1].Cells[4].Range.Text = val;
            }



            para1.Range.InsertParagraphAfter();
        }

        public void tableINIT(Document document, Paragraph para1, string[] dataText, string[] dataName)
        {
            int cnt = testData.Length;
            Table firstTable = document.Tables.Add(para1.Range, cnt, 4, ref missing, ref missing);

            int count = 0;
            //firstTable.Borders.Enable = 1;
            firstTable.Borders[WdBorderType.wdBorderHorizontal].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
            firstTable.Borders[WdBorderType.wdBorderLeft].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
            firstTable.Borders[WdBorderType.wdBorderRight].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
            firstTable.Borders[WdBorderType.wdBorderTop].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
            firstTable.Borders[WdBorderType.wdBorderBottom].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
            //firstTable.Rows[1].Cells[2].Range.Font.Bold = 1;
            int stepper = 0;
            firstTable.AllowAutoFit = true;
            firstTable.AutoFitBehavior(WdAutoFitBehavior.wdAutoFitContent);

            for (int i = 1; i < cnt + 1; i++)
            {

                firstTable.Rows[i].Cells[1].Range.Text = dataName[i - 1] + "\n" + dataText[i - 1] + "     123.45kPa" + "\n" + dataText[i - 1] + "     123.45kPa";



                // firstTable.Rows[i].Cells[2].Range.Text = "\n" + "123.45kPa";


                firstTable.Rows[i].Cells[2].Range.Text = "\n" + dataText[i - 1] + "     123.45kPa" + "\n" + dataText[i - 1] + "     123.45kPa";


                // firstTable.Rows[i].Cells[4].Range.Text = "\n" + "123.45kPa";
            }

            /*
                stepper++;
            }
            stepper = 0;
            for (int i = 1; i < cnt; i += 2)
            {
                firstTable.Rows[i].Cells[2].Range.Text = " ";
                firstTable.Rows[i].Cells[1].Range.Font.Bold = 1;                
                firstTable.Rows[i].Cells[1].Range.Text = dataName[stepper];
                firstTable.Rows[i].Cells[1].Height = 20;
                firstTable.Rows[i].Cells[1].Width = 170;
                firstTable.Rows[i].Cells[2].Width = 70;
                firstTable.Rows[i].Cells[3].Width = 170;
                firstTable.Rows[i].Cells[4].Width = 70;
                firstTable.Rows[i].Cells[1].Merge(firstTable.Rows[i].Cells[2]);
                //document.Range(firstTable.Rows[i].Cells[1].Range.Start, firstTable.Rows[i].Cells[4].Range.End).Cells.Merge();

                stepper++;
            }
            */
        }

        public void footerInit(Document document)
        {
            foreach (Section section in document.Sections)
            {
                Word.Range footerRange = section.Footers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                footerRange.Text = "Компания вправе изменить конечную конфигурацию установки без предупреждения заказчика.\nООО \"Вега\" ";
            }
        }

        public void CreateDocument(Document document, string HdrText, string[] DATA, string[] NUM)
        {
            //Шапка
            HeaderINIT(document);
            //данные о заказе
            Paragraph para0 = document.Content.Paragraphs.Add(ref missing);
            OrderStatistics(document, para0, HdrText);
            para0.Range.InsertParagraphAfter();
            //схема
            Paragraph para1 = document.Content.Paragraphs.Add(ref missing);
            shemeInit(document, para1);
            para1.Range.InsertParagraphAfter();
            //таблица данных
            CreateTables(document);

            //нижняя информация(?)
            footerInit(document);


        }
    }
}
