using Microsoft.Office.Interop.Word;
using System;
using System.IO;
using Word = Microsoft.Office.Interop.Word;

namespace VentWPF.DocX
{
    class DocX_Main
    {
        object missing = System.Reflection.Missing.Value;
        Application winword = new Application();

        #region[testStrArea]
        string HdrText = "Заказ №25564-2";
        #endregion
        public void test()
        {
            CreateDocument();
        }

        public void HeaderINIT(Document document)
        {
            foreach (Section section in document.Sections)
            {

                Word.Range headerRange = section.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                Table Table = document.Tables.Add(headerRange, 1, 3, ref missing, ref missing);
                Table.Borders.Enable = 0; //для тестов




                Table.Rows[1].Cells[2].Range.Text = "  170025, Тверская область, г. Тверь \n  ул. Бочкина, д.18, строение 3 офис 3 \n  Тел.: +7 (4822) 74-42-87 \n  ivv@vega-air.com";
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
        public void OrderStatistics(Document document, string HText)
        {
            Paragraph para1 = document.Content.Paragraphs.Add(ref missing);
            //object styleHeading1 = "Heading 1";
            //para1.Range.set_Style(ref styleHeading1);
            para1.Range.Text = HText;
            para1.Range.InsertParagraphAfter();
        }
        public void tableINIT(Document document, Paragraph para1)
        {
            Table firstTable = document.Tables.Add(para1.Range, 5, 5, ref missing, ref missing);

            firstTable.Borders.Enable = 1;
            foreach (Row row in firstTable.Rows)
            {
                foreach (Cell cell in row.Cells)
                {

                    if (cell.RowIndex == 1)
                    {
                        cell.Range.Text = "Column " + cell.ColumnIndex.ToString();
                        cell.Range.Font.Bold = 1;
                        cell.Range.Font.Name = "verdana";
                        cell.Range.Font.Size = 10;
                        cell.Shading.BackgroundPatternColor = WdColor.wdColorGray25;
                        cell.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                        cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;

                    }
                    else
                    {
                        cell.Range.Text = (cell.RowIndex - 2 + cell.ColumnIndex).ToString();
                    }
                }
            }
        }
        public void CreateDocument()
        {
            winword.ShowAnimation = false;
            winword.Visible = false;

            Document document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);

            HeaderINIT(document);
            OrderStatistics(document, HdrText);
            Paragraph para1 = document.Content.Paragraphs.Add(ref missing);
            tableINIT(document, para1);
            /*
            document.Content.SetRange(0, 0);
            document.Content.Text = HText + Environment.NewLine;
            */


            

            //таблица 5х5 

            //Сохранение            
            document.Save();/*
            document.Close(ref missing, ref missing, ref missing);
            document = null;
            winword.Quit(ref missing, ref missing, ref missing);
            winword = null;*/

        }
    }
}
