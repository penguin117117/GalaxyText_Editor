using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using GalaxyFileStreamLibrary;

namespace GalaxyFileLibrary.FileExtentionType.SectionDataSys.TXT2Data
{
    public class DisplayText
    {
        public string Text { get; private set; }

        public void Read(BinaryReader br)
        {
            while (true)
            {
                byte[] Top2byte = br.ReadBytes(2);

                bool isNullTermination   = (Top2byte[0] == 0x00) && (Top2byte[1] == 0x00);
                bool isNewLine           = (Top2byte[0] == 0x00) && (Top2byte[1] == 0x0A);
                bool isTag               = (Top2byte[0] == 0x00) && (Top2byte[1] == 0x0E);

                if (isNullTermination) break;

                if (isNewLine)
                {
                    Text += "</br>";
                    continue;
                }

                if (isTag == true) 
                {
                    Console.WriteLine(Text);
                    Console.WriteLine("pos: 0x" + br.BaseStream.Position.ToString("X"));
                    throw new Exception();
                    continue;
                }

                Text += Encoding.GetEncoding(EncodingName.UTF16_Bigendian).GetString(Top2byte);
                
            }
        }
    }

    public class TagModify 
    {
        private readonly Dictionary<byte, ITagData> _tagDictionary = new Dictionary<byte, ITagData> 
        {
            { 0x00 , new SystemTag() }
        };

        public void Read(BinaryReader br) 
        {
            byte[] CategoryByte = br.ReadBytes(2);

            _tagDictionary[CategoryByte[1]].Read(br);
        }
    }

    public interface ITagData 
    {
        string Read(BinaryReader br);
    }

    public class SystemTag : ITagData
    {
        private readonly Dictionary<byte, ISystemTagSubCategory> _systemTagSubCategory = new Dictionary<byte, ISystemTagSubCategory>() 
        {
            { 0x00 , new Ruby() }
        };

        public string Read(BinaryReader br)
        {
            byte[] subCategory_2Byte = br.ReadBytes(2);

            return _systemTagSubCategory[subCategory_2Byte[1]].Read(br);
        }
    }

    public interface ISystemTagSubCategory 
    {
        string Read(BinaryReader br);
    }

    public class Ruby : ISystemTagSubCategory
    {
        public string Read(BinaryReader br)
        {
            return string.Empty;
        }
    }
}
