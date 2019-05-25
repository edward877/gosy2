using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.FileService
{
    interface IFileService
    {
        List<Student>  LoadFile();

        void SaveFile(List<Student> students);

    }
}
