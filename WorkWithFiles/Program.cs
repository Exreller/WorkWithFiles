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
                        TimeSpan timeSpan = DateTime.Now - file.LastAccessTime;
                        if (timeSpan > interval)
                        {
                            file.Delete();
                            Console.WriteLine("Файл удален");
                        }
                        
                    }
                    
                    foreach(DirectoryInfo directory in path.GetDirectories())
                    {
                        TimeSpan timeSpan = DateTime.Now - directory.LastAccessTime;
                        if(timeSpan > interval)
                        {
                            directory.Delete(true);
                            Console.WriteLine("Папка удалена");
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
