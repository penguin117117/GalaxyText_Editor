using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using GalaxyFileStreamLibrary;

namespace GalaxyFileLibrary.FileExtentionType.SectionDataSys.TXT2Data.TagData.SystemTagData
{
    public class Ruby : ISubCategory
    {
        public string TagText { get; private set; }

        public void Read(BinaryReader br)
        {
            byte[] stringBytes = br.ReadBytes(6);

            var ruby     = (stringBytes[5] >> 1);
            var kanji    = (stringBytes[3] >> 1);

            var rubyStr  = Encoding.GetEncoding(EncodingName.UTF16_Bigendian).GetString(br.ReadBytes(ruby*2));
            var kanjiStr = Encoding.GetEncoding(EncodingName.UTF16_Bigendian).GetString(br.ReadBytes(kanji*2));

            TagText = $"[ふりがな=\"{rubyStr}\" 対象の文字=\"{kanjiStr}\"]";

            Console.WriteLine(TagText);
        }
    }
}
