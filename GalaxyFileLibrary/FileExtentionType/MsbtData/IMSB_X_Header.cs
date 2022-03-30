using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GalaxyFileLibrary.FileExtentionType.MsbtData
{
    public interface IMSB_X_Header
    {
        ushort Endian { get; }
        uint FileSize { get; set; }
        string Magic { get; }
        ushort Padding1 { get; }
        byte EncodingType { get;}
        byte VerNum { get; }
        ushort SectionCount { get; }
        ushort Padding2 { get;  }
        ushort[] Paddings { get; }
        void Read(BinaryReader br);
    }
}
