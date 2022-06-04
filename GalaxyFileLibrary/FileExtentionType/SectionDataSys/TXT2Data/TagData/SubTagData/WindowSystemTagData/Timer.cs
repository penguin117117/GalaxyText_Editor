using GalaxyFileLibrary.FileExtentionType.SectionDataSys.TXT2Data.TagData.SystemTagData;
using GalaxyFileStreamLibrary;
using GalaxyFileStreamSupportSystem;
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
            br.ReadBytes(2);

            var time = BigEndian.ReadUInt16(br);

            TagText = $"<時間=\"{time}\">";
        }
    }
}
