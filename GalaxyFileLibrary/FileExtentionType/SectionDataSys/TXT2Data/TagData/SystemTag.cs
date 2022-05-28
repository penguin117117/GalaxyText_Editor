using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using GalaxyFileLibrary.FileExtentionType.SectionDataSys.TXT2Data.TagData.SystemTagData;
using GalaxyFileLibrary.FileExtentionType.SectionDataSys.TXT2Data.TagData.SubTagData.SystemTagData;

namespace GalaxyFileLibrary.FileExtentionType.SectionDataSys.TXT2Data.TagData
{
    public class SystemTag : ITagData
    {
        private readonly Dictionary<byte, ISubCategory> _systemTagSubCategory = new Dictionary<byte, ISubCategory>()
        {
            { 0x00 , new Ruby()  },
            { 0x03 , new Color() }
        }; 

        public ISubCategory SubCategory { get; private set; }

        public void Read(BinaryReader br)
        {
            byte[] subCategoryBytes = br.ReadBytes(2);

            SubCategory = _systemTagSubCategory[subCategoryBytes[1]];

            SubCategory.Read(br);
        }
    }
}
