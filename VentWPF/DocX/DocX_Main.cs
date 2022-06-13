using Microsoft.Office.Interop.Word;
using System;
using System.IO;
using System.Linq;
using System.Windows.Media;
using System.Windows;
using System.Windows.Media.Imaging;
using VentWPF.Model.Calculations;
using vm = VentWPF.ViewModel;

using SYS = System.Windows;
using Word = Microsoft.Office.Interop.Word;

namespace VentWPF.DocX
{
    internal class DocX_Main
    {
        private object missing = System.Reflection.Missing.Value;
        private object varFalse = false;
        private Word.Application winword = new Word.Application();
        public string imageLogo = Path.GetFullPath("Assets/Images/DocXImages/logo.png");
        public string imageQR = Path.GetFullPath("Assets/Images/DocXImages/qr-code.gif");

        public static vm.ProjectVM Project { get; set; } = vm.ProjectVM.Current;

        public float currentSumFrame;
        public float currentSumStand;
        public float currentSumCorner;

        #region[testStrArea]
        private string HdrText = "Заказ №25564-2";
        private string[] testData = { "Падение давления:", "Падение супер крутого давления:", "Падение ещё большего упадка самого давления:" };
        private string[] dataName = { "123", "123", "123" };
        #endregion

        public void SaveImage(string path, SYS.FrameworkElement gui)
        {
            RenderTargetBitmap bmp = new RenderTargetBitmap((int)gui.ActualWidth + 10, (int)gui.ActualHeight + 10, 96, 96, PixelFormats.Pbgra32);
            bmp.Render(gui);
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bmp));
            FileStream fs = new FileStream(path, FileMode.Create);
            encoder.Save(fs);
            fs.Close();
        }

        #region Frame

        public void DocX_Frame()
        {
            winword.ShowAnimation = false;
            winword.Visible = false;
            Document document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);
            document.PageSetup.Orientation = WdOrientation.wdOrientLandscape;
            HeaderFrame(document);
            FrameScheme(document);
            DataTableFrame(document);
            DataTableStandFrame(document);
            DataTableCornerFrame(document);
            FrameTableSum(document);
            try
            {
                document.Save();
            }
            catch (System.Runtime.InteropServices.COMException)
            {
                MessageBox.Show("Сохранение было отменено");
            }
            document.Close(varFalse, ref missing, ref missing);
            document = null;
            winword.Quit(ref varFalse, ref missing, ref missing);
            winword = null;
        }

        public void FrameScheme(Document document)
        {
            string[] path = { Environment.CurrentDirectory + @"\\frame_top.png", Environment.CurrentDirectory + @"\\frame_left.png", Environment.CurrentDirectory + @"\\frame_right.png" };
            string[] name = { "frame_top", "frame_left", "frame_right" };
            for (int i = 0; i < name.Length; i++)
            {
                var valid = Project.Elements.ContainsKey(name[i]);
                if (valid)
                {
                    SaveImage(path[i], Project.Elements[name[i]]);
                    if (name[i] == "frame_top")
                    {
                        Paragraph para1 = document.Content.Paragraphs.Add(ref missing);
                        para1.Range.Text = "Каркас вид сверху";
                        para1.Range.InsertParagraphAfter();
                    }
                    if (name[i] == "frame_left")
                    {
                        Paragraph para1 = document.Content.Paragraphs.Add(ref missing);
                        para1.Range.Text = "Каркас вид слева";
                        para1.Range.InsertParagraphAfter();
                    }
                    if (name[i] == "frame_right")
                    {
                        Paragraph para1 = document.Content.Paragraphs.Add(ref missing);
                        para1.Range.Text = "Каркас вид справа";
                        para1.Range.InsertParagraphAfter();
                    }
                    Paragraph para2 = document.Content.Paragraphs.Add(ref missing);
                    SaveFrame(document, path[i], para2);
                }
                else
                {
                    Paragraph para2 = document.Content.Paragraphs.Add(ref missing);
                    para2.Range.Text = "Нет схемы каркаса " + name[i] + " для текущего проекта";
                }
            }
        }

        public void SaveFrame(Document document, string path, Paragraph para1)
        {
            object docRange = para1.Range;
            document.InlineShapes.AddPicture(path, LinkToFile: true, SaveWithDocument: true, Range: docRange);
        }

        public void DataTableFrame(Document document)
        {
            Paragraph para0 = document.Content.Paragraphs.Add(ref missing);
            para0.Range.Text = "Профиль каркаса";
            para0.Range.InsertParagraphAfter();
            Paragraph para1 = document.Content.Paragraphs.Add(ref missing);

            string[] dataW = Calculations.FrameOutCalcWitdh(Convert.ToInt32(Project.Frame.Width));
            string[] dataL = Calculations.FrameOutCalcLenght(Convert.ToInt32(Project.Frame.Length));
            string[] dataH = Calculations.FrameOutCalcHeight(Convert.ToInt32(Project.Frame.Height));

            Table firstTable = document.Tables.Add(para1.Range, 4, dataW.Length, ref missing, ref missing);

            firstTable.Borders[WdBorderType.wdBorderLeft].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
            firstTable.Borders[WdBorderType.wdBorderRight].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
            firstTable.Borders[WdBorderType.wdBorderTop].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
            firstTable.Borders[WdBorderType.wdBorderBottom].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
            firstTable.Borders[WdBorderType.wdBorderVertical].LineStyle = Word.WdLineStyle.wdLineStyleSingle;

            firstTable.AllowAutoFit = true;
            firstTable.AutoFitBehavior(WdAutoFitBehavior.wdAutoFitContent);

            for (int i = 0; i < dataW.Length; i++)
            {
                firstTable.Rows[1].Cells[i + 1].Range.Text = dataW[i];

                firstTable.Rows[2].Cells[i + 1].Range.Text = dataL[i];

                firstTable.Rows[3].Cells[i + 1].Range.Text = dataH[i];
            }
            firstTable.Rows[4].Cells[1].Range.Text = "Итого:";
            int sum = Convert.ToInt32(dataW[4]) + Convert.ToInt32(dataH[4]) + Convert.ToInt32(dataL[4]);
            firstTable.Rows[4].Cells[5].Range.Text = Convert.ToString(sum);
            para0.Range.InsertParagraphAfter();
            currentSumFrame = (float)Convert.ToDouble(sum);
        }

        public void DataTableStandFrame(Document document)
        {
            Paragraph para0 = document.Content.Paragraphs.Add(ref missing);
            para0.Range.Text = "Перегородки каркаса";
            para0.Range.InsertParagraphAfter();

            Paragraph para1 = document.Content.Paragraphs.Add(ref missing);
            string[] dataT = Calculations.FrameStandCalcTop(Convert.ToInt32(Project.Frame.Width), Project.Frame.Top.Values.Count - 1);
            string[] dataS = Calculations.FrameStandCalcServ(Convert.ToInt32(Project.Frame.Height), Project.Frame.Left.Values.Count - 1);
            string[] dataB = Calculations.FrameStandCalcBack(Convert.ToInt32(Project.Frame.Height), Project.Frame.Right.Values.Count - 1);
            string[] dataU = Calculations.FrameStandCalcUnder(Convert.ToInt32(Project.Frame.Width), 0);
            Table firstTable = document.Tables.Add(para1.Range, 5, dataT.Length, ref missing, ref missing);
            firstTable.Borders[WdBorderType.wdBorderLeft].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
            firstTable.Borders[WdBorderType.wdBorderRight].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
            firstTable.Borders[WdBorderType.wdBorderTop].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
            firstTable.Borders[WdBorderType.wdBorderBottom].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
            firstTable.Borders[WdBorderType.wdBorderVertical].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
            firstTable.AllowAutoFit = true;
            firstTable.AutoFitBehavior(WdAutoFitBehavior.wdAutoFitContent);

            for (int i = 0; i < dataT.Length; i++)
            {
                firstTable.Rows[1].Cells[i + 1].Range.Text = dataT[i];

                firstTable.Rows[2].Cells[i + 1].Range.Text = dataS[i];

                firstTable.Rows[3].Cells[i + 1].Range.Text = dataB[i];

                firstTable.Rows[4].Cells[i + 1].Range.Text = dataU[i];
            }
            firstTable.Rows[5].Cells[1].Range.Text = "Итого:";
            int sum = Convert.ToInt32(dataT[4]) + Convert.ToInt32(dataS[4]) + Convert.ToInt32(dataB[4]) + Convert.ToInt32(dataU[4]);
            firstTable.Rows[5].Cells[5].Range.Text = Convert.ToString(sum);
            para0.Range.InsertParagraphAfter();
            currentSumStand = (float)Convert.ToDouble(sum);
        }

        public void DataTableCornerFrame(Document document)
        {
            Paragraph para0 = document.Content.Paragraphs.Add(ref missing);
            para0.Range.Text = "Фитинги";
            para0.Range.InsertParagraphAfter();

            Paragraph para1 = document.Content.Paragraphs.Add(ref missing);
            string[] dataT = Calculations.FrameCorner(8);
            Table firstTable = document.Tables.Add(para1.Range, 2, 2, ref missing, ref missing);
            firstTable.Borders[WdBorderType.wdBorderLeft].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
            firstTable.Borders[WdBorderType.wdBorderRight].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
            firstTable.Borders[WdBorderType.wdBorderTop].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
            firstTable.Borders[WdBorderType.wdBorderBottom].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
            firstTable.Borders[WdBorderType.wdBorderVertical].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
            firstTable.AllowAutoFit = true;
            firstTable.AutoFitBehavior(WdAutoFitBehavior.wdAutoFitContent);

            firstTable.Rows[1].Cells[1].Range.Text = dataT[0];
            firstTable.Rows[1].Cells[2].Range.Text = dataT[1];
            firstTable.Rows[2].Cells[1].Range.Text = dataT[2];
            firstTable.Rows[2].Cells[2].Range.Text = dataT[3];

            para1.Range.InsertParagraphAfter();
            currentSumCorner = (float)Convert.ToDouble(dataT[1]);
        }

        public void FrameTableSum(Document document)
        {
            Paragraph para1 = document.Content.Paragraphs.Add(ref missing);
            Table firstTable = document.Tables.Add(para1.Range, 5, 4, ref missing, ref missing);
            firstTable.Borders[WdBorderType.wdBorderLeft].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
            firstTable.Borders[WdBorderType.wdBorderRight].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
            firstTable.Borders[WdBorderType.wdBorderTop].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
            firstTable.Borders[WdBorderType.wdBorderBottom].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
            firstTable.Borders[WdBorderType.wdBorderVertical].LineStyle = Word.WdLineStyle.wdLineStyleSingle;
            firstTable.AllowAutoFit = true;
            firstTable.AutoFitBehavior(WdAutoFitBehavior.wdAutoFitContent);

            firstTable.Rows[1].Cells[1].Range.Text = "Наименование";
            firstTable.Rows[1].Cells[2].Range.Text = "Цена за единицу";
            firstTable.Rows[1].Cells[3].Range.Text = "Всего";
            firstTable.Rows[1].Cells[4].Range.Text = "Итог";
            string[] dataB = Calculations.FrameBorderPrice(currentSumFrame);
            string[] dataS = Calculations.FrameStandPrice(currentSumStand);
            string[] dataC = Calculations.FrameCornerPrice(currentSumCorner);
            for (int i = 0; i < dataB.Length; i++)
            {
                firstTable.Rows[2].Cells[i + 1].Range.Text = dataB[i];
                firstTable.Rows[3].Cells[i + 1].Range.Text = dataS[i];
                firstTable.Rows[4].Cells[i + 1].Range.Text = dataC[i];
            }
            int sum = Convert.ToInt32(dataB[3]) + Convert.ToInt32(dataS[3]) + Convert.ToInt32(dataC[3]);
            firstTable.Rows[5].Cells[1].Range.Text = "Итого:";
            firstTable.Rows[5].Cells[4].Range.Text = Convert.ToString(sum);
        }

        public void HeaderFrame(Document document)
        {
            foreach (Section section in document.Sections)
            {
                Word.Range headerRange = section.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                Table Table = document.Tables.Add(headerRange, 1, 3, ref missing, ref missing);
                Table.Borders.Enable = 0; //для тестов
                Table.Rows[1].Cells[2].Range.Text = "Техническая документация\nДля сотрудников ООО \"ВЕГА\"";
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

        #endregion

        #region DocX

        public void DocX_Initialization()
        {
            winword.ShowAnimation = false;
            winword.Visible = false;
            Document document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);
            CreateDocument(document, HdrText, testData, dataName);
            try
            {
                // TODO: Здесь можно вызвать в ручную диалоговое окно и потом в ручную вставить в метод SaveAs2
                //document.SaveAs2("Path");
                document.Save();
            }
            catch (System.Runtime.InteropServices.COMException)
            {
                MessageBox.Show("Сохранение было отменено");
            }
            document.Close(varFalse, ref missing, ref missing);
            document = null;
            winword.Quit(ref varFalse, ref missing, ref missing);
            winword = null;
        }

        public static vm.ProjectInfoVM pjct { get; set; } = vm.ProjectVM.Current?.ProjectInfo;

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
            string Datastat = null;
            string Datastat2 = null;

            string Date = "Время заказа: " + Convert.ToString(pjct.Order.Date) + "\n";
            string Worker = "Исполнитель: " + pjct.Order.Worker + "\n";
            string OrderName = "Заказ: " + pjct.Order.OrderName + "\n";
            string Foots = "Ножки: " + "???" + "\n";
            string Realization = "Исполнение: ТРЕНД\n";
            string Maintenance = "Сторона обслуживания: " + Convert.ToString(pjct.View.Maintenance);

            string BuildName = "Обозначение установки: " + pjct.Order.BuildName + "\n";
            string Customer = "Заказчик: " + pjct.Order.Customer + "\n";
            string Object = "Объект: " + pjct.Order.Object + "\n";
            string Number = "Телефон заказчика: " + pjct.Order.Number + "\n";

            Datastat = Date + Worker + OrderName + Foots + Realization + Maintenance;
            Datastat2 = BuildName + Customer + Object + Number;

            Table OredrTable = document.Tables.Add(para1.Range, 1, 2, ref missing, ref missing);
            OredrTable.Borders.Enable = 0;
            OredrTable.Rows[1].Cells[1].Range.Text = Datastat;
            OredrTable.Rows[1].Cells[2].Range.Text = Datastat2;
        }

        public void shemeInit(Document document, Paragraph para1)
        {
            string path = Environment.CurrentDirectory + @"\\scheme.png";
            var existed = Project.Elements.ContainsKey("scheme");
            if (existed)
            {
                SaveImage(path, Project.Elements["scheme"]);
                object docRange = para1.Range;
                string imagePath = path;
                document.InlineShapes.AddPicture(imagePath, LinkToFile: true, SaveWithDocument: true, Range: docRange);
            }
            else
            {
                para1.Range.Text = "Нет схемы для текущего проекта";
            }
        }

        //создаёт таблицы
        public void CreateTables(Document document)
        {
            foreach (vm.Element i in vm.ProjectVM.Current.Grid.Elements)
            {
                var list = vm.InfoLine.GenerateInfoLines(i, i.DeviceType, i.InfoProperties).ToList();
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
        public void TableStructor(Document document, vm.Element el)
        {
            var list = vm.InfoLine.GenerateInfoLines(el, el.DeviceType, el.InfoProperties).ToList();
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

        #endregion
    }
}