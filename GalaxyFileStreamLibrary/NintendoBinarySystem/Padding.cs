using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GalaxyFileStreamLibrary.NintendoBinarySystem
{
    public class Padding
    {
        public static void ReadSkip(BinaryReader br) 
        {
            while (br.BaseStream.Position % 0x20 != 0) 
            {
                br.ReadByte();
            }
        }
    }
}
