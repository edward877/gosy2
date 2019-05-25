
using System.Runtime.Serialization;

namespace ConsoleApp1
{
    [DataContract]
    class Student
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Group { get; set; }
        [DataMember]
        public string Faculty { get; set; }
        [DataMember]
        public int Course { get; set; }

        override
        public string ToString()
        {
            return "Name = " + Name + "; Group = " + Group + "; Faculty = " + Faculty + "; Course = " + Course;
         }
    }
}
