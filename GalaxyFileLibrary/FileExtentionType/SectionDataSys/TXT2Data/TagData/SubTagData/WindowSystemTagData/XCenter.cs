using GalaxyFileLibrary.FileExtentionType.SectionDataSys.TXT2Data.TagData.SystemTagData;
using GalaxyFileStreamSupportSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyFileLibrary.FileExtentionType.SectionDataSys.TXT2Data.TagData.SubTagData.WindowSystemTagData
{
    class XCenter : ISubCategory
    {
        public string TagText { get; private set; }

        public void Read(BinaryReader br)
        {
            if (BigEndian.ReadUInt16(br) == 0x0000)
            {
                TagText = "</XCenter>";
                return;
            }
        }
    }
}
