using GalaxyFileLibrary.FileExtentionType.SectionDataSys.TXT2Data.TagData.SystemTagData;
using GalaxyFileStreamLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyFileLibrary.FileExtentionType.SectionDataSys.TXT2Data.TagData.SubTagData
{
    public class Timer : ISubCategory
    {
        public string TagText { get; private set; }

        public void Read(BinaryReader br)
        {
            byte[] stringBytes = br.ReadBytes(4);

            var time = (stringBytes[2] << 8) + stringBytes[3];

            TagText = $"[ふりがな=\"{time}\"]";

            //Console.WriteLine(TagText);
        }
    }
}
