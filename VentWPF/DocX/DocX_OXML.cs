using DocumentFormat.OpenXml;

using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using A = DocumentFormat.OpenXml.Drawing;
using DW = DocumentFormat.OpenXml.Drawing.Wordprocessing;
using PIC = DocumentFormat.OpenXml.Drawing.Pictures;

namespace VentWPF.DocX
{


    class BuildDocX
    {

        private static void AddImageToCell(TableCell cell, string relationshipId, string name)
        {
            var element =
              new Drawing(
                new DW.Inline(
                  new DW.Extent() { Cx = 990000L, Cy = 792000L },
                  new DW.EffectExtent()
                  {
                      LeftEdge = 0L,
                      TopEdge = 0L,
                      RightEdge = 0L,
                      BottomEdge = 0L
                  },
                  new DW.DocProperties()
                  {
                      Id = (UInt32Value)1U,
                      Name = "Picture 1"
                  },
                  new DW.NonVisualGraphicFrameDrawingProperties(
                      new A.GraphicFrameLocks() { NoChangeAspect = true }),
                  new A.Graphic(
                    new A.GraphicData(
                      new PIC.Picture(
                        new PIC.NonVisualPictureProperties(
                          new PIC.NonVisualDrawingProperties()
                          {
                              Id = (UInt32Value)0U,
                              Name = name
                          },
                          new PIC.NonVisualPictureDrawingProperties()),
                        new PIC.BlipFill(
                          new A.Blip(
                            new A.BlipExtensionList(
                              new A.BlipExtension()
                              {
                                  Uri = "{28A0092B-C50C-407E-A947-70E740481C1C}"
                              })
                           )
                          {
                              Embed = relationshipId,
                              CompressionState =
                              A.BlipCompressionValues.Print
                          },
                          new A.Stretch(
                            new A.FillRectangle())),
                          new PIC.ShapeProperties(
                            new A.Transform2D(
                              new A.Offset() { X = 0L, Y = 0L },
                              new A.Extents() { Cx = 990000L, Cy = 792000L }),
                            new A.PresetGeometry(
                              new A.AdjustValueList()
                            )
                            { Preset = A.ShapeTypeValues.Rectangle }))
                    )
                    { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" })
                )
                {
                    DistanceFromTop = (UInt32Value)0U,
                    DistanceFromBottom = (UInt32Value)0U,
                    DistanceFromLeft = (UInt32Value)0U,
                    DistanceFromRight = (UInt32Value)0U
                });

            cell.Append(new Paragraph(new Run(element)));
        }


        public static HeaderPart BuildHeader(MainDocumentPart mainPart)
        {
            //MainDocumentPart mainPart = doc.MainDocumentPart;
            HeaderPart header = mainPart.AddNewPart<HeaderPart>();

            string imageFile = Path.GetFullPath("Assets/Images/DocXImages/logo.png");
            string imageQR = Path.GetFullPath("Assets/Images/DocXImages/qr-code.gif");
            string info = "  170025, Тверская область, г. Тверь \n  ул. Бочкина, д.18, строение 3 офис 3 \n  Тел.: +7(4822)74-42-87 \n  ivv@vega-air.com";


            ImagePart imagePart = mainPart.AddImagePart(ImagePartType.Png);

            using (FileStream stream = new FileStream(imageFile, FileMode.Open))
            {
                imagePart.FeedData(stream);
            }

            ImagePart imagePartQR = mainPart.AddImagePart(ImagePartType.Gif);

            using (FileStream stream = new FileStream(imageQR, FileMode.Open))
            {
                imagePartQR.FeedData(stream);
            }

            Table dTable = new Table();
            TableProperties props = new TableProperties();
            dTable.AppendChild<TableProperties>(props);

            var inforow = new TableRow();
            var tl = new TableCell();

            AddImageToCell(tl, mainPart.GetIdOfPart(imagePart), "Picture 1.png");
            //tl.Append(new Paragraph(new Run(element)));
            tl.Append(new TableCellProperties());
            inforow.Append(tl);

            var tc = new TableCell();
            tc.Append(new Paragraph(new Run(new Text(info))));
            tc.Append(new TableCellProperties());
            inforow.Append(tc);


            var tqr = new TableCell();
            AddImageToCell(tqr, mainPart.GetIdOfPart(imagePart), "Picture 2.gif");
            tqr.Append(new TableCellProperties());
            inforow.Append(tqr);
            dTable.Append(inforow);

            if (mainPart.HeaderParts.Any())
                return null;

            //HeaderPart headerPart = mainPart.AddNewPart<HeaderPart>();

            string headerPartId = mainPart.GetIdOfPart(header);

            header.Header = new Header(
                            new Paragraph(
                              new ParagraphProperties(
                                new ParagraphStyleId() { Val = "Header" }),
                                new Run(new Table(dTable))));

            var sectionProperties = mainPart.Document
                                            .Body
                                            .GetFirstChild<SectionProperties>();
            sectionProperties.PrependChild<HeaderReference>(new HeaderReference()
            {
                Id = headerPartId
            });


            return header;

        }


        public static void InsertWordHeader(
                             string headerText, MainDocumentPart mainPart)
        {
            //MainDocumentPart mainPart = doc.MainDocumentPart;

           

            HeaderPart headerPart = mainPart.AddNewPart<HeaderPart>();

            string headerPartId = mainPart.GetIdOfPart(headerPart);

            headerPart.Header = new Header(
                            new Paragraph(
                              new ParagraphProperties(
                                new ParagraphStyleId() { Val = "Header" }),
                                new Run(new Text() { Text = headerText })));

            var sectionProperties = mainPart.Document
                                            .Body
                                            .GetFirstChild<SectionProperties>();
            sectionProperties.PrependChild<HeaderReference>(new HeaderReference()
            {
                Id = headerPartId
            });
        }
    }




    public class DocX_OXML
    {

        static void GenerateHeaderPartContent(HeaderPart part)
        {
            Header header1 = new Header() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "w14 wp14" } };
            header1.AddNamespaceDeclaration("wpc", "http://schemas.microsoft.com/office/word/2010/wordprocessingCanvas");
            header1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            header1.AddNamespaceDeclaration("o", "urn:schemas-microsoft-com:office:office");
            header1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            header1.AddNamespaceDeclaration("m", "http://schemas.openxmlformats.org/officeDocument/2006/math");
            header1.AddNamespaceDeclaration("v", "urn:schemas-microsoft-com:vml");
            header1.AddNamespaceDeclaration("wp14", "http://schemas.microsoft.com/office/word/2010/wordprocessingDrawing");
            header1.AddNamespaceDeclaration("wp", "http://schemas.openxmlformats.org/drawingml/2006/wordprocessingDrawing");
            header1.AddNamespaceDeclaration("w10", "urn:schemas-microsoft-com:office:word");
            header1.AddNamespaceDeclaration("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
            header1.AddNamespaceDeclaration("w14", "http://schemas.microsoft.com/office/word/2010/wordml");
            header1.AddNamespaceDeclaration("wpg", "http://schemas.microsoft.com/office/word/2010/wordprocessingGroup");
            header1.AddNamespaceDeclaration("wpi", "http://schemas.microsoft.com/office/word/2010/wordprocessingInk");
            header1.AddNamespaceDeclaration("wne", "http://schemas.microsoft.com/office/word/2006/wordml");
            header1.AddNamespaceDeclaration("wps", "http://schemas.microsoft.com/office/word/2010/wordprocessingShape");

            Paragraph paragraph1 = new Paragraph() { RsidParagraphAddition = "00164C17", RsidRunAdditionDefault = "00164C17" };

            ParagraphProperties paragraphProperties1 = new ParagraphProperties();
            ParagraphStyleId paragraphStyleId1 = new ParagraphStyleId() { Val = "Header" };

            paragraphProperties1.Append(paragraphStyleId1);

            Run run1 = new Run();
            Text text1 = new Text();
            text1.Text = "Header";

            run1.Append(text1);

            paragraph1.Append(paragraphProperties1);
            paragraph1.Append(run1);

            header1.Append(paragraph1);

            part.Header = header1;
        }

        public static void ChangeHeader(String documentPath)
        {
            // Replace header in target document with header of source document.
            using (WordprocessingDocument document = WordprocessingDocument.Open(documentPath, true))
            {
                // Get the main document part
                MainDocumentPart mainDocumentPart = document.MainDocumentPart;

                // Delete the existing header and footer parts
                mainDocumentPart.DeleteParts(mainDocumentPart.HeaderParts);
                mainDocumentPart.DeleteParts(mainDocumentPart.FooterParts);

                // Create a new header and footer part
                HeaderPart headerPart = mainDocumentPart.AddNewPart<HeaderPart>();
                FooterPart footerPart = mainDocumentPart.AddNewPart<FooterPart>();

                // Get Id of the headerPart and footer parts
                string headerPartId = mainDocumentPart.GetIdOfPart(headerPart);
                string footerPartId = mainDocumentPart.GetIdOfPart(footerPart);

                GenerateHeaderPartContent(headerPart);                

                // Get SectionProperties and Replace HeaderReference and FooterRefernce with new Id
                IEnumerable<SectionProperties> sections = mainDocumentPart.Document.Body.Elements<SectionProperties>();

                foreach (var section in sections)
                {
                    // Delete existing references to headers and footers
                    section.RemoveAllChildren<HeaderReference>();
                    section.RemoveAllChildren<FooterReference>();

                    // Create the new header and footer reference node
                    section.PrependChild<HeaderReference>(new HeaderReference() { Id = headerPartId });
                    section.PrependChild<FooterReference>(new FooterReference() { Id = footerPartId });
                }
            }
        }



        public static void Create()
        {
            ChangeHeader(@"D:\test.docx");

            // Create Document



        }
    }
}
