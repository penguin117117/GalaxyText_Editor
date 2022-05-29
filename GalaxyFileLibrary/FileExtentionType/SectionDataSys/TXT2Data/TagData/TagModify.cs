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
        public ITagData CategoryTag { get; private set; }

        private readonly Dictionary<byte, ITagData> _tagDictionary = new Dictionary<byte, ITagData>
        {
            { 0x00 , new SystemTag() },
            { 0x01 , new WindowSystemTag()},
            { 0x02 , new SoundSystemTag()},
            { 0x05 , new Tag05() }
        };

        public TagModify(BinaryReader br) 
        {
            byte[] CategoryByte = br.ReadBytes(2);

            CategoryTag = _tagDictionary[CategoryByte[1]];

            Read(br);
        }

        private void Read(BinaryReader br)
        {
            CategoryTag.Read(br);
        }
    }
}
