using System;
using System.IO;

namespace Task3
{
    class Program
    {
        static void DicertoryСleans(string dirPath)
        {

            try
            {                
                DirectoryInfo path = new DirectoryInfo(dirPath);
                if (path.Exists)
                {
                    long size = 0;
                    TimeSpan interval = TimeSpan.FromMinutes(30);
                    foreach (FileInfo file in path.GetFiles())
                    {
                        
                        TimeSpan timeSpan = DateTime.Now - file.LastAccessTime;
                        if (timeSpan > interval)
                        {
                            size += file.Length;
                            file.Delete();
                            Console.WriteLine("Файл удален");
                        }
                    }

                    foreach (DirectoryInfo directory in path.GetDirectories())
                    {
                        TimeSpan timeSpan = DateTime.Now - directory.LastAccessTime;
                        if (timeSpan > interval)
                        {
                            size += DirectoryExtention.Dirsize(path);
                            directory.Delete(true);
                            Console.WriteLine("Папка удалена");
                        }
                    }
                    Console.WriteLine($"Размер удалённых файлов: {size}") ;
                }
                else
                {
                    Console.WriteLine("Путь не верен или такой директории не существует");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void Main(string[] args)
        {

            Console.WriteLine("Для подсчёта размера, введите путь к папке.");
            Console.WriteLine(@"Шаблон ввода: C:\NewFolder");
            string dirPath = Console.ReadLine();
            DirectoryInfo path = new DirectoryInfo(dirPath);
            if (path.Exists)
            {
                Console.WriteLine($"Исходный размер {DirectoryExtention.Dirsize(path)} байт");
            }
            else
            {
                Console.WriteLine("Указанный путь не существует");
            }

            DicertoryСleans(dirPath);

            Console.WriteLine($"Итоговый размер: {DirectoryExtention.Dirsize(path)} байт");

        }
    }
}
