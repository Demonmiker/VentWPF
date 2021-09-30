using Microsoft.Office.Interop.Word;
using Word = Microsoft.Office.Interop.Word;

namespace VentWPF.DocX
{
    class DocX_Main
    {
        object missing = System.Reflection.Missing.Value;
        Application winword = new Application();

        #region[testStrArea]
        string HdrText = "Заказ №25564-2";
        string[] testData = { "Данные блок 1\nПереход новая строка: есть\nВажные данные: 4кПа", "Данные блок 2\nПереход новая строка: есть\nВажные данные: 4кПа", "Данные блок 3\nПереход новая строка: есть\nВажные данные: 4кПа" };
        #endregion

        public void DocX_Initialization()
        {
            winword.ShowAnimation = false;
            winword.Visible = false;
            Document document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);
            CreateDocument(document);
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

                //Table.Rows[1].Cells[1].Width = 200;
                //Table.Rows[1].Cells[2].Width = 180;

                //Table.Rows[1].Cells[3].Width = 100;
                //------                              
                //Add image
                object docRange = Table.Rows[1].Cells[1].Range;
                string imagePath = @"C:\Users\stig1\Desktop\logo.png";
                document.InlineShapes.AddPicture(imagePath, LinkToFile: true, SaveWithDocument: true, Range: docRange);
                docRange = Table.Rows[1].Cells[3].Range;
                imagePath = @"C:\Users\stig1\Desktop\qr-code.gif";
                document.InlineShapes.AddPicture(imagePath, LinkToFile: true, SaveWithDocument: true, Range: docRange);

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

        public void tableINIT(Document document, Paragraph para1, string[] dataText)
        {
            int cnt = dataText.Length;
            Table firstTable = document.Tables.Add(para1.Range, cnt, 1, ref missing, ref missing);
            int count = 0;
            firstTable.Borders.Enable = 1;

            for (int i = 1; i <= cnt; i++)
            {
                firstTable.Rows[i].Cells[1].Range.Text = dataText[i - 1];
            }
        }

        public void footerInit(Document document)
        {
            foreach (Section section in document.Sections)
            {
                Word.Range footerRange = section.Footers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                footerRange.Text = "Компания вправе изменить конечную конфигурацию установки без предупреждения заказчика.\nООО \"Вега\" ";
            }
        }

        public void CreateDocument(Document document)
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
            Paragraph para2 = document.Content.Paragraphs.Add(ref missing);
            tableINIT(document, para1, testData);
            para2.Range.InsertParagraphAfter();
            //нижняя информация(?)
            footerInit(document);

            /*
            document.Content.SetRange(0, 0);
            document.Content.Text = HText + Environment.NewLine;
            */

        }
    }
}
