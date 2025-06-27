using System;

public class Singleton
{
    public class Logger
    {
        private static Logger? instance;

        private Logger()
        {
            Console.WriteLine("Logger Initialized");
        }

        public static Logger GetInstance()
        {
            if (instance == null)
            {
                instance = new Logger();
            }
            return instance;
        }

        public void Log(string message)
        {
            Console.WriteLine("[LOG]: " + message);
        }
    }

    public static void Main()
    {
        Logger logger1 = Logger.GetInstance();
        logger1.Log("First log message");

        Logger logger2 = Logger.GetInstance();
        logger2.Log("Second log message");

        Console.WriteLine("Same instance? " + (logger1 == logger2));
    }
}
