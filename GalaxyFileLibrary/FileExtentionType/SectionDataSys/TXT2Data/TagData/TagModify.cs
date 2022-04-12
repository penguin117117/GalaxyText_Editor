using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GalaxyFileLibrary.FileExtentionType.SectionDataSys.TXT2Data.TagData
{
    public class TagModify
    {
        private readonly Dictionary<byte, ITagData> _tagDictionary = new Dictionary<byte, ITagData>
        {
            { 0x00 , new SystemTag() }
        };

        public string Read(BinaryReader br)
        {
            byte[] CategoryByte = br.ReadBytes(2);

            return _tagDictionary[CategoryByte[1]].Read(br);
        }
    }
}
