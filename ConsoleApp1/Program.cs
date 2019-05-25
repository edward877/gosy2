
using ConsoleApp1.FileService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().Start();
        }

        private IFileService fileService;
        private List<Student> students;

        void Start()
        {
            string fileName = "students.json";
            fileService = new JsonService(fileName);
            students = fileService.LoadFile();

            string action;
            bool isProcess = true;

            while(isProcess)
            {
                Console.WriteLine("\n0: Закончить.");
                Console.WriteLine("1: Добавить.");
                Console.WriteLine("2: Вывести запрос.");
                Console.WriteLine("3: Сохранить в файл.");
                Console.Write("Действие: ");
                action = Console.ReadLine();

                switch(action)
                {
                    case "1":
                        AddStudent();
                        break;
                    case "2":
                        LinqStudents();
                        break;
                    case "3":
                        fileService.SaveFile(students);
                        break;
                    case "0":
                        isProcess = false;
                        break;
                }
            }

            fileService.SaveFile(students);
        }

        void AddStudent()
        {
            try
            {
                Student student = new Student();

                Console.Write("Имя: ");
                student.Name = Console.ReadLine();
                Console.Write("Группа: ");
                student.Group = Console.ReadLine();
                Console.Write("Факультет: ");
                student.Faculty = Console.ReadLine();
                Console.Write("Курс: ");
                student.Course = int.Parse(Console.ReadLine());

                students.Add(student);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Что-то пошло не так. " + ex.Message);
            }
        }

        void LinqStudents()
        {
            var result = from s in students where s.Course == 2 select s;
            foreach (var s in result)
            {
                Console.WriteLine(s);
            }
        }
    }
}
