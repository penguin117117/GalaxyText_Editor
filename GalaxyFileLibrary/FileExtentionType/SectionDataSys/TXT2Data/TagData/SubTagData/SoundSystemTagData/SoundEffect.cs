using GalaxyFileLibrary.FileExtentionType.SectionDataSys.TXT2Data.TagData.SystemTagData;
using GalaxyFileStreamSupportSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxyFileStreamLibrary;

namespace GalaxyFileLibrary.FileExtentionType.SectionDataSys.TXT2Data.TagData.SubTagData.SoundSystemTagData
{
    public class SoundEffect : ISubCategory
    {
        public string TagText { get; private set; }

        public void Read(BinaryReader br)
        {
            var bytes = br.ReadBytes(2);

            var readCharsCount = bytes[1];

            var soundEffectName = ReadString.FromBinaryRead(br,readCharsCount);

            TagText = $"<SE=\"{soundEffectName}\">";
        }
    }
}
