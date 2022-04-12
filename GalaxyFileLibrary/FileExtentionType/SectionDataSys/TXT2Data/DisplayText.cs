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

                    //TagModifyクラスをここに配置する
                    TagData.TagModify tagModify = new TagData.TagModify();
                    Text += tagModify.Read(br);

                    throw new Exception();
                    continue;
                }

                Text += Encoding.GetEncoding(EncodingName.UTF16_Bigendian).GetString(Top2byte);
                
            }
        }
    }
}
