using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ushortTest2
{
    class ushortTest2
    {
        static void Main(string[] args)
        {
            ushort abc = 0xFF;
            Console.WriteLine(abc);
            byte[] abc1 = null;
            abc1 = BitConverter.GetBytes(abc);
            for (int i = 0; i < abc1.Length; i++)
            {
                Console.WriteLine(abc1[i].ToString("X"));
            }
        }
    }
}
