using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates001
{
    public class Program
    {
        delegate void LogSimple(string message);// create a delete that has no return type

        static void Main(string[] args)
        {
            LogSimple logTerminal = new LogSimple(LogConsole);

            logTerminal("Hello world");

            Logger simpleLogger= new Logger();

            LogSimple logScopeGlobalTerminal = new LogSimple(simpleLogger.LogTerminal);

            LogSimple logScopeGlobalTime= new LogSimple(simpleLogger.LogToText);

            LogSimple multiLog=logScopeGlobalTerminal + logScopeGlobalTime;

            multiLog("This works");

            Console.ReadKey();
        }

        static void LogConsole(string message)
        {
            System.Console.WriteLine($"the message {message}");
        }
    }

    public class Logger
    {
        public void LogTerminal(string message)
        {
            System.Console.WriteLine($"msg: {message}");
        }

        public void LogToText(string message)
        {
            DateTime time = DateTime.Now;

            System.Console.WriteLine($"msg + {message}");

            System.Console.WriteLine($"time: {time}");

        }
    }
}
