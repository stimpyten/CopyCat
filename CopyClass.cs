using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CopyCat1
{
    internal class CopyClass
    {
        public static void CopyCat(string input, string outputPath, string file)
        {
            File.Copy(file, System.IO.Path.Combine(outputPath, System.IO.Path.GetFileName(file)));
        }
    }
}
