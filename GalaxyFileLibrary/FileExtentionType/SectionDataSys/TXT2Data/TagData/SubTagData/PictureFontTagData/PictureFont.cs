using GalaxyFileLibrary.FileExtentionType.SectionDataSys.TXT2Data.TagData.SystemTagData;
using GalaxyFileStreamSupportSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyFileLibrary.FileExtentionType.SectionDataSys.TXT2Data.TagData.SubTagData.PictureFontTagData
{
    public class PictureFont : ISubCategory
    {
        private readonly Dictionary<string, string> _pictureFont = new Dictionary<string, string>()
        {
            { "000E000300350002003A" , "CometMedal" }
        };

        public string TagText { get; private set; }

        public void Read(BinaryReader br)
        {
            string checkBytesString = "000E0003";
            checkBytesString += BigEndian.ReadUInt16(br).ToString("X4");
            checkBytesString += BigEndian.ReadUInt16(br).ToString("X4");
            checkBytesString += BigEndian.ReadUInt16(br).ToString("X4");

            string tagData = _pictureFont[checkBytesString];

            TagText = $"<PictureFont=\"{tagData}\">";
        }
    }
}
