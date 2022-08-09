using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FinalTask
{
    [Serializable]
    class Student
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public DateTime DateOfBirth { get; set; }

    }

    class Program
    {

        static void Main(string[] args)
        {
            try
            {
                Student[] students;
                BinaryFormatter bf = new BinaryFormatter();
                using (var fs = new FileStream(@"C:\Users\Exreller\Desktop\NewFolder1\Students.dat", FileMode.OpenOrCreate))
                {
                    students = (Student[])bf.Deserialize(fs);
                    foreach (var student in students)
                    {
                        Console.WriteLine($"Имя: {student.Name} {student.Group} {student.DateOfBirth }");
                    }

                }

                Console.WriteLine("Для продолжения нажмите любую клавишу");
                Console.ReadLine();

                string pathToStudents = @"C:\Users\Exreller\Desktop\NewFolder1\Students";
                DirectoryInfo directoryStudents = new DirectoryInfo(pathToStudents);
                if (!directoryStudents.Exists)
                {
                    directoryStudents.Create();
                }

                foreach (var student in students)
                {
                    string pathToGroups = $@"C:\Users\Exreller\Desktop\NewFolder1\Students\{student.Group}.txt";
                    FileInfo group = new FileInfo(pathToGroups);
                    if (!group.Exists)
                    {
                        using (StreamWriter sw = group.CreateText())
                        {
                            sw.Write(student.Name);
                            sw.Write(student.DateOfBirth + Environment.NewLine);
                        }
                    }
                    else
                    {
                        using (StreamWriter sw = group.AppendText())
                        {
                            sw.Write(student.Name);
                            sw.Write(student.DateOfBirth + Environment.NewLine);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}