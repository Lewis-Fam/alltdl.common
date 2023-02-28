/***
   Copyright (C) 2021. LewisFam. All Rights Reserved.
   Version: 1.1.1
***/

namespace alltdl.CmdLine
{
    public enum ConsoleColorServerity
    {
        Trace,

        Info,

        Warning,

        Error,

        Fatal,
    }

    public abstract class BaseLewisFamConsole
    {
        protected static string HelloWorld => "Hello World!";

        protected static void PrintLine(object value) =>
                    Console.WriteLine(value);

        protected static void PrintLine(string value) =>
                    Console.WriteLine(value);

        protected static void ResetColor()
        {
            Console.ResetColor();
        }

        protected static void SetColor(ConsoleColor backgroundColor = ConsoleColor.Black, ConsoleColor foregroundColor = ConsoleColor.White)
        {
            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = foregroundColor;
        }
    }
}