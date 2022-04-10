using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using GalaxyFileStreamSupportSystem;
using GalaxyFileStreamLibrary.NintendoBinarySystem;
using GalaxyFileStreamLibrary;

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
        public TextEntries TextEntries { get; private set; }

        public void Read(BinaryReader br)
        {
            BaseAddress  = br.BaseStream.Position;

            SectionName  = Encoding.ASCII.GetString(br.ReadBytes(4));
            SectionSize  = BigEndian.ReadInt32(br);
            Unknown1     = BigEndian.ReadInt32(br);
            Unknown2     = BigEndian.ReadInt32(br);

            TextBaseAddress  = br.BaseStream.Position;

            EntrySize    = BigEndian.ReadInt32(br);

            TextEntries = new TextEntries();
            TextEntries.Read(br, EntrySize);

            //List<int> tes = new List<int>();
            //{
            //    for (int i = 0; i < EntrySize; i++) 
            //    {
            //        tes.Add(BigEndian.ReadInt32(br));
            //    }
            //}

            Console.WriteLine("TXT2 End Address: 0x" + br.BaseStream.Position.ToString("X"));
        }
    }

    public class TextEntries 
    {
        public TextEntry[] FromBinary { get; private set; }

        public void Read(BinaryReader br, int entrySize) 
        {
            FromBinary = new TextEntry[entrySize];

            for (int i = 0; i < entrySize; i++) 
            {
                FromBinary[i].ReadOffset(br);
            }
            
            for (int j = 0; j < entrySize; j++)
            {
                FromBinary[j].ReadText(br);
            }
        }

    }

    public struct TextEntry 
    {
        public int Offset { get; private set; }
        public string Text { get; private set; }

        public void ReadOffset(BinaryReader br) 
        {
            Offset = BigEndian.ReadInt32(br);
        }

        /*
         * Note: Banner.msbtはNull末端と改行コードのみで読み込み可能
         */
        public void ReadText(BinaryReader br) 
        {

            while (true)
            {
                byte[] Top2byte = br.ReadBytes(2);

                bool isEnd       = (Top2byte[0] == 0x00) && (Top2byte[1] == 0x00);
                bool isNewLine   = (Top2byte[0] == 0x00) && (Top2byte[1] == 0x0A);
                bool isTag       = (Top2byte[0] == 0x00) && (Top2byte[1] == 0x0E);

                if (isEnd) break;

                if (isNewLine) 
                {
                    Text += "</br>";
                    continue;
                }

                if (isTag == false)
                {
                    Text += Encoding.GetEncoding(EncodingName.UTF16_Bigendian).GetString(Top2byte);
                    continue;
                }
                else
                {
                    Console.WriteLine(Text);
                    Console.WriteLine("pos: 0x" + br.BaseStream.Position.ToString("X"));
                    throw new Exception();
                }

            }

            Console.WriteLine("End Text");
            Console.WriteLine(Text);
        }
    }
}
