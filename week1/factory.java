public class factory {
    interface MyDoc {
        void open();
    }

    static class WordDoc implements MyDoc {
        public void open() {
            System.out.println("Word file is now open");
        }
    }

    static class PdfDoc implements MyDoc {
        public void open() {
            System.out.println("PDF file is now open");
        }
    }

    static class ExcelDoc implements MyDoc {
        public void open() {
            System.out.println("Spreadsheet opened.");
        }
    }

    abstract static class DocMaker {
        abstract MyDoc makeDoc();
    }

    static class WordDocMaker extends DocMaker {
        public MyDoc makeDoc() {
            return new WordDoc();
        }
    }

    static class PdfDocMaker extends DocMaker {
        public MyDoc makeDoc() {
            return new PdfDoc();
        }
    }

    static class ExcelDocMaker extends DocMaker {
        public MyDoc makeDoc() {
            return new ExcelDoc();
        }
    }

    public static void main(String[] args) {
        DocMaker doc = new WordDocMaker();
        MyDoc word = doc.makeDoc();
        word.open();

        DocMaker pdf = new PdfDocMaker();
        MyDoc p = pdf.makeDoc();
        p.open();

        DocMaker excel = new ExcelDocMaker();
        MyDoc x = excel.makeDoc();
        x.open();
    }
}
