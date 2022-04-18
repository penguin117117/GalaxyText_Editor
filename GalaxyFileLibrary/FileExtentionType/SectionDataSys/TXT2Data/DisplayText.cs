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
                byte[] stringBytes = br.ReadBytes(2);

                bool isNullTermination   = (stringBytes[0] == 0x00) && (stringBytes[1] == 0x00);
                bool isNewLine           = (stringBytes[0] == 0x00) && (stringBytes[1] == 0x0A);
                bool isTag               = (stringBytes[0] == 0x00) && (stringBytes[1] == 0x0E);

                if (isNullTermination) break;

                if (isNewLine)
                {
                    Text += "</br>";
                    continue;
                }

                if (isTag) 
                {
                    Console.WriteLine(Text);
                    Console.WriteLine("pos: 0x" + br.BaseStream.Position.ToString("X"));

                    //TagModifyクラスをここに配置する
                    TagData.TagModify tagModify = new TagData.TagModify(br);
                    Text += tagModify.CategoryTag.SubCategory.TagText;

                    throw new Exception();
                    continue;
                }

                Text += Encoding.GetEncoding(EncodingName.UTF16_Bigendian).GetString(stringBytes);
                
            }
        }
    }
}
