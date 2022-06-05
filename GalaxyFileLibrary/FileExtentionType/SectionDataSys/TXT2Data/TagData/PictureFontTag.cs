using GalaxyFileLibrary.FileExtentionType.SectionDataSys.TXT2Data.TagData.SubTagData.PictureFontTagData;
using GalaxyFileLibrary.FileExtentionType.SectionDataSys.TXT2Data.TagData.SystemTagData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyFileLibrary.FileExtentionType.SectionDataSys.TXT2Data.TagData
{
    public class PictureFontTag : ITagData
    {
        private readonly Dictionary<byte, ISubCategory> _pictureFontTagSubCategory = new Dictionary<byte, ISubCategory>()
        {
            //{ 0x00 , new SoundEffect() }
        };

        public ISubCategory SubCategory { get; private set; }

        public void Read(BinaryReader br)
        {
            //byte[] subCategoryBytes = br.ReadBytes(2);

            SubCategory = new PictureFont();

            SubCategory.Read(br);
        }
    }
}
