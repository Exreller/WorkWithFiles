using System;
using System.IO;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Для подсчёта размера, введите путь к папке.");
                Console.WriteLine(@"Шаблон ввода: C:\NewFolder");
                DirectoryInfo path = new DirectoryInfo(Console.ReadLine());
                if (path.Exists)
                {                    
                    Console.WriteLine($"Размер {DirectoryExtention.Dirsize(path)} байт");
                }
                else
                {
                    Console.WriteLine("Указанный путь не существует");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
           
        }

    }
}
