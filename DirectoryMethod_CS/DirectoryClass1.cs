using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryClassLibrary1
{
    public class DirectoryClass1
    {
        public bool dllTestAPI(ref string sMsg)
        {
            Console.WriteLine("dllTestAPI:{0}", sMsg);
            return true;
        }

        public bool _GetCreationTime(ref string sMsg)
        {
            Console.WriteLine("GetCreationTime:{0}", sMsg);
            return true;
        }
    }
}

//CreateDirectory
//CreateSymbolicLink
//Delete
//EnumerateDirectories
//EnumerateFiles
//EnumerateFileSystemEntries
//Exists
//GetCreationTime
//GetCreationTimeUtc
//GetCurrentDirectory
//GetDirectories
//GetDirectoryRoot
//GetFiles
//GetFileSystemEntries
//GetLastAccessTime
//GetLastAccessTimeUtc
//GetLastWriteTime
//GetLastWriteTimeUtc
//GetLogicalDrives
//GetParent
//Move
//ResolveLinkTarget
//SetCreationTime
//SetCreationTimeUtc
//SetCurrentDirectory
//SetLastAccessTime
//SetLastAccessTimeUtc
//SetLastWriteTime
//SetLastWriteTimeUtc
