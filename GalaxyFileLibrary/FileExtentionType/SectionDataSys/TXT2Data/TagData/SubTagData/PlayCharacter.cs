using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using GalaxyFileStreamLibrary;
using GalaxyFileLibrary.FileExtentionType.SectionDataSys.TXT2Data.TagData.SystemTagData;

namespace GalaxyFileLibrary.FileExtentionType.SectionDataSys.TXT2Data.TagData.SubTagData
{
    public class PlayCharacter : ISubCategory
    {
        public string TagText { get; private set; }

        public void Read(BinaryReader br)
        {
            byte[] stringBytes = br.ReadBytes(4);

            TagText = $"[PlayCharacter]";

            //Console.WriteLine(TagText);
        }
    }
}
