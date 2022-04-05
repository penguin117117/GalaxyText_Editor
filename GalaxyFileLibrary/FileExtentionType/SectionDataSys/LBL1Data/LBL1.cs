using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using GalaxyFileStreamSupportSystem;

namespace GalaxyFileLibrary.FileExtentionType.SectionDataSys.LBL1Data
{
    public class LBL1 : ILBL1
    {
        public string SectionName { get; private set; }
        public int SectionSize { get; private set; }
        public int Unknown1 { get; private set; }
        public int Unknown2 { get; private set; }
        public int EntrySize { get; private set; }


        public void Read(BinaryReader br) 
        {

            SectionName  = Encoding.ASCII.GetString(br.ReadBytes(4));
            SectionSize  = BigEndian.ReadInt32(br);
            Unknown1     = BigEndian.ReadInt32(br);
            Unknown2     = BigEndian.ReadInt32(br);
            EntrySize    = BigEndian.ReadInt32(br);

            LabelData[] labelData = new LabelData[EntrySize];

            for (int i = 0; i < EntrySize; i++)
            {
                labelData[i].Read(br);
            }

            Console.WriteLine($"RemoveDuplication: { RemoveDuplication(labelData).Count() }");

            Console.WriteLine(br.BaseStream.Position.ToString("X"));
        }

        private LabelData[] RemoveDuplication(LabelData[] labelData) 
        {
            return labelData.Where(x => x.HashSkip != 0).ToArray();
        }
    }

    public struct LabelData 
    {
        public uint HashSkip { get; private set; }
        public uint Offset { get; private set; }

        public void Read(BinaryReader br) 
        {
            HashSkip     = BigEndian.ReadUInt32(br);
            Offset       = BigEndian.ReadUInt32(br);
        }
    }
}
