using ConsoleApp1.FileService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace ConsoleApp1
{
    class XmlService : IFileService
    {
        private string fileName;

        public XmlService(string fileName)
        {
            this.fileName = fileName;
        }

        public string FileName { set => fileName = value; }

        public List<Student> LoadFile ()
        {
            List<Student> students = new List<Student>();
            if (!File.Exists(fileName))
            {
                Console.WriteLine("Файл не найден");
                return students;
            }

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(fileName);
            XmlElement xRoot = xDoc.DocumentElement;
            foreach (XmlElement xnode in xRoot)
            {
                Student student = new Student();
                XmlNode attr = xnode.Attributes.GetNamedItem("name");
                if (attr != null)
                    student.Name = attr.Value;

                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    if (childnode.Name == "group")
                        student.Group = childnode.InnerText;

                    if (childnode.Name == "course")
                        student.Course = int.Parse(childnode.InnerText);

                    if (childnode.Name == "faculty")
                        student.Faculty = childnode.InnerText;

                }
                students.Add(student);
            }
            Console.WriteLine("Файл загружен");

            return students;
        }

        public void SaveFile(List<Student> students)
        {
            XDocument xdoc = new XDocument();
            XElement xRoot = new XElement("students");

            foreach (Student student in students)
            {
                XElement studentXml = new XElement("student");
                XAttribute attr1 = new XAttribute("name", student.Name);
                XElement attr2 = new XElement("group", student.Group);
                XElement attr3 = new XElement("course", student.Course);
                XElement attr4 = new XElement("faculty", student.Faculty);

                studentXml.Add(attr1);
                studentXml.Add(attr2);
                studentXml.Add(attr3);
                studentXml.Add(attr4);

                xRoot.Add(studentXml);
            }

            xdoc.Add(xRoot);
            //сохраняем документ
            xdoc.Save(fileName);

            Console.WriteLine("Файл сохранен");
        }

    }
}
