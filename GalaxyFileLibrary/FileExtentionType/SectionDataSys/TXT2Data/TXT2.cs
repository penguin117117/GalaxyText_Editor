using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using GalaxyFileStreamSupportSystem;
using GalaxyFileStreamLibrary.NintendoBinarySystem;

namespace GalaxyFileLibrary.FileExtentionType.SectionDataSys.TXT2Data
{
    public class TXT2
    {
        public long BaseAddress { get; private set; }
        public long TextBaseAddress { get; private set; }

        public string SectionName { get; private set; }
        public int SectionSize { get; private set; }
        public int Unknown1 { get; private set; }
        public int Unknown2 { get; private set; }
        public int EntrySize { get; private set; }

        public void Read(BinaryReader br)
        {
            BaseAddress = br.BaseStream.Position;

            SectionName = Encoding.ASCII.GetString(br.ReadBytes(4));
            SectionSize = BigEndian.ReadInt32(br);
            Unknown1 = BigEndian.ReadInt32(br);
            Unknown2 = BigEndian.ReadInt32(br);

            TextBaseAddress = br.BaseStream.Position;

            EntrySize = BigEndian.ReadInt32(br);

            List<int> tes = new List<int>();
            {
                for (int i = 0; i < EntrySize; i++) 
                {
                    tes.Add(BigEndian.ReadInt32(br));
                }
            }

            Console.WriteLine("TXT2 End Address: 0x" + br.BaseStream.Position.ToString("X"));
        }
    }
}
