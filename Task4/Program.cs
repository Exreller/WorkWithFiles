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
            

            BinaryFormatter bf = new BinaryFormatter();
           
            // десериализация
            using (var fs = new FileStream(@"C:\Users\Exreller\Desktop\NewFolder1\Students.dat", FileMode.OpenOrCreate))
            {
                Student[] students = (Student[]) bf.Deserialize(fs) ;
                foreach(var student in students)
                {
                    Console.WriteLine("Объект десериализован");
                    Console.WriteLine($"Имя: {student.Name} {student.Group} {student.DateOfBirth }");
                }
                
            }
            Console.ReadLine();
        }
    }
}
