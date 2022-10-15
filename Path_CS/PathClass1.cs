using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PathClassLibrary1
{
    public class PathClass1
    {
        public bool dllTestAPI(ref string sMsg)
        {
            Console.WriteLine("dllTestAPI:{0}", sMsg);
            return true;
        }

        public bool _ChangeExtension(ref string sMsg)
        {
            Console.WriteLine("ChangeExtension:{0}", sMsg);
            return true;
        }

        public bool _Combine(ref string sMsg)
        {
            Console.WriteLine("Combine:{0}", sMsg);
            return true;
        }

        public bool _EndsInDirectorySeparator(ref string sMsg)
        {
            Console.WriteLine("EndsInDirectorySeparator:{0}", sMsg);
            return true;
        }

        public bool _GetDirectoryName(ref string sMsg)
        {
            Console.WriteLine("GetDirectoryName:{0}", sMsg);
            return true;
        }

        public bool _GetExtension(ref string sMsg, ref string _path)
        {
            Console.WriteLine("GetExtension:{0}", sMsg);
            _path = Path.GetExtension(sMsg);
            return true;
        }

        public bool _GetFileName(ref string sMsg)
        {
            Console.WriteLine("GetFileName:{0}", sMsg);
            return true;
        }

        public bool _GetFileNameWithoutExtension(ref string sMsg)
        {
            Console.WriteLine("GetFileNameWithoutExtension:{0}", sMsg);
            return true;
        }

        public bool _GetFullPath(ref string sMsg)
        {
            Console.WriteLine("GetFullPath:{0}", sMsg);
            return true;
        }

        public bool _GetInvalidFileNameChars(ref string sMsg)
        {
            Console.WriteLine("GetInvalidFileNameChars:{0}", sMsg);
            return true;
        }

        public bool _GetInvalidPathChars(ref string sMsg)
        {
            Console.WriteLine("GetInvalidPathChars:{0}", sMsg);
            return true;
        }

        public bool _GetPathRoot(ref string sMsg)
        {
            Console.WriteLine("GetPathRoot:{0}", sMsg);
            return true;
        }
        public bool _GetRandomFileName(ref string sMsg)
        {
            Console.WriteLine("GetRandomFileName:{0}", sMsg);
            return true;
        }
        public bool _GetRelativePath(ref string sMsg)
        {
            Console.WriteLine("GetRelativePath:{0}", sMsg);
            return true;
        }
        public bool _GetTempFileName(ref string sMsg)
        {
            Console.WriteLine("GetTempFileName:{0}", sMsg);
            return true;
        }
        public bool _GetTempPath(ref string sMsg)
        {
            Console.WriteLine("GetTempPath:{0}", sMsg);
            return true;
        }
        public bool _HasExtension(ref string sMsg)
        {
            Console.WriteLine("HasExtension:{0}", sMsg);
            return true;
        }
        public bool _IsPathFullyQualified(ref string sMsg)
        {
            Console.WriteLine("IsPathFullyQualified:{0}", sMsg);
            return true;
        }
        public bool _IsPathRooted(ref string sMsg)
        {
            Console.WriteLine("IsPathRooted:{0}", sMsg);
            return true;
        }
        public bool _Join(ref string sMsg)
        {
            Console.WriteLine("Join:{0}", sMsg);
            return true;
        }
        public bool _TrimEndingDirectorySeparator(ref string sMsg)
        {
            Console.WriteLine("TrimEndingDirectorySeparator:{0}", sMsg);
            return true;
        }
        public bool _TryJoin(ref string sMsg)
        {
            Console.WriteLine("TryJoin:{0}", sMsg);
            return true;
        }

    }
}
