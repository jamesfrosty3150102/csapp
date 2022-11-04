using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileInfoClassLibrary1
{
    public class FileInfoClass1
    {
        public bool dllTestAPI(ref string sMsg)
        {
            Console.WriteLine("dllTestAPI:{0}", sMsg);
            return true;
        }

        public bool _AppendText(ref string sMsg)
        {
            Console.WriteLine("AppendText:{0}", sMsg);
            return true;
        }
    }

//FileInfo
    //AppendText
    //CopyTo
    //Create
    //CreateText
    //Decrypt
    //Delete
    //Encrypt
    //MoveTo
    //Open
    //OpenRead
    //OpenText
    //OpenWrite
    //Replace
    //ToString

}
