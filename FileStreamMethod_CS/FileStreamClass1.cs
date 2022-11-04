using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStreamClassLibrary1
{
    public class FileStreamClass1
    {
        public bool dllTestAPI(ref string sMsg)
        {
            Console.WriteLine("dllTestAPI:{0}", sMsg);
            return true;
        }

        public bool _BeginRead(ref string sMsg)
        {
            Console.WriteLine("BeginRead:{0}", sMsg);
            return true;
        }

    }
}
//  BeginRead
//  BeginWrite
//	CopyToAsync
//	Dispose
//	DisposeAsync
//	EndRead
//	EndWrite
//	Finalize
//	Flush
//	FlushAsync
//	Lock
//	Read
//	ReadAsync
//	ReadByte
//	Seek
//	SetLength
//	Unlock
//	Write
//	WriteAsync
//	WriteByte
//	FileStreamOptions
