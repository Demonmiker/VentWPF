using Microsoft.Office.Interop.Word;
using System;
using System.IO;
using Word = Microsoft.Office.Interop.Word;

namespace VentWPF.DocX
{
    class DocX_Main
    {
        public void test()
        {
            CreateDocument();
        }
        public void CreateDocument()
        {
             
            Application winword = new Application();             
            winword.ShowAnimation = false;              
            winword.Visible = false;             
            object missing = System.Reflection.Missing.Value;            
            Document document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);
            
            //Колонтитул 
            foreach (Section section in document.Sections)
            {
                /*
                Word.Range headerRange = section.Headers[WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                headerRange.Fields.Add(headerRange, WdFieldType.wdFieldPage);
                headerRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                headerRange.Font.ColorIndex = WdColorIndex.wdBlue;
                headerRange.Font.Size = 10;
                headerRange.Text = "VegaAir";*/
                
                Word.Range headerRange = section.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                document.Frames.Add(headerRange);
                //Place Frame at top of page
                headerRange.Frames[1].RelativeVerticalPosition = Word.WdRelativeVerticalPosition.wdRelativeVerticalPositionPage;
                headerRange.Frames[1].VerticalPosition = 0;
                headerRange.Frames[1].Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleNone;
                //Add image
                object docRange = headerRange.Frames[1].Range;
                string imagePath = @"C:\Users\stig1\Desktop\wood-3.jpg";
                document.InlineShapes.AddPicture(imagePath, ref missing, ref missing, ref docRange);

                headerRange.Frames[2].Range.Text = "VegaAir";
                headerRange.Frames[2].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                headerRange.Frames[2].Range.Font.Size = 10;
            }


            document.Content.SetRange(0, 0);
            document.Content.Text = "This is test document " + Environment.NewLine;

            //Заголовок 
            Paragraph para1 = document.Content.Paragraphs.Add(ref missing);
            object styleHeading1 = "Heading 1";
            para1.Range.set_Style(ref styleHeading1);
            para1.Range.Text = "Para 1 text";
            para1.Range.InsertParagraphAfter();
            

            //таблица 5х5 
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

            //Сохранение            
            document.Save();
            document.Close(ref missing, ref missing, ref missing);
            document = null;
            winword.Quit(ref missing, ref missing, ref missing);
            winword = null;

        }
    }
}
