using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace ConsoleApp1.FileService
{
    class JsonService : IFileService
    {
        private string fileName;

        public JsonService(string fileName)
        {
            this.fileName = fileName;
        }
        
        public List<Student> LoadFile()
        {
            List<Student> students = new List<Student>();
            if (!File.Exists(fileName))
            {
                Console.WriteLine("Файл не найден");
                return students;
            }

            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<Student>));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                students = (List<Student>)ser.ReadObject(fs);
            }

            Console.WriteLine("Файл загружен");

            return students;
        }

        public void SaveFile(List<Student> students)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<Student>));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                ser.WriteObject(fs, students);
            }

            Console.WriteLine("Файл сохранен");
        }
    }
}
