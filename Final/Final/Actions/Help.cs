using System;
using System.Collections.Generic;
using System.Text;

namespace Final.Actions
{
    class Help : Action
    {
        private string command = "all";
        private Dictionary<string, string> helpers = new Dictionary<string, string>();

        public void Create(params string[] args)
        {
            if(args.Length == 2)
            {
                this.command = args[1];
            }
            this.Run();
        }

        private void Run()
        {
            this.FullfillDictionary();

            if (this.command == "all")
            {
                foreach(KeyValuePair<string, string> entry in this.helpers)
                {
                    Console.WriteLine($"{entry.Key} {entry.Value}");
                }
            } else
            {
                Console.WriteLine($"{this.command} {this.helpers[this.command]}");
            }
        }

        private void FullfillDictionary()
        {
            this.helpers.Add("/cd", "Переход между каталогами. Синтаксис: /cd полный_путь_к_каталогу. Пример /cd c:\\Document And Settings. Для указания текущей папки используйте '.'");
            this.helpers.Add("/rm", "Удаление файла. Синтаксис: /rm полный_путь_к_файлу имя_файла. Пример /rm c:\\Document And Settings test.txt. Для указания текущей папки используйте '.'");
            this.helpers.Add("/copy", "Копирование файла. Синтаксис: /copy полный_путь_к_файлу полный_путь_к_новой_папке имя_файла. Пример /copy c:\\Document And Settings c:\\Document And Settings2 test.txt. Для указания текущей папки используйте '.'");
            this.helpers.Add("/help", "Помощь по командам менеджера. Синтаксис: /help нзвание команды. Если названия нет - выводит информацию обо всех командах");
            this.helpers.Add("/info", "Просмотр информации о файле. Синтаксис: /info полный_путь_к_каталогу имя_файла. Пример /info c:\\Document And Settings test.txt. Для указания текущей папки используйте '.'");
            this.helpers.Add("/ls", "Просмотр файлов в директории. Синтаксис: /ls полный_путь_к_каталогу. Пример /ls c:\\Document And Settings. Для указания текущей папки используйте '.'");
        }
    }
}
