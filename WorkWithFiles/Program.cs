using System;
using System.IO;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите путь к папке, которую нужно почистить от файлов и папок," +
                    "\nне использовавшихся более 30 минут");
                Console.WriteLine(@"Шаблон ввода: C:\NewFolder ");                
                DirectoryInfo path = new DirectoryInfo(Console.ReadLine());
                if (path.Exists)
                {
                   
                    TimeSpan interval = TimeSpan.FromMinutes(30);
                    foreach(FileInfo file in path.GetFiles())
                    {
                        TimeSpan timeSpan = file.CreationTime - DateTime.Now;
                        if (timeSpan > interval)
                        {
                            file.Delete();
                            Console.WriteLine("Файлы удалены");
                        }
                        else
                        {
                            Console.WriteLine("Подходящие файлы не обнаружены");
                        }
                    }
                    
                    foreach(DirectoryInfo directory in path.GetDirectories())
                    {
                        TimeSpan timeSpan = directory.CreationTime - DateTime.Now;
                        if(timeSpan > interval)
                        {
                            directory.Delete(true);
                            Console.WriteLine("Директории удалены");
                        }
                        else
                        {
                            Console.WriteLine("Нет подходящих папок к удалению");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Путь не верен или такой директории не существует");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
