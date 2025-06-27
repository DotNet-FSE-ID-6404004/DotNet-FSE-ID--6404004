using System;

public class Factory
{
    public interface IMyDoc
    {
        void Open();
    }

    public class WordDoc : IMyDoc
    {
        public void Open()
        {
            Console.WriteLine("Word file is now open");
        }
    }

    public class PdfDoc : IMyDoc
    {
        public void Open()
        {
            Console.WriteLine("PDF file is now open");
        }
    }

    public class ExcelDoc : IMyDoc
    {
        public void Open()
        {
            Console.WriteLine("Spreadsheet opened.");
        }
    }

    public abstract class DocMaker
    {
        public abstract IMyDoc MakeDoc();
    }

    public class WordDocMaker : DocMaker
    {
        public override IMyDoc MakeDoc()
        {
            return new WordDoc();
        }
    }

    public class PdfDocMaker : DocMaker
    {
        public override IMyDoc MakeDoc()
        {
            return new PdfDoc();
        }
    }

    public class ExcelDocMaker : DocMaker
    {
        public override IMyDoc MakeDoc()
        {
            return new ExcelDoc();
        }
    }

    public static void Main()
    {
        DocMaker wordMaker = new WordDocMaker();
        IMyDoc word = wordMaker.MakeDoc();
        word.Open();

        DocMaker pdfMaker = new PdfDocMaker();
        IMyDoc pdf = pdfMaker.MakeDoc();
        pdf.Open();

        DocMaker excelMaker = new ExcelDocMaker();
        IMyDoc excel = excelMaker.MakeDoc();
        excel.Open();
    }
}
