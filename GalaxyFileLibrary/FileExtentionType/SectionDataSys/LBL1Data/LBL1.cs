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
        public LabelEntries LabelEntries { get; private set; }
        public LabelNameEntries LabelNameEntries { get; private set; }

        public void Read(BinaryReader br) 
        {

            SectionName  = Encoding.ASCII.GetString(br.ReadBytes(4));
            SectionSize  = BigEndian.ReadInt32(br);
            Unknown1     = BigEndian.ReadInt32(br);
            Unknown2     = BigEndian.ReadInt32(br);
            EntrySize    = BigEndian.ReadInt32(br);

            LabelEntries = new LabelEntries();
            LabelEntries.Read(br, EntrySize);

            LabelNameEntries = new LabelNameEntries();
            LabelNameEntries.Read(br,LabelEntries.GetTrueCount());

            GalaxyFileStreamLibrary.NintendoBinarySystem.Padding.ReadSkip(br);

            Console.WriteLine("LBL1 End Address: 0x" + br.BaseStream.Position.ToString("X"));
            Console.WriteLine("----- LBL1 End -----");
        }
    }

    public class LabelEntries
    {
        public LabelEntry[] FromBinary{ get; private set; }
        public LabelEntry[] RemoveHashZero { get; private set; }

        public void Read(BinaryReader br , int entrySize) 
        {
            FromBinary = new LabelEntry[entrySize];

            for (int entryIndex = 0; entryIndex < entrySize; entryIndex++)
            {
                FromBinary[entryIndex].Read(br);
            }

            RemoveHashZero = RemoveZero(FromBinary);
        }

        public int GetTrueCount() 
        {
            uint labelCount = 0;

            foreach (LabelEntry labelEntry in RemoveHashZero)
            {
                labelCount += labelEntry.HashSkip;
            }

            return (int)labelCount;
        }
        
        private LabelEntry[] RemoveZero(LabelEntry[] labelEntries) 
        {
            return labelEntries.Where(labelEntry => labelEntry.HashSkip != 0).ToArray();
        }
    }

    public class LabelNameEntries 
    {
        public LabelNameEntry[] FromBinary { get; private set; }

        public void Read(BinaryReader br, int trueLabelCount) 
        {
            FromBinary = new LabelNameEntry[trueLabelCount];

            for (int j = 0; j < trueLabelCount; j++) 
            {
                FromBinary[j].Read(br);
            }
        }
    }

    public struct LabelNameEntry
    {
        public int OffsetAddress { get; private set; }
        public byte TextLength { get; private set; }
        public string LabelName { get; private set; }
        public uint LabelID { get; private set; }

        public void Read(BinaryReader br) 
        {
            OffsetAddress    = (int)br.BaseStream.Position;
            TextLength       = br.ReadByte();
            LabelName        = Encoding.ASCII.GetString(br.ReadBytes(TextLength));
            LabelID          = BigEndian.ReadUInt32(br);

            Console.WriteLine(LabelName);
        }
    }

    public struct LabelEntry 
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
