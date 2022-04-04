using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GalaxyFileLibrary.FileExtentionType.SectionDataSys.LBL1Data
{
    public class LBL1 : ILBL1
    {
        public string Magic { get; private set; }

        public void Read(BinaryReader br) 
        {
            Magic = Encoding.ASCII.GetString(br.ReadBytes(4));
        }
    }
}
