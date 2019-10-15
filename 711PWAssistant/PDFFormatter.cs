using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZetPDF;
using ZetPDF.Pdf;
using ZetPDF.Forms;
using ZetPDF.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Diagnostics;
using ZetPDF.Pdf.Printing;
using System.Drawing;


namespace _711PWAssistant
{
    class PDFFormatter
    {
        public PDFFormatter(bool printPreview)
        {

            double pageWidth;
            double pageHeight;
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            page.Size = PageSize.A4;
            pageWidth = page.Width;
            pageHeight = page.Height;
            XGraphics gfx = XGraphics.FromPdfPage(page);
            double fontHeight = 12;
            double boldFontHeight = 18;
            XFont font = new XFont("Arial", 12, XFontStyle.Regular);
            XFont boldFont = new XFont("Arial", boldFontHeight, XFontStyle.Bold);
            XFont smallDenotationFont = new XFont("Arial", 10, XFontStyle.Regular);

            double totalizerYLoc = 100;
            double totalizerXloc = 30;

            double cashierYLoc = 100;
            double cashierXLoc = 285;

            double safeYLoc;
            double safeXLoc;

            XSolidBrush darkGrayBox = new XSolidBrush(XColors.Gray);
            XSolidBrush greyBox = new XSolidBrush(XColors.WhiteSmoke);
            XSolidBrush whiteBox = new XSolidBrush(XColors.White);
            XPen pen = new XPen(XColors.Black);
            XPen linePen = new XPen(XColors.Black, 1);
            XPen thickPen = new XPen(XColors.Black, 5);

            XPoint lottoStartingCoords = new XPoint(0,0);
            XPoint cigStartingCoords = new XPoint(0, 0);

            gfx.DrawString("Totalizers", boldFont, XBrushes.Black, 30, 90);
            gfx.DrawLine(linePen, 30, 92, 265, 92);

            gfx.DrawLine(thickPen, 30, 66, 520, 66);

            gfx.DrawString("Paperwork Set for " + TextBoxBackingFields.PaperworkDate.ToShortDateString(), boldFont, XBrushes.Black, 30, 58);
            gfx.DrawString("Signature", new XFont("Arial", 10, XFontStyle.Italic), XBrushes.Black, 300, 58);
            gfx.DrawLine(pen, 350, 58, 520, 58);

            XRect cashierRect = new XRect(cashierXLoc, cashierYLoc, 85, font.Height);
            XRect cashierVarianceRect = new XRect(cashierXLoc + cashierRect.Width, cashierYLoc, 50, font.Height);
            XRect cashierChangeRect = new XRect(cashierVarianceRect.X + cashierVarianceRect.Width, cashierYLoc, 50, font.Height);
            XRect cashierDropsRect = new XRect(cashierChangeRect.X + cashierChangeRect.Width, cashierYLoc, 50, font.Height);

            gfx.DrawString("Cashier Totals", boldFont, XBrushes.Black, cashierXLoc, 90);
            gfx.DrawLine(linePen, cashierXLoc, 92, Convert.ToDouble(cashierXLoc + 235), 92);

            for (int i = 0; i < 9; i++)
            {
                XRect totalizerNameRects = new XRect(totalizerXloc, totalizerYLoc, 85, font.Height);
                XRect totalizerRects = new XRect(totalizerNameRects.X + totalizerNameRects.Width, totalizerYLoc, 150, font.Height);
                gfx.DrawRectangle(pen, greyBox, totalizerNameRects);
                gfx.DrawRectangle(pen, whiteBox, totalizerRects);
                totalizerYLoc += font.Height;

                switch (i)
                {
                    case 0:
                        gfx.DrawString("Low (Reg)", smallDenotationFont, XBrushes.Black, totalizerNameRects.X + 2, totalizerNameRects.Y + fontHeight - 1);
                        if (TextBoxBackingFields.LowFeedstock == null)
                        {
                            break;
                        }
                        
                        gfx.DrawString(TextBoxBackingFields.LowFeedstock, smallDenotationFont, XBrushes.Black, totalizerRects.X + 2, totalizerRects.Y + fontHeight - 1);
                        break;
                    case 1:
                        gfx.DrawString("High (Ult)", smallDenotationFont, XBrushes.Black, totalizerNameRects.X + 2, totalizerNameRects.Y + fontHeight - 1);
                        if (TextBoxBackingFields.HighFeedstock == null)
                        {
                            break;
                        }
                        
                        gfx.DrawString(TextBoxBackingFields.HighFeedstock, smallDenotationFont, XBrushes.Black, totalizerRects.X + 2, totalizerRects.Y + fontHeight - 1);
                        break;
                    case 2:
                        gfx.DrawString("Diesel", smallDenotationFont, XBrushes.Black, totalizerNameRects.X + 2, totalizerNameRects.Y + fontHeight - 1);
                        if (TextBoxBackingFields.Diesel == null)
                        {
                            break;
                        }
                        
                        gfx.DrawString(TextBoxBackingFields.Diesel, smallDenotationFont, XBrushes.Black, totalizerRects.X + 2, totalizerRects.Y + fontHeight - 1);
                        break;
                    case 3:
                        gfx.DrawString("Diesel Fiscal 5", smallDenotationFont, XBrushes.Black, totalizerNameRects.X + 2, totalizerNameRects.Y + fontHeight - 1);
                        if (TextBoxBackingFields.DieselFiscal5 == null)
                        {
                            break;
                        }
                        
                        gfx.DrawString(TextBoxBackingFields.DieselFiscal5, smallDenotationFont, XBrushes.Black, totalizerRects.X + 2, totalizerRects.Y + fontHeight - 1);
                        break;
                    case 4:
                        gfx.DrawString("Diesel-Ker. 1", smallDenotationFont, XBrushes.Black, totalizerNameRects.X + 2, totalizerNameRects.Y + fontHeight - 1);
                        if (TextBoxBackingFields.DieselKer1 == null)
                        {
                            break;
                        }
                        
                        gfx.DrawString(TextBoxBackingFields.DieselKer1, smallDenotationFont, XBrushes.Black, totalizerRects.X + 2, totalizerRects.Y + fontHeight - 1);
                        break;
                    case 5:
                        gfx.DrawString("Ult - E85 2", smallDenotationFont, XBrushes.Black, totalizerNameRects.X + 2, totalizerNameRects.Y + fontHeight - 1);
                        if (TextBoxBackingFields.UltE852 == null)
                        {
                            break;
                        }
                        
                        gfx.DrawString(TextBoxBackingFields.UltE852, smallDenotationFont, XBrushes.Black, totalizerRects.X + 2, totalizerRects.Y + fontHeight - 1);
                        break;
                    case 6:
                        gfx.DrawString("Unlead-Race", smallDenotationFont, XBrushes.Black, totalizerNameRects.X + 2, totalizerNameRects.Y + fontHeight - 1);
                        if (TextBoxBackingFields.UnleadRace == null)
                        {
                            break;
                        }
                        
                        gfx.DrawString(TextBoxBackingFields.UnleadRace, smallDenotationFont, XBrushes.Black, totalizerRects.X + 2, totalizerRects.Y + fontHeight - 1);
                        break;
                    case 7:
                        gfx.DrawString("2/def 3", smallDenotationFont, XBrushes.Black, totalizerNameRects.X + 2, totalizerNameRects.Y + fontHeight - 1);
                        if (TextBoxBackingFields.Def3 == null)
                        {
                            break;
                        }
                        
                        gfx.DrawString(TextBoxBackingFields.Def3, smallDenotationFont, XBrushes.Black, totalizerRects.X + 2, totalizerRects.Y + fontHeight - 1);
                        break;
                    case 8:
                        gfx.DrawString("Def - Rec 90", smallDenotationFont, XBrushes.Black, totalizerNameRects.X + 2, totalizerNameRects.Y + fontHeight - 1);
                        if (TextBoxBackingFields.DefRec90 == null)
                        {
                            break;
                        }
                        
                        gfx.DrawString(TextBoxBackingFields.DefRec90, smallDenotationFont, XBrushes.Black, totalizerRects.X + 2, totalizerRects.Y + fontHeight - 1);
                        break;
                }
            }

            for (int i = 0; i < 10; i++)
            {
                
                switch (i)
                {
                    case 0:
                        gfx.DrawRectangle(pen, greyBox, cashierRect);
                        gfx.DrawRectangle(pen, greyBox, cashierVarianceRect);
                        gfx.DrawRectangle(pen, greyBox, cashierChangeRect);
                        gfx.DrawRectangle(pen, greyBox, cashierDropsRect);
                        gfx.DrawString("Cashier", smallDenotationFont, XBrushes.Black, cashierRect.X + 2, cashierRect.Y + fontHeight - 1);
                        gfx.DrawString("Variance", smallDenotationFont, XBrushes.Black, cashierVarianceRect.X + 2, cashierVarianceRect.Y + fontHeight - 1);
                        gfx.DrawString("Change", smallDenotationFont, XBrushes.Black, cashierChangeRect.X + 2, cashierChangeRect.Y + fontHeight - 1);
                        gfx.DrawString("Drops", smallDenotationFont, XBrushes.Black, cashierDropsRect.X + 2, cashierDropsRect.Y + fontHeight - 1);
                        cashierYLoc += font.Height;

                        cashierRect = new XRect(cashierXLoc, cashierYLoc, 85, font.Height);
                        cashierVarianceRect = new XRect(cashierXLoc + cashierRect.Width, cashierYLoc, 50, font.Height);
                        cashierChangeRect = new XRect(cashierVarianceRect.X + cashierVarianceRect.Width, cashierYLoc, 50, font.Height);
                        cashierDropsRect = new XRect(cashierChangeRect.X + cashierChangeRect.Width, cashierYLoc, 50, font.Height);
                        if (TextBoxBackingFields.CashierName1 != null && TextBoxBackingFields.CashierName1 != "")
                        {
                            gfx.DrawRectangle(pen, whiteBox, cashierRect);
                            gfx.DrawRectangle(pen, whiteBox, cashierVarianceRect);
                            gfx.DrawRectangle(pen, whiteBox, cashierChangeRect);
                            gfx.DrawRectangle(pen, whiteBox, cashierDropsRect);
                            gfx.DrawString(TextBoxBackingFields.CashierName1.ToString(), smallDenotationFont, XBrushes.Black, cashierRect.X + 2, cashierRect.Y + fontHeight - 1);
                            gfx.DrawString(TextBoxBackingFields.CashierVariance1.ToString("C"), smallDenotationFont, XBrushes.Black, cashierVarianceRect.X + 2, cashierVarianceRect.Y + fontHeight - 1);
                            gfx.DrawString(TextBoxBackingFields.CashierChange1.ToString("C"), smallDenotationFont, XBrushes.Black, cashierChangeRect.X + 2, cashierChangeRect.Y + fontHeight - 1);
                            gfx.DrawString(TextBoxBackingFields.CashierDrops1.ToString("C"), smallDenotationFont, XBrushes.Black, cashierDropsRect.X + 2, cashierDropsRect.Y + fontHeight - 1);
                            cashierYLoc += font.Height;
                        }
                        break;
                    case 1:
                        if (TextBoxBackingFields.CashierName2 != null && TextBoxBackingFields.CashierName2 != "")
                        {
                            cashierRect = new XRect(cashierXLoc, cashierYLoc, 85, font.Height);
                            cashierVarianceRect = new XRect(cashierXLoc + cashierRect.Width, cashierYLoc, 50, font.Height);
                            cashierChangeRect = new XRect(cashierVarianceRect.X + cashierVarianceRect.Width, cashierYLoc, 50, font.Height);
                            cashierDropsRect = new XRect(cashierChangeRect.X + cashierChangeRect.Width, cashierYLoc, 50, font.Height);
                            gfx.DrawRectangle(pen, whiteBox, cashierRect);
                            gfx.DrawRectangle(pen, whiteBox, cashierVarianceRect);
                            gfx.DrawRectangle(pen, whiteBox, cashierChangeRect);
                            gfx.DrawRectangle(pen, whiteBox, cashierDropsRect);
                            gfx.DrawString(TextBoxBackingFields.CashierName2.ToString(), smallDenotationFont, XBrushes.Black, cashierRect.X + 2, cashierRect.Y + fontHeight - 1);
                            gfx.DrawString(TextBoxBackingFields.CashierVariance2.ToString("C"), smallDenotationFont, XBrushes.Black, cashierVarianceRect.X + 2, cashierVarianceRect.Y + fontHeight - 1);
                            gfx.DrawString(TextBoxBackingFields.CashierChange2.ToString("C"), smallDenotationFont, XBrushes.Black, cashierChangeRect.X + 2, cashierChangeRect.Y + fontHeight - 1);
                            gfx.DrawString(TextBoxBackingFields.CashierDrops2.ToString("C"), smallDenotationFont, XBrushes.Black, cashierDropsRect.X + 2, cashierDropsRect.Y + fontHeight - 1);
                            cashierYLoc += font.Height;
                        }
                        break;
                    case 2:
                        if (TextBoxBackingFields.CashierName3 != null && TextBoxBackingFields.CashierName3 != "")
                        {
                            cashierRect = new XRect(cashierXLoc, cashierYLoc, 85, font.Height);
                            cashierVarianceRect = new XRect(cashierXLoc + cashierRect.Width, cashierYLoc, 50, font.Height);
                            cashierChangeRect = new XRect(cashierVarianceRect.X + cashierVarianceRect.Width, cashierYLoc, 50, font.Height);
                            cashierDropsRect = new XRect(cashierChangeRect.X + cashierChangeRect.Width, cashierYLoc, 50, font.Height);
                            gfx.DrawRectangle(pen, whiteBox, cashierRect);
                            gfx.DrawRectangle(pen, whiteBox, cashierVarianceRect);
                            gfx.DrawRectangle(pen, whiteBox, cashierChangeRect);
                            gfx.DrawRectangle(pen, whiteBox, cashierDropsRect);
                            gfx.DrawString(TextBoxBackingFields.CashierName3.ToString(), smallDenotationFont, XBrushes.Black, cashierRect.X + 2, cashierRect.Y + fontHeight - 1);
                            gfx.DrawString(TextBoxBackingFields.CashierVariance3.ToString("C"), smallDenotationFont, XBrushes.Black, cashierVarianceRect.X + 2, cashierVarianceRect.Y + fontHeight - 1);
                            gfx.DrawString(TextBoxBackingFields.CashierChange3.ToString("C"), smallDenotationFont, XBrushes.Black, cashierChangeRect.X + 2, cashierChangeRect.Y + fontHeight - 1);
                            gfx.DrawString(TextBoxBackingFields.CashierDrops3.ToString("C"), smallDenotationFont, XBrushes.Black, cashierDropsRect.X + 2, cashierDropsRect.Y + fontHeight - 1);
                            cashierYLoc += font.Height;
                        }
                        break;
                    case 3:
                        if (TextBoxBackingFields.CashierName4 != null && TextBoxBackingFields.CashierName4 != "")
                        {
                            cashierRect = new XRect(cashierXLoc, cashierYLoc, 85, font.Height);
                            cashierVarianceRect = new XRect(cashierXLoc + cashierRect.Width, cashierYLoc, 50, font.Height);
                            cashierChangeRect = new XRect(cashierVarianceRect.X + cashierVarianceRect.Width, cashierYLoc, 50, font.Height);
                            cashierDropsRect = new XRect(cashierChangeRect.X + cashierChangeRect.Width, cashierYLoc, 50, font.Height);
                            gfx.DrawRectangle(pen, whiteBox, cashierRect);
                            gfx.DrawRectangle(pen, whiteBox, cashierVarianceRect);
                            gfx.DrawRectangle(pen, whiteBox, cashierChangeRect);
                            gfx.DrawRectangle(pen, whiteBox, cashierDropsRect);
                            gfx.DrawString(TextBoxBackingFields.CashierName4.ToString(), smallDenotationFont, XBrushes.Black, cashierRect.X + 2, cashierRect.Y + fontHeight - 1);
                            gfx.DrawString(TextBoxBackingFields.CashierVariance4.ToString("C"), smallDenotationFont, XBrushes.Black, cashierVarianceRect.X + 2, cashierVarianceRect.Y + fontHeight - 1);
                            gfx.DrawString(TextBoxBackingFields.CashierChange4.ToString("C"), smallDenotationFont, XBrushes.Black, cashierChangeRect.X + 2, cashierChangeRect.Y + fontHeight - 1);
                            gfx.DrawString(TextBoxBackingFields.CashierDrops4.ToString("C"), smallDenotationFont, XBrushes.Black, cashierDropsRect.X + 2, cashierDropsRect.Y + fontHeight - 1);
                            cashierYLoc += font.Height;
                        }
                        break;
                    case 4:
                        if (TextBoxBackingFields.CashierName5 != null && TextBoxBackingFields.CashierName5 != "")
                        {
                            cashierRect = new XRect(cashierXLoc, cashierYLoc, 85, font.Height);
                            cashierVarianceRect = new XRect(cashierXLoc + cashierRect.Width, cashierYLoc, 50, font.Height);
                            cashierChangeRect = new XRect(cashierVarianceRect.X + cashierVarianceRect.Width, cashierYLoc, 50, font.Height);
                            cashierDropsRect = new XRect(cashierChangeRect.X + cashierChangeRect.Width, cashierYLoc, 50, font.Height);
                            gfx.DrawRectangle(pen, whiteBox, cashierRect);
                            gfx.DrawRectangle(pen, whiteBox, cashierVarianceRect);
                            gfx.DrawRectangle(pen, whiteBox, cashierChangeRect);
                            gfx.DrawRectangle(pen, whiteBox, cashierDropsRect);
                            gfx.DrawString(TextBoxBackingFields.CashierName5.ToString(), smallDenotationFont, XBrushes.Black, cashierRect.X + 2, cashierRect.Y + fontHeight - 1);
                            gfx.DrawString(TextBoxBackingFields.CashierVariance5.ToString("C"), smallDenotationFont, XBrushes.Black, cashierVarianceRect.X + 2, cashierVarianceRect.Y + fontHeight - 1);
                            gfx.DrawString(TextBoxBackingFields.CashierChange5.ToString("C"), smallDenotationFont, XBrushes.Black, cashierChangeRect.X + 2, cashierChangeRect.Y + fontHeight - 1);
                            gfx.DrawString(TextBoxBackingFields.CashierDrops5.ToString("C"), smallDenotationFont, XBrushes.Black, cashierDropsRect.X + 2, cashierDropsRect.Y + fontHeight - 1);
                            cashierYLoc += font.Height;
                        }
                        break;
                    case 5:
                        if (TextBoxBackingFields.CashierName6 != null && TextBoxBackingFields.CashierName6 != "")
                        {
                            cashierRect = new XRect(cashierXLoc, cashierYLoc, 85, font.Height);
                            cashierVarianceRect = new XRect(cashierXLoc + cashierRect.Width, cashierYLoc, 50, font.Height);
                            cashierChangeRect = new XRect(cashierVarianceRect.X + cashierVarianceRect.Width, cashierYLoc, 50, font.Height);
                            cashierDropsRect = new XRect(cashierChangeRect.X + cashierChangeRect.Width, cashierYLoc, 50, font.Height);
                            gfx.DrawRectangle(pen, whiteBox, cashierRect);
                            gfx.DrawRectangle(pen, whiteBox, cashierVarianceRect);
                            gfx.DrawRectangle(pen, whiteBox, cashierChangeRect);
                            gfx.DrawRectangle(pen, whiteBox, cashierDropsRect);
                            gfx.DrawString(TextBoxBackingFields.CashierName6.ToString(), smallDenotationFont, XBrushes.Black, cashierRect.X + 2, cashierRect.Y + fontHeight - 1);
                            gfx.DrawString(TextBoxBackingFields.CashierVariance6.ToString("C"), smallDenotationFont, XBrushes.Black, cashierVarianceRect.X + 2, cashierVarianceRect.Y + fontHeight - 1);
                            gfx.DrawString(TextBoxBackingFields.CashierChange6.ToString("C"), smallDenotationFont, XBrushes.Black, cashierChangeRect.X + 2, cashierChangeRect.Y + fontHeight - 1);
                            gfx.DrawString(TextBoxBackingFields.CashierDrops6.ToString("C"), smallDenotationFont, XBrushes.Black, cashierDropsRect.X + 2, cashierDropsRect.Y + fontHeight - 1);
                            cashierYLoc += font.Height;
                        }
                        break;
                    case 6:
                        if (TextBoxBackingFields.CashierName7 != null && TextBoxBackingFields.CashierName7 != "")
                        {
                            cashierRect = new XRect(cashierXLoc, cashierYLoc, 85, font.Height);
                            cashierVarianceRect = new XRect(cashierXLoc + cashierRect.Width, cashierYLoc, 50, font.Height);
                            cashierChangeRect = new XRect(cashierVarianceRect.X + cashierVarianceRect.Width, cashierYLoc, 50, font.Height);
                            cashierDropsRect = new XRect(cashierChangeRect.X + cashierChangeRect.Width, cashierYLoc, 50, font.Height);
                            gfx.DrawRectangle(pen, whiteBox, cashierRect);
                            gfx.DrawRectangle(pen, whiteBox, cashierVarianceRect);
                            gfx.DrawRectangle(pen, whiteBox, cashierChangeRect);
                            gfx.DrawRectangle(pen, whiteBox, cashierDropsRect);
                            gfx.DrawString(TextBoxBackingFields.CashierName7.ToString(), smallDenotationFont, XBrushes.Black, cashierRect.X + 2, cashierRect.Y + fontHeight - 1);
                            gfx.DrawString(TextBoxBackingFields.CashierVariance7.ToString("C"), smallDenotationFont, XBrushes.Black, cashierVarianceRect.X + 2, cashierVarianceRect.Y + fontHeight - 1);
                            gfx.DrawString(TextBoxBackingFields.CashierChange7.ToString("C"), smallDenotationFont, XBrushes.Black, cashierChangeRect.X + 2, cashierChangeRect.Y + fontHeight - 1);
                            gfx.DrawString(TextBoxBackingFields.CashierDrops7.ToString("C"), smallDenotationFont, XBrushes.Black, cashierDropsRect.X + 2, cashierDropsRect.Y + fontHeight - 1);
                            cashierYLoc += font.Height;
                        }
                        break;
                    case 7:
                        if (TextBoxBackingFields.CashierName8 != null && TextBoxBackingFields.CashierName8 != "")
                        {
                            cashierRect = new XRect(cashierXLoc, cashierYLoc, 85, font.Height);
                            cashierVarianceRect = new XRect(cashierXLoc + cashierRect.Width, cashierYLoc, 50, font.Height);
                            cashierChangeRect = new XRect(cashierVarianceRect.X + cashierVarianceRect.Width, cashierYLoc, 50, font.Height);
                            cashierDropsRect = new XRect(cashierChangeRect.X + cashierChangeRect.Width, cashierYLoc, 50, font.Height);
                            gfx.DrawRectangle(pen, whiteBox, cashierRect);
                            gfx.DrawRectangle(pen, whiteBox, cashierVarianceRect);
                            gfx.DrawRectangle(pen, whiteBox, cashierChangeRect);
                            gfx.DrawRectangle(pen, whiteBox, cashierDropsRect);
                            gfx.DrawString(TextBoxBackingFields.CashierName8.ToString(), smallDenotationFont, XBrushes.Black, cashierRect.X + 2, cashierRect.Y + fontHeight - 1);
                            gfx.DrawString(TextBoxBackingFields.CashierVariance8.ToString("C"), smallDenotationFont, XBrushes.Black, cashierVarianceRect.X + 2, cashierVarianceRect.Y + fontHeight - 1);
                            gfx.DrawString(TextBoxBackingFields.CashierChange8.ToString("C"), smallDenotationFont, XBrushes.Black, cashierChangeRect.X + 2, cashierChangeRect.Y + fontHeight - 1);
                            gfx.DrawString(TextBoxBackingFields.CashierDrops8.ToString("C"), smallDenotationFont, XBrushes.Black, cashierDropsRect.X + 2, cashierDropsRect.Y + fontHeight - 1);
                            cashierYLoc += font.Height;
                        }
                        break;
                    case 8:
                        if (TextBoxBackingFields.CashierName9 != null && TextBoxBackingFields.CashierName9 != "")
                        {
                            cashierRect = new XRect(cashierXLoc, cashierYLoc, 85, font.Height);
                            cashierVarianceRect = new XRect(cashierXLoc + cashierRect.Width, cashierYLoc, 50, font.Height);
                            cashierChangeRect = new XRect(cashierVarianceRect.X + cashierVarianceRect.Width, cashierYLoc, 50, font.Height);
                            cashierDropsRect = new XRect(cashierChangeRect.X + cashierChangeRect.Width, cashierYLoc, 50, font.Height);
                            gfx.DrawRectangle(pen, whiteBox, cashierRect);
                            gfx.DrawRectangle(pen, whiteBox, cashierVarianceRect);
                            gfx.DrawRectangle(pen, whiteBox, cashierChangeRect);
                            gfx.DrawRectangle(pen, whiteBox, cashierDropsRect);
                            gfx.DrawString(TextBoxBackingFields.CashierName9.ToString(), smallDenotationFont, XBrushes.Black, cashierRect.X + 2, cashierRect.Y + fontHeight - 1);
                            gfx.DrawString(TextBoxBackingFields.CashierVariance9.ToString("C"), smallDenotationFont, XBrushes.Black, cashierVarianceRect.X + 2, cashierVarianceRect.Y + fontHeight - 1);
                            gfx.DrawString(TextBoxBackingFields.CashierChange9.ToString("C"), smallDenotationFont, XBrushes.Black, cashierChangeRect.X + 2, cashierChangeRect.Y + fontHeight - 1);
                            gfx.DrawString(TextBoxBackingFields.CashierDrops9.ToString("C"), smallDenotationFont, XBrushes.Black, cashierDropsRect.X + 2, cashierDropsRect.Y + fontHeight - 1);
                            cashierYLoc += font.Height;
                        }
                        break;
                    case 9:
                        if (TextBoxBackingFields.CashierName10 != null && TextBoxBackingFields.CashierName10 != "")
                        {
                            cashierRect = new XRect(cashierXLoc, cashierYLoc, 85, font.Height);
                            cashierVarianceRect = new XRect(cashierXLoc + cashierRect.Width, cashierYLoc, 50, font.Height);
                            cashierChangeRect = new XRect(cashierVarianceRect.X + cashierVarianceRect.Width, cashierYLoc, 50, font.Height);
                            cashierDropsRect = new XRect(cashierChangeRect.X + cashierChangeRect.Width, cashierYLoc, 50, font.Height);
                            gfx.DrawRectangle(pen, whiteBox, cashierRect);
                            gfx.DrawRectangle(pen, whiteBox, cashierVarianceRect);
                            gfx.DrawRectangle(pen, whiteBox, cashierChangeRect);
                            gfx.DrawRectangle(pen, whiteBox, cashierDropsRect);
                            gfx.DrawString(TextBoxBackingFields.CashierName10.ToString(), smallDenotationFont, XBrushes.Black, cashierRect.X + 2, cashierRect.Y + fontHeight - 1);
                            gfx.DrawString(TextBoxBackingFields.CashierVariance10.ToString("C"), smallDenotationFont, XBrushes.Black, cashierVarianceRect.X + 2, cashierVarianceRect.Y + fontHeight - 1);
                            gfx.DrawString(TextBoxBackingFields.CashierChange10.ToString("C"), smallDenotationFont, XBrushes.Black, cashierChangeRect.X + 2, cashierChangeRect.Y + fontHeight - 1);
                            gfx.DrawString(TextBoxBackingFields.CashierDrops10.ToString("C"), smallDenotationFont, XBrushes.Black, cashierDropsRect.X + 2, cashierDropsRect.Y + fontHeight - 1);
                            cashierYLoc += font.Height;
                        }
                        lottoStartingCoords.X = cashierRect.X;
                        break;
                }
            }
            gfx.DrawString("Totals:", smallDenotationFont, XBrushes.Black, cashierRect.X + 2 + cashierRect.Width / 2, cashierYLoc + fontHeight - 1);
            gfx.DrawString(TextBoxBackingFields.VarianceTotal.ToString("C"), smallDenotationFont, XBrushes.Black, cashierVarianceRect.X + 2, cashierYLoc + fontHeight - 1);
            gfx.DrawString(TextBoxBackingFields.ChangeTotal.ToString("C"), smallDenotationFont,XBrushes.Black, cashierChangeRect.X + 2, cashierYLoc + fontHeight - 1);
            gfx.DrawString(TextBoxBackingFields.DropsTotal.ToString("C"), smallDenotationFont, XBrushes.Black, cashierDropsRect.X + 2, cashierYLoc + fontHeight - 1);
            cashierYLoc += font.Height;
            gfx.DrawString(TextBoxBackingFields.Checks.ToString("C"), smallDenotationFont, XBrushes.Black, cashierDropsRect.X + 2, cashierYLoc + fontHeight - 1);
            gfx.DrawString("Checks:", smallDenotationFont, XBrushes.Black, cashierChangeRect.X + 2, cashierYLoc + fontHeight - 1);
            cashierYLoc += font.Height;
            gfx.DrawString("Bank Deposit:", smallDenotationFont, XBrushes.Black, cashierVarianceRect.X + 26, cashierYLoc + fontHeight - 1);
            
            gfx.DrawString(TextBoxBackingFields.BankDeposit.ToString("C"), smallDenotationFont, XBrushes.Black, cashierDropsRect.X + 2, cashierYLoc + fontHeight - 1);
            lottoStartingCoords.Y = cashierYLoc + 40;

            safeYLoc = totalizerYLoc + 30;
            safeXLoc = totalizerXloc;
            gfx.DrawString("Safe Totals", boldFont, XBrushes.Black, safeXLoc + 2, safeYLoc);
            
            gfx.DrawLine(linePen, 30, safeYLoc + 2, 275, safeYLoc + 2);

            safeYLoc += font.Height + 10;

            XRect safeRect;
            XRect safeDenomRect;
            double middleRectXCoord = 0;
            XRect safeCashAmountRect = new XRect();
            XPoint safeBorderTopRight = new XPoint(0,0);
            XPoint safeBorderBottomRight = new XPoint(0,0);
            XPoint safeBorderTopLeft = new XPoint(0, 0);
            XPoint safeBorderBottomLeft = new XPoint(0, 0);

            for (int i = 0; i < 14; i++)
            {
                switch (i)
                {
                    case 0:
                        safeRect = new XRect(safeXLoc * 2.7 + 8, safeYLoc, 93, font.Height);
                        safeRect.Y -= safeRect.Height;
                        gfx.DrawRectangle(pen, greyBox, safeRect);
                        gfx.DrawString("Gas Safe", smallDenotationFont, XBrushes.Black, safeRect, XStringFormats.Center);
                        safeRect.X += safeRect.Width;
                        gfx.DrawRectangle(pen, greyBox, safeRect);
                        gfx.DrawString("Diesel Safe", smallDenotationFont, XBrushes.Black, safeRect, XStringFormats.Center);
                        safeBorderTopRight = new XPoint(safeRect.X + safeRect.Width, safeRect.Y);
                        safeBorderTopLeft = new XPoint(30, safeRect.Y);

                        safeYLoc += font.Height;
                        safeXLoc += 8;
                        break;
                    case 1:
                        safeRect = new XRect(safeXLoc, safeYLoc, 30, font.Height);
                        safeDenomRect = new XRect(30, safeYLoc, 70, font.Height);
                        safeRect.Y -= safeRect.Height;
                        safeDenomRect.Y -= safeRect.Height;
                        gfx.DrawRectangle(pen, greyBox, safeDenomRect);
                        gfx.DrawString("Pennies", smallDenotationFont, XBrushes.Black, safeDenomRect.X + 2, safeDenomRect.Y + 2, XStringFormats.TopLeft);
                        safeRect.X += safeRect.Width * 1.7;
                        gfx.DrawRectangle(pen, greyBox, safeRect);
                        gfx.DrawString(TextBoxBackingFields.FrontPennies.ToString(), smallDenotationFont, XBrushes.Black, safeRect, XStringFormats.Center);
                        safeCashAmountRect = new XRect(safeRect.X + safeRect.Width, safeRect.Y, safeDenomRect.Width, font.Height);
                        safeRect.X += safeRect.Width * 1.4;
                        middleRectXCoord = safeCashAmountRect.X;
                        gfx.DrawRectangle(pen, whiteBox, safeCashAmountRect);
                        gfx.DrawString((TextBoxBackingFields.FrontPennies*.50).ToString("C"), smallDenotationFont, XBrushes.Black, safeCashAmountRect.X + 2, safeCashAmountRect.Y + 2, XStringFormats.TopLeft);
                        safeRect.X += safeRect.Width * 1.7;
                        gfx.DrawRectangle(pen, greyBox, safeRect);
                        gfx.DrawString(TextBoxBackingFields.BackPennies.ToString(), smallDenotationFont, XBrushes.Black, safeRect, XStringFormats.Center);
                        safeCashAmountRect = new XRect(safeRect.X + safeRect.Width, safeRect.Y, safeDenomRect.Width - 7, font.Height);
                        safeRect.X += safeRect.Width * 1.4;
                        gfx.DrawRectangle(pen, whiteBox, safeCashAmountRect);
                        gfx.DrawString((TextBoxBackingFields.BackPennies * .50).ToString("C"), smallDenotationFont, XBrushes.Black, safeCashAmountRect.X + 2, safeCashAmountRect.Y + 2, XStringFormats.TopLeft);

                        safeYLoc += font.Height;
                        break;
                    case 2:
                        safeRect = new XRect(safeXLoc, safeYLoc, 30, font.Height);
                        safeDenomRect = new XRect(30, safeYLoc, 70, font.Height);
                        safeRect.Y -= safeRect.Height;
                        safeDenomRect.Y -= safeRect.Height;
                        gfx.DrawRectangle(pen, greyBox, safeDenomRect);
                        gfx.DrawString("Nickles", smallDenotationFont, XBrushes.Black, safeDenomRect.X + 2, safeDenomRect.Y + 2, XStringFormats.TopLeft);
                        safeRect.X += safeRect.Width * 1.7;
                        gfx.DrawRectangle(pen, greyBox, safeRect);
                        gfx.DrawString(TextBoxBackingFields.FrontNickles.ToString(), smallDenotationFont, XBrushes.Black, safeRect, XStringFormats.Center);
                        safeCashAmountRect = new XRect(safeRect.X + safeRect.Width, safeRect.Y, safeDenomRect.Width, font.Height);
                        safeRect.X += safeRect.Width * 1.4;
                        gfx.DrawRectangle(pen, whiteBox, safeCashAmountRect);
                        gfx.DrawString((TextBoxBackingFields.FrontNickles * 2.00).ToString("C"), smallDenotationFont, XBrushes.Black, safeCashAmountRect.X + 2, safeCashAmountRect.Y + 2, XStringFormats.TopLeft);
                        safeRect.X += safeRect.Width * 1.7;
                        gfx.DrawRectangle(pen, greyBox, safeRect);
                        gfx.DrawString(TextBoxBackingFields.BackNickles.ToString(), smallDenotationFont, XBrushes.Black, safeRect, XStringFormats.Center);
                        safeCashAmountRect = new XRect(safeRect.X + safeRect.Width, safeRect.Y, safeDenomRect.Width - 7, font.Height);
                        safeRect.X += safeRect.Width * 1.4;
                        gfx.DrawRectangle(pen, whiteBox, safeCashAmountRect);
                        gfx.DrawString((TextBoxBackingFields.BackNickles * 2.00).ToString("C"), smallDenotationFont, XBrushes.Black, safeCashAmountRect.X + 2, safeCashAmountRect.Y + 2, XStringFormats.TopLeft);

                        safeYLoc += font.Height;
                        break;
                    case 3:
                        safeRect = new XRect(safeXLoc, safeYLoc, 30, font.Height);
                        safeDenomRect = new XRect(30, safeYLoc, 70, font.Height);
                        safeRect.Y -= safeRect.Height;
                        safeDenomRect.Y -= safeRect.Height;
                        gfx.DrawRectangle(pen, greyBox, safeDenomRect);
                        gfx.DrawString("Dimes", smallDenotationFont, XBrushes.Black, safeDenomRect.X + 2, safeDenomRect.Y + 2, XStringFormats.TopLeft);
                        safeRect.X += safeRect.Width * 1.7;
                        gfx.DrawRectangle(pen, greyBox, safeRect);
                        gfx.DrawString(TextBoxBackingFields.FrontDimes.ToString(), smallDenotationFont, XBrushes.Black, safeRect, XStringFormats.Center);
                        safeCashAmountRect = new XRect(safeRect.X + safeRect.Width, safeRect.Y, safeDenomRect.Width, font.Height);
                        safeRect.X += safeRect.Width * 1.4;
                        gfx.DrawRectangle(pen, whiteBox, safeCashAmountRect);
                        gfx.DrawString((TextBoxBackingFields.FrontDimes * 5.00).ToString("C"), smallDenotationFont, XBrushes.Black, safeCashAmountRect.X + 2, safeCashAmountRect.Y + 2, XStringFormats.TopLeft);
                        safeRect.X += safeRect.Width * 1.7;
                        gfx.DrawRectangle(pen, greyBox, safeRect);
                        gfx.DrawString(TextBoxBackingFields.BackDimes.ToString(), smallDenotationFont, XBrushes.Black, safeRect, XStringFormats.Center);
                        safeCashAmountRect = new XRect(safeRect.X + safeRect.Width, safeRect.Y, safeDenomRect.Width - 7, font.Height);
                        safeRect.X += safeRect.Width * 1.4;
                        gfx.DrawRectangle(pen, whiteBox, safeCashAmountRect);
                        gfx.DrawString((TextBoxBackingFields.BackDimes * 5.00).ToString("C"), smallDenotationFont, XBrushes.Black, safeCashAmountRect.X + 2, safeCashAmountRect.Y + 2, XStringFormats.TopLeft);

                        safeYLoc += font.Height;
                        break;
                    case 4:
                        safeRect = new XRect(safeXLoc, safeYLoc, 30, font.Height);
                        safeDenomRect = new XRect(30, safeYLoc, 70, font.Height);
                        safeRect.Y -= safeRect.Height;
                        safeDenomRect.Y -= safeRect.Height;
                        gfx.DrawRectangle(pen, greyBox, safeDenomRect);
                        gfx.DrawString("Quarters", smallDenotationFont, XBrushes.Black, safeDenomRect.X + 2, safeDenomRect.Y + 2, XStringFormats.TopLeft);
                        safeRect.X += safeRect.Width * 1.7;
                        gfx.DrawRectangle(pen, greyBox, safeRect);
                        gfx.DrawString(TextBoxBackingFields.FrontQuarters.ToString(), smallDenotationFont, XBrushes.Black, safeRect, XStringFormats.Center);
                        safeCashAmountRect = new XRect(safeRect.X + safeRect.Width, safeRect.Y, safeDenomRect.Width, font.Height);
                        safeRect.X += safeRect.Width * 1.4;
                        gfx.DrawRectangle(pen, whiteBox, safeCashAmountRect);
                        gfx.DrawString((TextBoxBackingFields.FrontQuarters * 10.00).ToString("C"), smallDenotationFont, XBrushes.Black, safeCashAmountRect.X + 2, safeCashAmountRect.Y + 2, XStringFormats.TopLeft);
                        safeRect.X += safeRect.Width * 1.7;
                        gfx.DrawRectangle(pen, greyBox, safeRect);
                        gfx.DrawString(TextBoxBackingFields.BackQuarters.ToString(), smallDenotationFont, XBrushes.Black, safeRect, XStringFormats.Center);
                        safeCashAmountRect = new XRect(safeRect.X + safeRect.Width, safeRect.Y, safeDenomRect.Width - 7, font.Height);
                        safeRect.X += safeRect.Width * 1.4;
                        gfx.DrawRectangle(pen, whiteBox, safeCashAmountRect);
                        gfx.DrawString((TextBoxBackingFields.BackQuarters * 10.00).ToString("C"), smallDenotationFont, XBrushes.Black, safeCashAmountRect.X + 2, safeCashAmountRect.Y + 2, XStringFormats.TopLeft);

                        safeYLoc += font.Height;
                        break;
                    case 5:
                        safeRect = new XRect(safeXLoc, safeYLoc, 30, font.Height);
                        safeDenomRect = new XRect(30, safeYLoc, 70, font.Height);
                        safeRect.Y -= safeRect.Height;
                        safeDenomRect.Y -= safeRect.Height;
                        gfx.DrawRectangle(pen, greyBox, safeDenomRect);
                        gfx.DrawString("Ones", smallDenotationFont, XBrushes.Black, safeDenomRect.X + 2, safeDenomRect.Y + 2, XStringFormats.TopLeft);
                        safeRect.X += safeRect.Width * 1.7;
                        gfx.DrawRectangle(pen, greyBox, safeRect);
                        gfx.DrawString(TextBoxBackingFields.FrontOnes.ToString(), smallDenotationFont, XBrushes.Black, safeRect, XStringFormats.Center);
                        safeCashAmountRect = new XRect(safeRect.X + safeRect.Width, safeRect.Y, safeDenomRect.Width, font.Height);
                        safeRect.X += safeRect.Width * 1.4;
                        gfx.DrawRectangle(pen, whiteBox, safeCashAmountRect);
                        gfx.DrawString((TextBoxBackingFields.FrontOnes * 20.00).ToString("C"), smallDenotationFont, XBrushes.Black, safeCashAmountRect.X + 2, safeCashAmountRect.Y + 2, XStringFormats.TopLeft);
                        safeRect.X += safeRect.Width * 1.7;
                        gfx.DrawRectangle(pen, greyBox, safeRect);
                        gfx.DrawString(TextBoxBackingFields.BackOnes.ToString(), smallDenotationFont, XBrushes.Black, safeRect, XStringFormats.Center);
                        safeCashAmountRect = new XRect(safeRect.X + safeRect.Width, safeRect.Y, safeDenomRect.Width - 7, font.Height);
                        safeRect.X += safeRect.Width * 1.4;
                        gfx.DrawRectangle(pen, whiteBox, safeCashAmountRect);
                        gfx.DrawString((TextBoxBackingFields.BackOnes * 20.00).ToString("C"), smallDenotationFont, XBrushes.Black, safeCashAmountRect.X + 2, safeCashAmountRect.Y + 2, XStringFormats.TopLeft);

                        safeYLoc += font.Height;
                        break;
                    case 6:
                        safeRect = new XRect(safeXLoc, safeYLoc, 30, font.Height);
                        safeDenomRect = new XRect(30, safeYLoc, 70, font.Height);
                        safeRect.Y -= safeRect.Height;
                        safeDenomRect.Y -= safeRect.Height;
                        gfx.DrawRectangle(pen, greyBox, safeDenomRect);
                        gfx.DrawString("Fives", smallDenotationFont, XBrushes.Black, safeDenomRect.X + 2, safeDenomRect.Y + 2, XStringFormats.TopLeft);
                        safeRect.X += safeRect.Width * 1.7;
                        gfx.DrawRectangle(pen, greyBox, safeRect);
                        gfx.DrawString(TextBoxBackingFields.FrontFives.ToString(), smallDenotationFont, XBrushes.Black, safeRect, XStringFormats.Center);
                        safeCashAmountRect = new XRect(safeRect.X + safeRect.Width, safeRect.Y, safeDenomRect.Width, font.Height);
                        safeRect.X += safeRect.Width * 1.4;
                        gfx.DrawRectangle(pen, whiteBox, safeCashAmountRect);
                        gfx.DrawString((TextBoxBackingFields.FrontFives * 40.00).ToString("C"), smallDenotationFont, XBrushes.Black, safeCashAmountRect.X + 2, safeCashAmountRect.Y + 2, XStringFormats.TopLeft);
                        safeRect.X += safeRect.Width * 1.7;
                        gfx.DrawRectangle(pen, greyBox, safeRect);
                        gfx.DrawString(TextBoxBackingFields.BackFives.ToString(), smallDenotationFont, XBrushes.Black, safeRect, XStringFormats.Center);
                        safeCashAmountRect = new XRect(safeRect.X + safeRect.Width, safeRect.Y, safeDenomRect.Width - 7, font.Height);
                        safeRect.X += safeRect.Width * 1.4;
                        gfx.DrawRectangle(pen, whiteBox, safeCashAmountRect);
                        gfx.DrawString((TextBoxBackingFields.BackFives * 40.00).ToString("C"), smallDenotationFont, XBrushes.Black, safeCashAmountRect.X + 2, safeCashAmountRect.Y + 2, XStringFormats.TopLeft);

                        safeYLoc += font.Height;
                        break;
                    case 7:
                        safeRect = new XRect(safeXLoc, safeYLoc, 30, font.Height);
                        safeDenomRect = new XRect(30, safeYLoc, 70, font.Height);
                        safeRect.Y -= safeRect.Height;
                        safeDenomRect.Y -= safeRect.Height;
                        gfx.DrawRectangle(pen, greyBox, safeDenomRect);
                        gfx.DrawString("Tens", smallDenotationFont, XBrushes.Black, safeDenomRect.X + 2, safeDenomRect.Y + 2, XStringFormats.TopLeft);
                        safeRect.X += safeRect.Width * 1.7;
                        gfx.DrawRectangle(pen, greyBox, safeRect);
                        gfx.DrawString(TextBoxBackingFields.FrontTens.ToString(), smallDenotationFont, XBrushes.Black, safeRect, XStringFormats.Center);
                        safeCashAmountRect = new XRect(safeRect.X + safeRect.Width, safeRect.Y, safeDenomRect.Width, font.Height);
                        safeRect.X += safeRect.Width * 1.4;
                        gfx.DrawRectangle(pen, whiteBox, safeCashAmountRect);
                        gfx.DrawString((TextBoxBackingFields.FrontTens * 40.00).ToString("C"), smallDenotationFont, XBrushes.Black, safeCashAmountRect.X + 2, safeCashAmountRect.Y + 2, XStringFormats.TopLeft);
                        safeRect.X += safeRect.Width * 1.7;
                        gfx.DrawRectangle(pen, greyBox, safeRect);
                        gfx.DrawString(TextBoxBackingFields.BackTens.ToString(), smallDenotationFont, XBrushes.Black, safeRect, XStringFormats.Center);
                        safeCashAmountRect = new XRect(safeRect.X + safeRect.Width, safeRect.Y, safeDenomRect.Width - 7, font.Height);
                        safeRect.X += safeRect.Width * 1.4;
                        gfx.DrawRectangle(pen, whiteBox, safeCashAmountRect);
                        gfx.DrawString((TextBoxBackingFields.BackTens * 40.00).ToString("C"), smallDenotationFont, XBrushes.Black, safeCashAmountRect.X + 2, safeCashAmountRect.Y + 2, XStringFormats.TopLeft);

                        safeYLoc += font.Height;
                        break;
                    case 8:
                        safeRect = new XRect(safeXLoc, safeYLoc, 30, font.Height);
                        safeDenomRect = new XRect(30, safeYLoc, 70, font.Height);
                        safeRect.Y -= safeRect.Height;
                        safeDenomRect.Y -= safeRect.Height;
                        gfx.DrawRectangle(pen, greyBox, safeDenomRect);
                        gfx.DrawString("Twenties", smallDenotationFont, XBrushes.Black, safeDenomRect.X + 2, safeDenomRect.Y + 2, XStringFormats.TopLeft);
                        safeRect.X += safeRect.Width * 1.7;
                        gfx.DrawRectangle(pen, greyBox, safeRect);
                        gfx.DrawString(TextBoxBackingFields.FrontTwenties.ToString(), smallDenotationFont, XBrushes.Black, safeRect, XStringFormats.Center);
                        safeCashAmountRect = new XRect(safeRect.X + safeRect.Width, safeRect.Y, safeDenomRect.Width, font.Height);
                        safeRect.X += safeRect.Width * 1.4;
                        gfx.DrawRectangle(pen, whiteBox, safeCashAmountRect);
                        gfx.DrawString((TextBoxBackingFields.FrontTwenties * 100.00).ToString("C"), smallDenotationFont, XBrushes.Black, safeCashAmountRect.X + 2, safeCashAmountRect.Y + 2, XStringFormats.TopLeft);
                        safeRect.X += safeRect.Width * 1.7;
                        gfx.DrawRectangle(pen, greyBox, safeRect);
                        gfx.DrawString(TextBoxBackingFields.BackTwenties.ToString(), smallDenotationFont, XBrushes.Black, safeRect, XStringFormats.Center);
                        safeCashAmountRect = new XRect(safeRect.X + safeRect.Width, safeRect.Y, safeDenomRect.Width - 7, font.Height);
                        safeRect.X += safeRect.Width * 1.4;
                        gfx.DrawRectangle(pen, whiteBox, safeCashAmountRect);
                        gfx.DrawString((TextBoxBackingFields.BackTwenties * 100.00).ToString("C"), smallDenotationFont, XBrushes.Black, safeCashAmountRect.X + 2, safeCashAmountRect.Y + 2, XStringFormats.TopLeft);

                        safeCashAmountRect.Y += safeCashAmountRect.Height;
                        safeYLoc += font.Height;
                        break;
                    case 9:
                        safeRect = new XRect(safeXLoc + 66, safeYLoc, 30, font.Height);
                        safeCashAmountRect.X = middleRectXCoord;
                        safeCashAmountRect.Width += 30;
                        gfx.DrawRectangle(pen, greyBox, safeCashAmountRect);
                        gfx.DrawString("Cashier Change", smallDenotationFont, XBrushes.Black, safeCashAmountRect, XStringFormats.Center);
                        safeCashAmountRect.Width -= 30;
                        safeCashAmountRect.X += safeCashAmountRect.Width + 30;
                        safeRect.X += safeRect.Width * 4;
                        gfx.DrawRectangle(pen, whiteBox, safeCashAmountRect);
                        gfx.DrawString(TextBoxBackingFields.ChangeTotal.ToString("C"), smallDenotationFont, XBrushes.Black, safeCashAmountRect.X + 2, safeCashAmountRect.Y + 2, XStringFormats.TopLeft);

                        safeCashAmountRect.Y += safeCashAmountRect.Height;
                        safeYLoc += font.Height;
                        break;
                    case 10:
                        safeRect = new XRect(safeXLoc + 66, safeYLoc, 30, font.Height);
                        safeCashAmountRect.X = middleRectXCoord;
                        safeCashAmountRect.Width += 30;
                        gfx.DrawRectangle(pen, greyBox, safeCashAmountRect);
                        gfx.DrawString("Office Safe", smallDenotationFont, XBrushes.Black, safeCashAmountRect, XStringFormats.Center);
                        safeCashAmountRect.Width -= 30;
                        safeCashAmountRect.X += safeCashAmountRect.Width + 30;
                        safeRect.X += safeRect.Width * 4;
                        gfx.DrawRectangle(pen, whiteBox, safeCashAmountRect);
                        gfx.DrawString(TextBoxBackingFields.OfficeSafe.ToString("C"), smallDenotationFont, XBrushes.Black, safeCashAmountRect.X + 2, safeCashAmountRect.Y + 2, XStringFormats.TopLeft);

                        safeCashAmountRect.Y += safeCashAmountRect.Height;
                        safeYLoc += font.Height;
                        break;
                    case 11:
                        safeRect = new XRect(safeXLoc + 66, safeYLoc, 30, font.Height);
                        safeCashAmountRect.X = middleRectXCoord;
                        safeCashAmountRect.Width += 30;
                        gfx.DrawRectangle(pen, greyBox, safeCashAmountRect);
                        gfx.DrawString("Gas Drawer", smallDenotationFont, XBrushes.Black, safeCashAmountRect, XStringFormats.Center);
                        safeCashAmountRect.Width -= 30;
                        safeCashAmountRect.X += safeCashAmountRect.Width + 30;
                        safeRect.X += safeRect.Width * 4;
                        gfx.DrawRectangle(pen, whiteBox, safeCashAmountRect);
                        gfx.DrawString(TextBoxBackingFields.GasDrawer.ToString("C"), smallDenotationFont, XBrushes.Black, safeCashAmountRect.X + 2, safeCashAmountRect.Y + 2, XStringFormats.TopLeft);

                        safeCashAmountRect.Y += safeCashAmountRect.Height;
                        safeYLoc += font.Height;
                        break;
                    case 12:
                        safeRect = new XRect(safeXLoc + 66, safeYLoc, 30, font.Height);
                        safeCashAmountRect.X = middleRectXCoord;
                        safeCashAmountRect.Width += 30;
                        gfx.DrawRectangle(pen, greyBox, safeCashAmountRect);
                        gfx.DrawString("Diesel Drawer", smallDenotationFont, XBrushes.Black, safeCashAmountRect, XStringFormats.Center);
                        safeCashAmountRect.Width -= 30;
                        safeCashAmountRect.X += safeCashAmountRect.Width + 30;
                        safeRect.X += safeRect.Width * 4;
                        gfx.DrawRectangle(pen, whiteBox, safeCashAmountRect);
                        gfx.DrawString(TextBoxBackingFields.DieselDrawer.ToString("C"), smallDenotationFont, XBrushes.Black, safeCashAmountRect.X + 2, safeCashAmountRect.Y + 2, XStringFormats.TopLeft);

                        safeCashAmountRect.Y += safeCashAmountRect.Height;
                        safeYLoc += font.Height;
                        break;
                    case 13:
                        safeRect = new XRect(safeXLoc + 66, safeYLoc, 30, font.Height);
                        safeCashAmountRect.X = middleRectXCoord;
                        safeCashAmountRect.Width += 30;
                        gfx.DrawRectangle(pen, greyBox, safeCashAmountRect);
                        gfx.DrawString("Safe Total", smallDenotationFont, XBrushes.Black, safeCashAmountRect, XStringFormats.Center);
                        safeCashAmountRect.Width -= 30;
                        safeCashAmountRect.X += safeCashAmountRect.Width + 30;
                        safeRect.X += safeRect.Width * 4;
                        gfx.DrawRectangle(pen, whiteBox, safeCashAmountRect);
                        gfx.DrawString(TextBoxBackingFields.TotalSafe.ToString("C"), smallDenotationFont, XBrushes.Black, safeCashAmountRect.X + 2, safeCashAmountRect.Y + 2, XStringFormats.TopLeft);

                        safeCashAmountRect.Y += safeCashAmountRect.Height;
                        safeYLoc += font.Height;
                        safeBorderBottomRight = new XPoint(safeBorderTopRight.X, safeCashAmountRect.Y);
                        safeBorderBottomLeft.Y = safeBorderBottomRight.Y;
                        safeBorderBottomLeft.X = 30;
                        
                        break;
                }
            }
            gfx.DrawLine(pen,safeBorderTopRight, safeBorderBottomRight);
            gfx.DrawLine(pen, safeBorderTopRight, safeBorderTopLeft);
            gfx.DrawLine(pen, safeBorderBottomLeft, safeBorderBottomRight);
            gfx.DrawLine(pen, safeBorderBottomLeft, safeBorderTopLeft);

            gfx.DrawString("Lottery Totals", boldFont, XBrushes.Black, lottoStartingCoords);
            gfx.DrawLine(pen, lottoStartingCoords.X, lottoStartingCoords.Y + 2, lottoStartingCoords.X + cashierRect.Width * 1.5, lottoStartingCoords.Y + 2);

            gfx.DrawString("Cigarettes", boldFont, XBrushes.Black, cashierChangeRect.X, lottoStartingCoords.Y);
            gfx.DrawLine(pen, cashierChangeRect.X, lottoStartingCoords.Y + 2, cashierDropsRect.X + cashierDropsRect.Width,lottoStartingCoords.Y + 2);

            lottoStartingCoords.Y += 10;
            XRect lottoRect = new XRect(lottoStartingCoords.X, lottoStartingCoords.Y, cashierRect.Width, font.Height);
            XRect cigRect = new XRect(cashierChangeRect.X, lottoStartingCoords.Y, cashierChangeRect.Width, cashierChangeRect.Height);

            for(int i = 0; i < 2; i++)
            {
                switch(i)
                {
                    case 0:
                        gfx.DrawRectangle(pen, greyBox, lottoRect);
                        gfx.DrawString("Online Sales", smallDenotationFont, XBrushes.Black, lottoRect.X + 2, lottoRect.Y + 2, XStringFormats.TopLeft);
                        lottoRect.X += lottoRect.Width;
                        lottoRect.Width /= 2;
                        gfx.DrawRectangle(pen, whiteBox, lottoRect);
                        gfx.DrawString(TextBoxBackingFields.OnlineSales.ToString("C"), smallDenotationFont, XBrushes.Black, lottoRect.X + 2, lottoRect.Y + 2, XStringFormats.TopLeft);
                        lottoRect.Width *= 2;
                        lottoRect.Y += lottoRect.Height;
                        lottoRect.X -= lottoRect.Width;
                        gfx.DrawRectangle(pen, greyBox, lottoRect);
                        gfx.DrawString("Instant Sales", smallDenotationFont, XBrushes.Black, lottoRect.X + 2, lottoRect.Y + 2, XStringFormats.TopLeft);
                        lottoRect.X += lottoRect.Width;
                        lottoRect.Width /= 2;
                        gfx.DrawRectangle(pen, whiteBox, lottoRect);
                        gfx.DrawString(TextBoxBackingFields.InstantSales.ToString("C"), smallDenotationFont, XBrushes.Black, lottoRect.X + 2, lottoRect.Y + 2, XStringFormats.TopLeft);
                        lottoRect.Width *= 2;
                        lottoRect.X = lottoStartingCoords.X;
                        lottoRect.Y += lottoRect.Height * 2;
                        break;
                    case 1:
                        gfx.DrawRectangle(pen, greyBox, lottoRect);
                        gfx.DrawString("Online Payouts", smallDenotationFont, XBrushes.Black, lottoRect.X + 2, lottoRect.Y + 2, XStringFormats.TopLeft);
                        lottoRect.X += lottoRect.Width;
                        lottoRect.Width /= 2;
                        gfx.DrawRectangle(pen, whiteBox, lottoRect);
                        gfx.DrawString(TextBoxBackingFields.OnlinePaidOut.ToString("C"), smallDenotationFont, XBrushes.Black, lottoRect.X + 2, lottoRect.Y + 2, XStringFormats.TopLeft);
                        lottoRect.Width *= 2;
                        lottoRect.Y += lottoRect.Height;
                        lottoRect.X -= lottoRect.Width;
                        gfx.DrawRectangle(pen, greyBox, lottoRect);
                        gfx.DrawString("Instant Payouts", smallDenotationFont, XBrushes.Black, lottoRect.X + 2, lottoRect.Y + 2, XStringFormats.TopLeft);
                        lottoRect.X += lottoRect.Width;
                        lottoRect.Width /= 2;
                        gfx.DrawRectangle(pen, whiteBox, lottoRect);
                        gfx.DrawString(TextBoxBackingFields.InstantPaidOut.ToString("C"), smallDenotationFont, XBrushes.Black, lottoRect.X + 2, lottoRect.Y + 2, XStringFormats.TopLeft);
                        break;
                }
            }

            for(int i = 0; i < 5; i++)
            {
                switch(i)
                {
                    case 0:
                        gfx.DrawRectangle(pen, greyBox, cigRect);
                        gfx.DrawString("Office", smallDenotationFont, XBrushes.Black, cigRect.X + 2, cigRect.Y + 2, XStringFormats.TopLeft);
                        cigRect.X += cigRect.Width;
                        gfx.DrawRectangle(pen, whiteBox, cigRect);
                        gfx.DrawString(TextBoxBackingFields.OfficeCigs.ToString(), smallDenotationFont, XBrushes.Black, cigRect.X + 2, cigRect.Y + 2, XStringFormats.TopLeft);
                        cigRect.Y += cigRect.Height;
                        cigRect.X -= cigRect.Width;
                        break;
                    case 1:
                        gfx.DrawRectangle(pen, greyBox, cigRect);
                        gfx.DrawString("Gas", smallDenotationFont, XBrushes.Black, cigRect.X + 2, cigRect.Y + 2, XStringFormats.TopLeft);
                        cigRect.X += cigRect.Width;
                        gfx.DrawRectangle(pen, whiteBox, cigRect);
                        gfx.DrawString(TextBoxBackingFields.GasCigs.ToString(), smallDenotationFont, XBrushes.Black, cigRect.X + 2, cigRect.Y + 2, XStringFormats.TopLeft);
                        cigRect.Y += cigRect.Height;
                        cigRect.X -= cigRect.Width;
                        break;
                    case 2:
                        gfx.DrawRectangle(pen, greyBox, cigRect);
                        gfx.DrawString("Diesel", smallDenotationFont, XBrushes.Black, cigRect.X + 2, cigRect.Y + 2, XStringFormats.TopLeft);
                        cigRect.X += cigRect.Width;
                        gfx.DrawRectangle(pen, whiteBox, cigRect);
                        gfx.DrawString(TextBoxBackingFields.DieselCigs.ToString(), smallDenotationFont, XBrushes.Black, cigRect.X + 2, cigRect.Y + 2, XStringFormats.TopLeft);
                        cigRect.Y += cigRect.Height;
                        cigRect.X -= cigRect.Width;
                        break;
                    case 3:
                        gfx.DrawRectangle(pen, greyBox, cigRect);
                        gfx.DrawString("McLane", smallDenotationFont, XBrushes.Black, cigRect.X + 2, cigRect.Y + 2, XStringFormats.TopLeft);
                        cigRect.X += cigRect.Width;
                        gfx.DrawRectangle(pen, whiteBox, cigRect);
                        gfx.DrawString(TextBoxBackingFields.MclaneCigs.ToString(), smallDenotationFont, XBrushes.Black, cigRect.X + 2, cigRect.Y + 2, XStringFormats.TopLeft);
                        cigRect.Y += cigRect.Height;
                        cigRect.X -= cigRect.Width;
                        break;
                    case 4:
                        gfx.DrawRectangle(pen, greyBox, cigRect);
                        gfx.DrawString("Total", smallDenotationFont, XBrushes.Black, cigRect.X + 2, cigRect.Y + 2, XStringFormats.TopLeft);
                        cigRect.X += cigRect.Width;
                        gfx.DrawRectangle(pen, whiteBox, cigRect);
                        gfx.DrawString(TextBoxBackingFields.TotalCigs.ToString(), smallDenotationFont, XBrushes.Black, cigRect.X + 2, cigRect.Y + 2, XStringFormats.TopLeft);
                        cigRect.Y += cigRect.Height * 2;
                        break;
                }
            }

            double miscRectLength = lottoStartingCoords.X + cigRect.X - lottoStartingCoords.X;
            miscRectLength /= 4;

            XRect miscRect = new XRect(lottoStartingCoords.X, cigRect.Y + font.Height, miscRectLength, font.Height);
            
            gfx.DrawString("Miscellaneous", boldFont, XBrushes.Black, miscRect.X, miscRect.Y);
            gfx.DrawLine(pen, miscRect.X, miscRect.Y + 2, cigRect.X + cigRect.Width, miscRect.Y + 2);

            miscRect.Y += 10;

            for(int i = 0; i < 3; i++)
            {
                switch(i)
                {
                    case 0:
                        gfx.DrawRectangle(pen, greyBox, miscRect);
                        gfx.DrawString("Ambest Redemption", smallDenotationFont, XBrushes.Black, miscRect.X + 2, miscRect.Y + 2, XStringFormats.TopLeft);
                        miscRect.X += miscRect.Width;
                        gfx.DrawRectangle(pen, whiteBox, miscRect);
                        gfx.DrawString(TextBoxBackingFields.AmbestRedeem.ToString("C"), smallDenotationFont, XBrushes.Black, miscRect.X + 2, miscRect.Y + 2, XStringFormats.TopLeft);
                        miscRect.X -= miscRect.Width;
                        miscRect.Y += font.Height;
                        gfx.DrawRectangle(pen, greyBox, miscRect);
                        gfx.DrawString("Store Paid Out", smallDenotationFont, XBrushes.Black, miscRect.X + 2, miscRect.Y + 2, XStringFormats.TopLeft);
                        miscRect.X += miscRect.Width;
                        gfx.DrawRectangle(pen, whiteBox, miscRect);
                        gfx.DrawString(TextBoxBackingFields.StorePaidOut.ToString("C"), smallDenotationFont, XBrushes.Black, miscRect.X + 2, miscRect.Y + 2, XStringFormats.TopLeft);
                        miscRect.X -= miscRect.Width;
                        miscRect.Y += font.Height;
                        break;
                    case 1:
                        gfx.DrawRectangle(pen, greyBox, miscRect);
                        gfx.DrawString("Coupons", smallDenotationFont, XBrushes.Black, miscRect.X + 2, miscRect.Y + 2, XStringFormats.TopLeft);
                        
                        miscRect.X += miscRect.Width;
                        gfx.DrawRectangle(pen, whiteBox, miscRect);
                        gfx.DrawString(TextBoxBackingFields.Coupons.ToString("C"), smallDenotationFont, XBrushes.Black, miscRect.X + 2, miscRect.Y + 2, XStringFormats.TopLeft);
                        miscRect.X -= miscRect.Width;
                        miscRect.Y += font.Height;
                        gfx.DrawRectangle(pen, greyBox, miscRect);
                        gfx.DrawString("Incentive", smallDenotationFont, XBrushes.Black, miscRect.X + 2, miscRect.Y + 2, XStringFormats.TopLeft);
                        
                        miscRect.X += miscRect.Width;
                        gfx.DrawRectangle(pen, whiteBox, miscRect);
                        gfx.DrawString(TextBoxBackingFields.Incentive.ToString("C"), smallDenotationFont, XBrushes.Black, miscRect.X + 2, miscRect.Y + 2, XStringFormats.TopLeft);
                        miscRect.Y += font.Height;
                        miscRect.X -= miscRect.Width;
                        break;
                    case 2:
                        gfx.DrawRectangle(pen, greyBox, miscRect);
                        gfx.DrawString("Reimbursement", smallDenotationFont, XBrushes.Black, miscRect.X + 2, miscRect.Y + 2, XStringFormats.TopLeft);

                        miscRect.X += miscRect.Width;
                        gfx.DrawRectangle(pen, whiteBox, miscRect);
                        gfx.DrawString(TextBoxBackingFields.Reimbursement.ToString("C"), smallDenotationFont, XBrushes.Black, miscRect.X + 2, miscRect.Y + 2, XStringFormats.TopLeft);
                        miscRect.X -= miscRect.Width;
                        miscRect.Y += font.Height;
                        gfx.DrawRectangle(pen, greyBox, miscRect);
                        gfx.DrawString("Overrun", smallDenotationFont, XBrushes.Black, miscRect.X + 2, miscRect.Y + 2, XStringFormats.TopLeft);

                        miscRect.X += miscRect.Width;
                        gfx.DrawRectangle(pen, whiteBox, miscRect);
                        gfx.DrawString(TextBoxBackingFields.Overrun.ToString("C"), smallDenotationFont, XBrushes.Black, miscRect.X + 2, miscRect.Y + 2, XStringFormats.TopLeft);
                        miscRect.Y += font.Height * 3;
                        miscRect.X -= miscRect.Width;
                        break;
                }
            }

            XRect testRect = miscRect;
            XRect pumptestRect = miscRect;
            int pumpTests = 0;
            testRect.Y += 10;
            pumptestRect.Y += 10;
            pumptestRect.Y += pumptestRect.Height;

            for(int i = 0; i < 6; i++)
            {
                switch(i)
                {
                    case 0:
                        if (TextBoxBackingFields.UnleadedEthanolDollars != null && TextBoxBackingFields.UnleadedEthanolUnits != null)
                        {
                            pumpTests++;
                            gfx.DrawRectangle(pen, greyBox, pumptestRect);
                            gfx.DrawString("Unleaded Ethanol", smallDenotationFont, XBrushes.Black, pumptestRect.X + 2, pumptestRect.Y + 2, XStringFormats.TopLeft);
                            pumptestRect.X += pumptestRect.Width;
                            pumptestRect.Width = pumptestRect.Width / 2;
                            gfx.DrawRectangle(pen, whiteBox, pumptestRect);
                            gfx.DrawString(TextBoxBackingFields.UnleadedEthanolDollars, smallDenotationFont, XBrushes.Black, pumptestRect.X + 2, pumptestRect.Y + 2, XStringFormats.TopLeft);
                            pumptestRect.X += pumptestRect.Width;
                            gfx.DrawRectangle(pen, whiteBox, pumptestRect);
                            gfx.DrawString(TextBoxBackingFields.UnleadedEthanolUnits, smallDenotationFont, XBrushes.Black, pumptestRect.X + 2, pumptestRect.Y + 2, XStringFormats.TopLeft);
                            pumptestRect.Y += pumptestRect.Height;
                            pumptestRect.X -= pumptestRect.Width * 3;
                            pumptestRect.Width *= 2;
                        }
                        break;
                    case 1:
                        if (TextBoxBackingFields.MidgradeEthanolDollars != null && TextBoxBackingFields.MidgradeEthanolUnits != null)
                        {
                            pumpTests++;
                            gfx.DrawRectangle(pen, greyBox, pumptestRect);
                            gfx.DrawString("Midgrade Ethanol Blend", smallDenotationFont, XBrushes.Black, pumptestRect.X + 2, pumptestRect.Y + 2, XStringFormats.TopLeft);
                            pumptestRect.X += pumptestRect.Width;
                            pumptestRect.Width = pumptestRect.Width / 2;
                            gfx.DrawRectangle(pen, whiteBox, pumptestRect);
                            gfx.DrawString(TextBoxBackingFields.MidgradeEthanolDollars, smallDenotationFont, XBrushes.Black, pumptestRect.X + 2, pumptestRect.Y + 2, XStringFormats.TopLeft);
                            pumptestRect.X += pumptestRect.Width;
                            gfx.DrawRectangle(pen, whiteBox, pumptestRect);
                            gfx.DrawString(TextBoxBackingFields.MidgradeEthanolUnits, smallDenotationFont, XBrushes.Black, pumptestRect.X + 2, pumptestRect.Y + 2, XStringFormats.TopLeft);
                            pumptestRect.Y += pumptestRect.Height;
                            pumptestRect.X -= pumptestRect.Width * 3;
                            pumptestRect.Width *= 2;
                        }
                        break;
                    case 2:
                        if (TextBoxBackingFields.PremiumEthanolDollars != null && TextBoxBackingFields.PremiumEthanolUnits != null)
                        {
                            pumpTests++;
                            gfx.DrawRectangle(pen, greyBox, pumptestRect);
                            gfx.DrawString("Premium Ethanol Blend", smallDenotationFont, XBrushes.Black, pumptestRect.X + 2, pumptestRect.Y + 2, XStringFormats.TopLeft);
                            pumptestRect.X += pumptestRect.Width;
                            pumptestRect.Width = pumptestRect.Width / 2;
                            gfx.DrawRectangle(pen, whiteBox, pumptestRect);
                            gfx.DrawString(TextBoxBackingFields.PremiumEthanolDollars, smallDenotationFont, XBrushes.Black, pumptestRect.X + 2, pumptestRect.Y + 2, XStringFormats.TopLeft);
                            pumptestRect.X += pumptestRect.Width;
                            gfx.DrawRectangle(pen, whiteBox, pumptestRect);
                            gfx.DrawString(TextBoxBackingFields.PremiumEthanolUnits, smallDenotationFont, XBrushes.Black, pumptestRect.X + 2, pumptestRect.Y + 2, XStringFormats.TopLeft);
                            pumptestRect.Y += pumptestRect.Height;
                            pumptestRect.X -= pumptestRect.Width * 3;
                            pumptestRect.Width *= 2;
                        }
                        break;
                    case 3:
                        if (TextBoxBackingFields.UltraDollars != null && TextBoxBackingFields.UltraUnits != null)
                        {
                            pumpTests++;
                            gfx.DrawRectangle(pen, greyBox, pumptestRect);
                            gfx.DrawString("Ultra", smallDenotationFont, XBrushes.Black, pumptestRect.X + 2, pumptestRect.Y + 2, XStringFormats.TopLeft);
                            pumptestRect.X += pumptestRect.Width;
                            pumptestRect.Width = pumptestRect.Width / 2;
                            gfx.DrawRectangle(pen, whiteBox, pumptestRect);
                            gfx.DrawString(TextBoxBackingFields.UltraDollars, smallDenotationFont, XBrushes.Black, pumptestRect.X + 2, pumptestRect.Y + 2, XStringFormats.TopLeft);
                            pumptestRect.X += pumptestRect.Width;
                            gfx.DrawRectangle(pen, whiteBox, pumptestRect);
                            gfx.DrawString(TextBoxBackingFields.UltraUnits, smallDenotationFont, XBrushes.Black, pumptestRect.X + 2, pumptestRect.Y + 2, XStringFormats.TopLeft);
                            pumptestRect.Y += pumptestRect.Height;
                            pumptestRect.X -= pumptestRect.Width * 3;
                            pumptestRect.Width *= 2;
                        }
                        break;
                    case 4:
                        if (TextBoxBackingFields.DieselDollars != null && TextBoxBackingFields.DieselUnits != null)
                        {
                            pumpTests++;
                            gfx.DrawRectangle(pen, greyBox, pumptestRect);
                            gfx.DrawString("Diesel", smallDenotationFont, XBrushes.Black, pumptestRect.X + 2, pumptestRect.Y + 2, XStringFormats.TopLeft);
                            pumptestRect.X += pumptestRect.Width;
                            pumptestRect.Width = pumptestRect.Width / 2;
                            gfx.DrawRectangle(pen, whiteBox, pumptestRect);
                            gfx.DrawString(TextBoxBackingFields.DieselDollars, smallDenotationFont, XBrushes.Black, pumptestRect.X + 2, pumptestRect.Y + 2, XStringFormats.TopLeft);
                            pumptestRect.X += pumptestRect.Width;
                            gfx.DrawRectangle(pen, whiteBox, pumptestRect);
                            gfx.DrawString(TextBoxBackingFields.DieselUnits, smallDenotationFont, XBrushes.Black, pumptestRect.X + 2, pumptestRect.Y + 2, XStringFormats.TopLeft);
                            pumptestRect.Y += pumptestRect.Height;
                            pumptestRect.X -= pumptestRect.Width * 3;
                            pumptestRect.Width *= 2;
                        }
                        break;
                    case 5:
                        if (TextBoxBackingFields.DefDollars != null && TextBoxBackingFields.DefUnits != null)
                        {
                            pumpTests++;
                            gfx.DrawRectangle(pen, greyBox, pumptestRect);
                            gfx.DrawString("DEF", smallDenotationFont, XBrushes.Black, pumptestRect.X + 2, pumptestRect.Y + 2, XStringFormats.TopLeft);
                            pumptestRect.X += pumptestRect.Width;
                            pumptestRect.Width = pumptestRect.Width / 2;
                            gfx.DrawRectangle(pen, whiteBox, pumptestRect);
                            gfx.DrawString(TextBoxBackingFields.DefDollars, smallDenotationFont, XBrushes.Black, pumptestRect.X + 2, pumptestRect.Y + 2, XStringFormats.TopLeft);
                            pumptestRect.X += pumptestRect.Width;
                            gfx.DrawRectangle(pen, whiteBox, pumptestRect);
                            gfx.DrawString(TextBoxBackingFields.DefUnits, smallDenotationFont, XBrushes.Black, pumptestRect.X + 2, pumptestRect.Y + 2, XStringFormats.TopLeft);
                            pumptestRect.Y += pumptestRect.Height;
                            pumptestRect.X -= pumptestRect.Width * 3;
                            pumptestRect.Width *= 2;
                        }
                        break;
                }
            }

            if (pumpTests > 0)
            {
                gfx.DrawString("Pump Tests", boldFont, XBrushes.Black, miscRect.X, miscRect.Y);
                gfx.DrawLine(pen, miscRect.X, miscRect.Y + 2, cigRect.X + cigRect.Width, miscRect.Y + 2);

                gfx.DrawRectangle(pen, greyBox, testRect);
                gfx.DrawString("Fuel Type", smallDenotationFont, XBrushes.Black, testRect.X + 2, testRect.Y + 2, XStringFormats.TopLeft);
                testRect.X += testRect.Width;
                testRect.Width = testRect.Width / 2;
                gfx.DrawRectangle(pen, greyBox, testRect);
                gfx.DrawString("Dollars", smallDenotationFont, XBrushes.Black, testRect.X + 2, testRect.Y + 2, XStringFormats.TopLeft);
                testRect.X += testRect.Width;
                gfx.DrawRectangle(pen, greyBox, testRect);
                gfx.DrawString("Units", smallDenotationFont, XBrushes.Black, testRect.X + 2, testRect.Y + 2, XStringFormats.TopLeft);
            }

            double fuelRectWidth = (safeBorderBottomLeft.X + safeBorderBottomRight.X) - safeBorderBottomLeft.X;
            fuelRectWidth = fuelRectWidth / 4 - 7.5;
            XRect fuelRect = new XRect(safeBorderBottomLeft.X, safeBorderBottomLeft.Y + font.Height * 2 + 10, fuelRectWidth, font.Height);

            int fuelDelivCount = 0;

            for(int i = 0; i < 8; i++)
            {
                switch (i)
                {
                    case 0:
                        if(TextBoxBackingFields.FuelType1 != "<choose fuel type>" && TextBoxBackingFields.FuelType1 != null)
                        {
                            fuelDelivCount++;
                            if (fuelDelivCount == 1)
                            {
                                gfx.DrawRectangle(pen, greyBox, fuelRect);
                                gfx.DrawString("Fuel Type", smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                                fuelRect.X += fuelRect.Width;
                                gfx.DrawRectangle(pen, greyBox, fuelRect);
                                gfx.DrawString("Bill of Lading", smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                                fuelRect.X += fuelRect.Width;
                                gfx.DrawRectangle(pen, greyBox, fuelRect);
                                gfx.DrawString("Net Fuel", smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                                fuelRect.X += fuelRect.Width;
                                gfx.DrawRectangle(pen, greyBox, fuelRect);
                                gfx.DrawString("Gross Fuel", smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                                fuelRect.X -= fuelRect.Width * 3;
                                fuelRect.Y += font.Height;
                            }
                            gfx.DrawRectangle(pen, greyBox, fuelRect);
                            gfx.DrawString(TextBoxBackingFields.FuelType1, smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                            fuelRect.X += fuelRect.Width;
                            gfx.DrawRectangle(pen, whiteBox, fuelRect);
                            gfx.DrawString(TextBoxBackingFields.BillOfLading1, smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                            fuelRect.X += fuelRect.Width;
                            gfx.DrawRectangle(pen, whiteBox, fuelRect);
                            gfx.DrawString(TextBoxBackingFields.NetFuel1, smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                            fuelRect.X += fuelRect.Width;
                            gfx.DrawRectangle(pen, whiteBox, fuelRect);
                            gfx.DrawString(TextBoxBackingFields.GrossFuel1, smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                            fuelRect.X -= fuelRect.Width * 3;
                            fuelRect.Y += font.Height;
                        }
                        break;
                    case 1:
                        if (TextBoxBackingFields.FuelType2 != "<choose fuel type>" && TextBoxBackingFields.FuelType2 != null)
                        {
                            fuelDelivCount++;
                            if (fuelDelivCount == 1)
                            {
                                gfx.DrawRectangle(pen, greyBox, fuelRect);
                                gfx.DrawString("Fuel Type", smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                                fuelRect.X += fuelRect.Width;
                                gfx.DrawRectangle(pen, greyBox, fuelRect);
                                gfx.DrawString("Bill of Lading", smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                                fuelRect.X += fuelRect.Width;
                                gfx.DrawRectangle(pen, greyBox, fuelRect);
                                gfx.DrawString("Net Fuel", smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                                fuelRect.X += fuelRect.Width;
                                gfx.DrawRectangle(pen, greyBox, fuelRect);
                                gfx.DrawString("Gross Fuel", smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                                fuelRect.X -= fuelRect.Width * 3;
                                fuelRect.Y += font.Height;
                            }
                            gfx.DrawRectangle(pen, greyBox, fuelRect);
                            gfx.DrawString(TextBoxBackingFields.FuelType2, smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                            fuelRect.X += fuelRect.Width;
                            gfx.DrawRectangle(pen, whiteBox, fuelRect);
                            gfx.DrawString(TextBoxBackingFields.BillOfLading2, smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                            fuelRect.X += fuelRect.Width;
                            gfx.DrawRectangle(pen, whiteBox, fuelRect);
                            gfx.DrawString(TextBoxBackingFields.NetFuel2, smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                            fuelRect.X += fuelRect.Width;
                            gfx.DrawRectangle(pen, whiteBox, fuelRect);
                            gfx.DrawString(TextBoxBackingFields.GrossFuel2, smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                            fuelRect.X -= fuelRect.Width * 3;
                            fuelRect.Y += font.Height;
                        }
                        break;
                    case 2:
                        if (TextBoxBackingFields.FuelType3 != "<choose fuel type>" && TextBoxBackingFields.FuelType3 != null)
                        {
                            fuelDelivCount++;
                            if (fuelDelivCount == 1)
                            {
                                gfx.DrawRectangle(pen, greyBox, fuelRect);
                                gfx.DrawString("Fuel Type", smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                                fuelRect.X += fuelRect.Width;
                                gfx.DrawRectangle(pen, greyBox, fuelRect);
                                gfx.DrawString("Bill of Lading", smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                                fuelRect.X += fuelRect.Width;
                                gfx.DrawRectangle(pen, greyBox, fuelRect);
                                gfx.DrawString("Net Fuel", smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                                fuelRect.X += fuelRect.Width;
                                gfx.DrawRectangle(pen, greyBox, fuelRect);
                                gfx.DrawString("Gross Fuel", smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                                fuelRect.X -= fuelRect.Width * 3;
                                fuelRect.Y += font.Height;
                            }
                            gfx.DrawRectangle(pen, greyBox, fuelRect);
                            gfx.DrawString(TextBoxBackingFields.FuelType3, smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                            fuelRect.X += fuelRect.Width;
                            gfx.DrawRectangle(pen, whiteBox, fuelRect);
                            gfx.DrawString(TextBoxBackingFields.BillOfLading3, smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                            fuelRect.X += fuelRect.Width;
                            gfx.DrawRectangle(pen, whiteBox, fuelRect);
                            gfx.DrawString(TextBoxBackingFields.NetFuel3, smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                            fuelRect.X += fuelRect.Width;
                            gfx.DrawRectangle(pen, whiteBox, fuelRect);
                            gfx.DrawString(TextBoxBackingFields.GrossFuel3, smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                            fuelRect.X -= fuelRect.Width * 3;
                            fuelRect.Y += font.Height;
                        }
                        break;
                    case 3:
                        if (TextBoxBackingFields.FuelType4 != "<choose fuel type>" && TextBoxBackingFields.FuelType4 != null)
                        {
                            fuelDelivCount++;
                            if (fuelDelivCount == 1)
                            {
                                gfx.DrawRectangle(pen, greyBox, fuelRect);
                                gfx.DrawString("Fuel Type", smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                                fuelRect.X += fuelRect.Width;
                                gfx.DrawRectangle(pen, greyBox, fuelRect);
                                gfx.DrawString("Bill of Lading", smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                                fuelRect.X += fuelRect.Width;
                                gfx.DrawRectangle(pen, greyBox, fuelRect);
                                gfx.DrawString("Net Fuel", smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                                fuelRect.X += fuelRect.Width;
                                gfx.DrawRectangle(pen, greyBox, fuelRect);
                                gfx.DrawString("Gross Fuel", smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                                fuelRect.X -= fuelRect.Width * 3;
                                fuelRect.Y += font.Height;
                            }
                            gfx.DrawRectangle(pen, greyBox, fuelRect);
                            gfx.DrawString(TextBoxBackingFields.FuelType4, smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                            fuelRect.X += fuelRect.Width;
                            gfx.DrawRectangle(pen, whiteBox, fuelRect);
                            gfx.DrawString(TextBoxBackingFields.BillOfLading4, smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                            fuelRect.X += fuelRect.Width;
                            gfx.DrawRectangle(pen, whiteBox, fuelRect);
                            gfx.DrawString(TextBoxBackingFields.NetFuel4, smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                            fuelRect.X += fuelRect.Width;
                            gfx.DrawRectangle(pen, whiteBox, fuelRect);
                            gfx.DrawString(TextBoxBackingFields.GrossFuel4, smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                            fuelRect.X -= fuelRect.Width * 3;
                            fuelRect.Y += font.Height;
                        }
                        break;
                    case 4:
                        if (TextBoxBackingFields.FuelType5 != "<choose fuel type>" && TextBoxBackingFields.FuelType5 != null)
                        {
                            fuelDelivCount++;
                            if (fuelDelivCount == 1)
                            {
                                gfx.DrawRectangle(pen, greyBox, fuelRect);
                                gfx.DrawString("Fuel Type", smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                                fuelRect.X += fuelRect.Width;
                                gfx.DrawRectangle(pen, greyBox, fuelRect);
                                gfx.DrawString("Bill of Lading", smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                                fuelRect.X += fuelRect.Width;
                                gfx.DrawRectangle(pen, greyBox, fuelRect);
                                gfx.DrawString("Net Fuel", smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                                fuelRect.X += fuelRect.Width;
                                gfx.DrawRectangle(pen, greyBox, fuelRect);
                                gfx.DrawString("Gross Fuel", smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                                fuelRect.X -= fuelRect.Width * 3;
                                fuelRect.Y += font.Height;
                            }
                            gfx.DrawRectangle(pen, greyBox, fuelRect);
                            gfx.DrawString(TextBoxBackingFields.FuelType5, smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                            fuelRect.X += fuelRect.Width;
                            gfx.DrawRectangle(pen, whiteBox, fuelRect);
                            gfx.DrawString(TextBoxBackingFields.BillOfLading5, smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                            fuelRect.X += fuelRect.Width;
                            gfx.DrawRectangle(pen, whiteBox, fuelRect);
                            gfx.DrawString(TextBoxBackingFields.NetFuel5, smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                            fuelRect.X += fuelRect.Width;
                            gfx.DrawRectangle(pen, whiteBox, fuelRect);
                            gfx.DrawString(TextBoxBackingFields.GrossFuel5, smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                            fuelRect.X -= fuelRect.Width * 3;
                            fuelRect.Y += font.Height;
                        }
                        break;
                    case 5:
                        if (TextBoxBackingFields.FuelType6 != "<choose fuel type>" && TextBoxBackingFields.FuelType6 != null)
                        {
                            fuelDelivCount++;
                            if (fuelDelivCount == 1)
                            {
                                gfx.DrawRectangle(pen, greyBox, fuelRect);
                                gfx.DrawString("Fuel Type", smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                                fuelRect.X += fuelRect.Width;
                                gfx.DrawRectangle(pen, greyBox, fuelRect);
                                gfx.DrawString("Bill of Lading", smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                                fuelRect.X += fuelRect.Width;
                                gfx.DrawRectangle(pen, greyBox, fuelRect);
                                gfx.DrawString("Net Fuel", smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                                fuelRect.X += fuelRect.Width;
                                gfx.DrawRectangle(pen, greyBox, fuelRect);
                                gfx.DrawString("Gross Fuel", smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                                fuelRect.X -= fuelRect.Width * 3;
                                fuelRect.Y += font.Height;
                            }
                            gfx.DrawRectangle(pen, greyBox, fuelRect);
                            gfx.DrawString(TextBoxBackingFields.FuelType6, smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                            fuelRect.X += fuelRect.Width;
                            gfx.DrawRectangle(pen, whiteBox, fuelRect);
                            gfx.DrawString(TextBoxBackingFields.BillOfLading6, smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                            fuelRect.X += fuelRect.Width;
                            gfx.DrawRectangle(pen, whiteBox, fuelRect);
                            gfx.DrawString(TextBoxBackingFields.NetFuel6, smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                            fuelRect.X += fuelRect.Width;
                            gfx.DrawRectangle(pen, whiteBox, fuelRect);
                            gfx.DrawString(TextBoxBackingFields.GrossFuel6, smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                            fuelRect.X -= fuelRect.Width * 3;
                            fuelRect.Y += font.Height;
                        }
                        break;
                    case 6:
                        if (TextBoxBackingFields.FuelType7 != "<choose fuel type>" && TextBoxBackingFields.FuelType7 != null)
                        {
                            fuelDelivCount++;
                            if (fuelDelivCount == 1)
                            {
                                gfx.DrawRectangle(pen, greyBox, fuelRect);
                                gfx.DrawString("Fuel Type", smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                                fuelRect.X += fuelRect.Width;
                                gfx.DrawRectangle(pen, greyBox, fuelRect);
                                gfx.DrawString("Bill of Lading", smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                                fuelRect.X += fuelRect.Width;
                                gfx.DrawRectangle(pen, greyBox, fuelRect);
                                gfx.DrawString("Net Fuel", smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                                fuelRect.X += fuelRect.Width;
                                gfx.DrawRectangle(pen, greyBox, fuelRect);
                                gfx.DrawString("Gross Fuel", smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                                fuelRect.X -= fuelRect.Width * 3;
                                fuelRect.Y += font.Height;
                            }
                            gfx.DrawRectangle(pen, greyBox, fuelRect);
                            gfx.DrawString(TextBoxBackingFields.FuelType7, smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                            fuelRect.X += fuelRect.Width;
                            gfx.DrawRectangle(pen, whiteBox, fuelRect);
                            gfx.DrawString(TextBoxBackingFields.BillOfLading7, smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                            fuelRect.X += fuelRect.Width;
                            gfx.DrawRectangle(pen, whiteBox, fuelRect);
                            gfx.DrawString(TextBoxBackingFields.NetFuel7, smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                            fuelRect.X += fuelRect.Width;
                            gfx.DrawRectangle(pen, whiteBox, fuelRect);
                            gfx.DrawString(TextBoxBackingFields.GrossFuel7, smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                            fuelRect.X -= fuelRect.Width * 3;
                            fuelRect.Y += font.Height;
                        }
                        break;
                    case 7:
                        if (TextBoxBackingFields.FuelType8 != "<choose fuel type>" && TextBoxBackingFields.FuelType8 != null)
                        {
                            fuelDelivCount++;
                            if (fuelDelivCount == 1)
                            {
                                gfx.DrawRectangle(pen, greyBox, fuelRect);
                                gfx.DrawString("Fuel Type", smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                                fuelRect.X += fuelRect.Width;
                                gfx.DrawRectangle(pen, greyBox, fuelRect);
                                gfx.DrawString("Bill of Lading", smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                                fuelRect.X += fuelRect.Width;
                                gfx.DrawRectangle(pen, greyBox, fuelRect);
                                gfx.DrawString("Net Fuel", smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                                fuelRect.X += fuelRect.Width;
                                gfx.DrawRectangle(pen, greyBox, fuelRect);
                                gfx.DrawString("Gross Fuel", smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                                fuelRect.X -= fuelRect.Width * 3;
                                fuelRect.Y += font.Height;
                            }
                            gfx.DrawRectangle(pen, greyBox, fuelRect);
                            gfx.DrawString(TextBoxBackingFields.FuelType8, smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                            fuelRect.X += fuelRect.Width;
                            gfx.DrawRectangle(pen, whiteBox, fuelRect);
                            gfx.DrawString(TextBoxBackingFields.BillOfLading8, smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                            fuelRect.X += fuelRect.Width;
                            gfx.DrawRectangle(pen, whiteBox, fuelRect);
                            gfx.DrawString(TextBoxBackingFields.NetFuel8, smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                            fuelRect.X += fuelRect.Width;
                            gfx.DrawRectangle(pen, whiteBox, fuelRect);
                            gfx.DrawString(TextBoxBackingFields.GrossFuel8, smallDenotationFont, XBrushes.Black, fuelRect.X + 2, fuelRect.Y + 2, XStringFormats.TopLeft);
                            fuelRect.X -= fuelRect.Width * 3;
                            fuelRect.Y += font.Height;
                        }
                        break;
                }
            }

            if (fuelDelivCount > 0)
            {
                gfx.DrawString("Fuel Deliveries", boldFont, XBrushes.Black, safeBorderBottomLeft.X, safeBorderBottomLeft.Y + font.Height * 2);
                gfx.DrawLines(pen, safeBorderBottomLeft.X, safeBorderBottomLeft.Y + font.Height * 2 + 2, safeBorderBottomRight.X, safeBorderBottomLeft.Y + font.Height * 2 + 2);
            }

            if (File.Exists(Properties.Settings.Default["RootFilePath"].ToString() + Properties.Settings.Default["ImgFilePath"].ToString() + "7-11-images-3.PNG"))
            {
                double subx = 150;
                double suby = 150;
                XImage image = XImage.FromFile(Properties.Settings.Default["RootFilePath"].ToString() + Properties.Settings.Default["ImgFilePath"].ToString() + "7-11-images-3.PNG");

                gfx.DrawImage(image, Convert.ToInt32(pageWidth - subx), Convert.ToInt32(pageHeight - suby));
            }
            

            Stream documentStream = new FileStream(Properties.Settings.Default["RootFilePath"].ToString() + Properties.Settings.Default["PdfFilePath"].ToString() + TextBoxBackingFields.PaperworkDate.ToString("MM-dd-yyy") + " PWS.pdf", FileMode.Create, FileAccess.ReadWrite, FileShare.None);
            document.Save(documentStream, true);

            if (printPreview == false)
            {
                using (PrintDialog dialogue = new PrintDialog())
                {
                    if (dialogue.ShowDialog() == DialogResult.OK)
                    {

                        ProcessStartInfo printProcessInfo = new ProcessStartInfo()
                        {
                            Verb = "print",
                            CreateNoWindow = true,
                            FileName = Properties.Settings.Default["RootFilePath"].ToString() + Properties.Settings.Default["PdfFilePath"].ToString() + TextBoxBackingFields.PaperworkDate.ToString("MM-dd-yyy") + " PWS.pdf",
                            WindowStyle = ProcessWindowStyle.Hidden
                        };

                        printProcessInfo.FileName = Properties.Settings.Default["RootFilePath"].ToString() + Properties.Settings.Default["PdfFilePath"].ToString() + TextBoxBackingFields.PaperworkDate.ToString("MM-dd-yyy") + " PWS.pdf";

                        Process printProcess = new Process();
                        printProcess.StartInfo = printProcessInfo;
                        printProcess.Start();

                        printProcess.WaitForInputIdle();

                        Thread.Sleep(3000);

                        if (false == printProcess.CloseMainWindow())
                        {
                            printProcess.Kill();
                        }
                    }
                }
            }
            else
            {
                System.Diagnostics.Process.Start(Properties.Settings.Default["RootFilePath"].ToString() + Properties.Settings.Default["PdfFilePath"].ToString() + TextBoxBackingFields.PaperworkDate.ToString("MM-dd-yyy") + " PWS.pdf");
            }
        }
    }
}
