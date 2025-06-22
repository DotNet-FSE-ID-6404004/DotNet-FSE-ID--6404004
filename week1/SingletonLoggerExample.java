public class SingletonLoggerExample {
    static class Logger {
        private static Logger instance;

        private Logger() {
            System.out.println("Logger Initialized");
        }

        public static Logger getInstance() {
            if (instance == null) {
                instance = new Logger();
            }
            return instance;
        }

        public void log(String message) {
            System.out.println("[LOG]: " + message);
        }
    }

    public static void main(String[] args) {
        Logger logger1 = Logger.getInstance();
        logger1.log("First log message");

        Logger logger2 = Logger.getInstance();
        logger2.log("Second log message");

        System.out.println("Same instance? " + (logger1 == logger2));
}
}