using prs.appdata;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Excel = Microsoft.Office.Interop.Excel;
using System.Drawing;

namespace prs.pages
{
    /// <summary>
    /// Логика взаимодействия для exipdf.xaml
    /// </summary>
    public partial class exipdf : Page
    {
        public exipdf()
        {
            InitializeComponent();
        }
        private void EXBtn_Click(object sender, RoutedEventArgs e)
        {
            var acc = Class1.context.uchetnaya.ToList();
            var spr = Class1.context.spravochnaya.ToList();
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook wb = app.Workbooks.Add(Type.Missing);
            Excel.Worksheet ws = (Excel.Worksheet)app.Worksheets.get_Item(1);
            ws.Name = "Учётная  таблица";
            Excel.Range r = ws.Range["A1", "E2"];
            r.Merge();
            r.Value = "Ведомость поставки товара";
            r.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            r.Cells.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            ws.Cells.Font.Name = "Times New Roman";
            ws.Cells[3, 1].Value = "Наименование товара";
            ws.Cells[3, 2].Value = "Ед.изм.";
            ws.Cells[3, 3].Value = "Цена";
            ws.Cells[3, 4].Value = "Кол-во товара";
            ws.Cells[3, 5].Value = "Дата";
            

            var curRow = 4;
            int? sum = 0;
            foreach (var item in acc)
            {
                ws.Cells[curRow, 1].Value = item.spravochnaya.Nazvaniye_tovara;
                ws.Cells[curRow, 2].Value = item.spravochnaya.Edinica_izmereniya;
                ws.Cells[curRow, 3].Value = item.Cena;
                ws.Cells[curRow, 4].Value = item.Kolichestvo_tovara;
                ws.Cells[curRow, 5].Value = item.Data;
               
                curRow++;
            }

            ws.Cells[curRow, 1].Value = "Итого: ";
            ws.Cells[curRow, 5].Value = sum;
            Excel.Range range = ws.Range[ws.Cells[curRow, 1], ws.Cells[curRow, 4]];
            range.Merge();

            Excel.Range ran = ws.Range[ws.Cells[3, 1], ws.Cells[curRow, 5]];
            ran.Borders.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);


            ws.Columns.AutoFit();
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = System.IO.Path.Combine(desktopPath, "Ведомость поставки товаров");
            wb.SaveAs(filePath);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
        }

        private void PDFBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Document doc = new Document();
                PdfWriter.GetInstance(doc, new FileStream("Ведомость.pdf", FileMode.Create));
                doc.Open();
                BaseFont baseFont = BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);
                PdfPTable table = new PdfPTable(5);
                PdfPCell cell = new PdfPCell(new Phrase("Ведомость поставки товара", font));
                cell.Colspan = 5;
                cell.HorizontalAlignment = 1;
                cell.Border = 0;
                table.AddCell(cell);
                table.AddCell(new PdfPCell(new Phrase(new Phrase("Наименование товара", font))));
                table.AddCell(new PdfPCell(new Phrase(new Phrase("Ед.изм.", font))));
                table.AddCell(new PdfPCell(new Phrase(new Phrase("Цена", font))));
                table.AddCell(new PdfPCell(new Phrase(new Phrase("Кол-во товара", font))));
                table.AddCell(new PdfPCell(new Phrase(new Phrase("Дата", font))));
                
                int? sum = 0;
                foreach (var item in Class1.context.uchetnaya.ToList())
                {
                    table.AddCell(new Phrase(item.spravochnaya.Nazvaniye_tovara.ToString(), font));
                    table.AddCell(new Phrase(item.spravochnaya.Edinica_izmereniya.ToString(), font));
                    table.AddCell(new Phrase(item.Cena.ToString(), font));
                    table.AddCell(new Phrase(item.Kolichestvo_tovara.ToString(), font));
                    table.AddCell(new Phrase(item.Data.ToString(), font));
                    
                }

                table.AddCell(new PdfPCell(new Phrase("Итого: ", font)) { Colspan = 4 });
                table.AddCell(new Phrase(sum.ToString(), font));

                doc.Add(table);
                doc.Close();
                MessageBox.Show("PDF-документ сохранён");
            }
            catch
            {
                MessageBox.Show("PDF-документ не сохранён", "Ошибка");
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }
    }
}
