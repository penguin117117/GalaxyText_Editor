using GalaxyFileLibrary.FileExtentionType.SectionDataSys.TXT2Data.TagData.SubTagData.SoundSystemTagData;
using GalaxyFileLibrary.FileExtentionType.SectionDataSys.TXT2Data.TagData.SystemTagData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyFileLibrary.FileExtentionType.SectionDataSys.TXT2Data.TagData
{
    public class SoundSystemTag : ITagData
    {
        private readonly Dictionary<byte, ISubCategory> _systemTagSubCategory = new Dictionary<byte, ISubCategory>()
        {
            { 0x00 , new SoundEffect() }
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
