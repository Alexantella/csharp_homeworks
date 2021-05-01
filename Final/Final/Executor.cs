using Final.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Final
{
    class Executor
    {
        public void Run()
        {
            bool isWork = true;

            // Long text for hello.
            this.SayHello();

            // Show files in current directory.
            this.showCurrent();

            while (isWork)
            {
                try
                {
                    // Our own ReadLine with blackjack and... you know.
                    // We use it for combine history of commands with keyboard enter.

                    string str = this.ReadLine();

                    if (str == "/exit")
                    {
                        break;
                    }

                    // Safe command in command history
                    Logger.History.HistoryLog(str);

                    // Get args from line. Use regex for file names with whitespaces
                    string[] args = Regex.Matches(str, @"[\""].+?[\""]|[^ ]+")
                        .Cast<Match>()
                        .Select(m => m.Value.Trim('"'))
                        .ToArray();

                    // Use a bit of abstract factory with reflection and get action we need for this command.
                    ActionFactory factory = new ActionFactory(args[0]);

                    // Let just pretend it's kind of reflection too.
                    // Run our action.
                    factory.command.Create(args);
                } 
                catch(Exception e)
                {
                    Logger.Logger.ErrorLog(e);
                }

                this.WriteCurrent();
            }

        }

        // Get current directory from file with directory history
        private string getCurrentDirectory()
        {
            return CurrentDirectory.getCurrentDirectory();
        }

        // Show content of current directory
        private void showCurrent()
        {
            string current = this.getCurrentDirectory();
            ActionFactory action = new ActionFactory("/cd");
            action.command.Create(new string[] { "", current });
            this.WriteCurrent();
        }

        // Show current path on the start of line;
        private void WriteCurrent()
        {
            string current = this.getCurrentDirectory();
            Console.Write($"{current} >");
        }

        // ReadLine for correct using ReadLine and ReadKey together.
        private string ReadLine()
        {
            List<string> commands = Logger.History.HistoryLoad();
            ConsoleKeyInfo cki;

            int i = 0;
            int cTop = Console.CursorTop;
            int cLeft = Console.CursorLeft;
            string retString = "";
            int curIndex = 0;

            do
            {
                string str = "";
                cki = Console.ReadKey(true);

                // Watch for the keys and do work. We have only Enter, Arrows and Backspase special actions
                // If we need more special actions for keys - we have to define them.
                switch (cki.Key)
                {
                    case ConsoleKey.DownArrow:
                        if(i - 1 >= 0)
                        {
                            i--;
                            str = commands[i];
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (i + 1 < commands.Count)
                        {
                            i++;
                            str = commands[i];
                        }
                        break;
                    case ConsoleKey.Backspace:
                        if (curIndex > 0)
                        {
                            retString = retString.Remove(retString.Length - 1);
                            Console.SetCursorPosition(Console.CursorLeft - (Console.CursorLeft - cLeft), Console.CursorTop);
                            Console.Write(Enumerable.Repeat<char>(' ', Console.BufferWidth).ToArray());
                            Console.SetCursorPosition(cLeft, cTop);
                            Console.Write(retString);
                            curIndex--;
                        }
                        break;
                    case ConsoleKey.Enter:
                        Console.WriteLine();
                        return retString;
                    default:
                        if (cki.KeyChar != 0x0000)
                        {
                            retString += cki.KeyChar;
                            Console.Write(cki.KeyChar);
                            curIndex++;
                        }
                        break;
                }

                if (str.Length > 0)
                {
                    // Move cursor to the end of our line.
                    Console.SetCursorPosition(Console.CursorLeft - (Console.CursorLeft - cLeft), Console.CursorTop);
                    // Clear everything that has written
                    Console.Write(Enumerable.Repeat<char>(' ', Console.BufferWidth).ToArray());
                    // Move cursor to the start again.
                    Console.SetCursorPosition(cLeft, cTop);

                    retString = str;
                    curIndex = str.Length;

                    Console.Write(str);
                } 
            } while (true);
        }

        private void SayHello()
        {
            Console.WriteLine("Добро пожаловать в кривой файловый менеджер.");
            Console.WriteLine("Для получения справки по командам напишите /help");
            Console.WriteLine("Если имя вашего файла или директории содержит пробелы - вводите его в двойных кавычках. Если вы умудрились напихать туда еще какой-то хтони - молитесь");
            Console.WriteLine("Для выхода введите /exit");
            Console.WriteLine();
        }
    }
}
