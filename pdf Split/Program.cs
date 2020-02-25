using System;
using IronPdf;
using System.IO;


namespace pdf_Split
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Em qual diretório esta os arquivos?");
            string path = Console.ReadLine();
            string[] folders = Directory.GetDirectories(path);

            foreach (string folder in folders)
            {
                string[] files = Directory.GetFiles(folder);
                foreach (string item in files)
                {
                    PdfDocument pdf = PdfDocument.FromFile(item);
                    for (int i = 0; i < pdf.PageCount; i++)
                    {

                        if ((i + 1) % 2 == 0)
                        {
                            pdf.CopyPages(i - 1, i).SaveAs(item + i.ToString() + "-" + (i + 1).ToString() + ".pdf");
                        }
                    }
                    if (pdf.PageCount % 2 != 0)
                    {
                        pdf.CopyPages(pdf.PageCount - 1, pdf.PageCount - 1).SaveAs(item + pdf.PageCount.ToString() + ".pdf");
                    }
                }
            }
            

            Console.WriteLine("Quebra concluida");
            Console.ReadLine();
        }
    }
}
