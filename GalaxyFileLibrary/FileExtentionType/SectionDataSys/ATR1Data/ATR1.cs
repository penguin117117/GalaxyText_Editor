using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using GalaxyFileStreamSupportSystem;
using GalaxyFileStreamLibrary.NintendoBinarySystem;

namespace GalaxyFileLibrary.FileExtentionType.SectionDataSys.ATR1Data
{
    public class ATR1
    {
        public long BasePosition { get; private set; }

        public string SectionName { get; private set; }
        public int SectionSize { get; private set; }
        public int Unknown1 { get; private set; }
        public int Unknown2 { get; private set; }
        public int EntrySize { get; private set; }
        public int EntryByteSize { get; private set; }
        public AttributeEntries AttributeEntries { get; private set; }


        public void Read(BinaryReader br)
        {
            BasePosition     = br.BaseStream.Position;

            SectionName      = Encoding.ASCII.GetString(br.ReadBytes(4));
            SectionSize      = BigEndian.ReadInt32(br);
            Unknown1         = BigEndian.ReadInt32(br);
            Unknown2         = BigEndian.ReadInt32(br);
            EntrySize        = BigEndian.ReadInt32(br);
            EntryByteSize    = BigEndian.ReadInt32(br);

            Console.WriteLine("EntrySize: 0x" + EntrySize.ToString("X"));

            AttributeEntries = new AttributeEntries();
            AttributeEntries.Read(br, EntrySize);
            AttributeEntries.ReadSpecialTextes(br, EntrySize);

            Padding.ReadSkip(br);

            Console.WriteLine("ATR1 Section End Position: 0x" + br.BaseStream.Position.ToString("X"));
            Console.WriteLine("----- ATR1 End -----");
        }
    }

    public class AttributeEntries 
    {
        public AttributeEntry[] FromBinary { get; private set; }

        public void Read(BinaryReader br, int entrySize)
        {

            FromBinary = new AttributeEntry[entrySize];

            for (int i = 0; i < entrySize; i++) 
            {
                FromBinary[i].Read(br);
            }
        }

        public void ReadSpecialTextes(BinaryReader br, int entrySize) 
        {
            for (int i = 0; i < entrySize; i++)
            {
                string tmp = string.Empty;

                List<byte> list = new List<byte>();
                list.Add(br.ReadByte());
                list.Add(br.ReadByte());

                if (!((list[0] == 0x00) && (list[1] == 0x00)))
                {
                    while (true)
                    {
                        if ((list[list.Count() - 2] == 0) && (list[list.Count() - 1] == 0))
                        {
                            break;
                        }
                        list.Add(br.ReadByte());
                    }
                }

                FromBinary[i].SpecialText = Encoding.GetEncoding("utf-16BE").GetString(list.ToArray());
            }
        }
    }

    public struct AttributeEntry 
    {
        public byte Voice { get; private set; }
        public byte SimpleCamera { get; private set; }
        public byte DialogType { get; private set; }
        public byte WindowLayout { get; private set; }
        public short EventCameraID { get; private set; }
        public byte MessageAreaID { get; private set; }
        public byte Unknown6 { get; private set; }
        public int SpecialTextOffset { get; private set; }
        public string SpecialText { get; set; }

        public void Read(BinaryReader br) 
        {
            Voice                = br.ReadByte();
            SimpleCamera         = br.ReadByte();
            DialogType           = br.ReadByte();
            WindowLayout         = br.ReadByte();
            EventCameraID        = BigEndian.ReadInt16(br);
            MessageAreaID        = br.ReadByte();
            Unknown6             = br.ReadByte();
            SpecialTextOffset    = BigEndian.ReadInt32(br);
        }
    }
}
