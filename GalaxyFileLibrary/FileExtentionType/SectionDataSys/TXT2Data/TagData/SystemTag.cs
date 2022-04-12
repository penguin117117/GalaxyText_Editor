using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using GalaxyFileLibrary.FileExtentionType.SectionDataSys.TXT2Data.TagData.SystemTagData;

namespace GalaxyFileLibrary.FileExtentionType.SectionDataSys.TXT2Data.TagData
{
    public class SystemTag : ITagData
    {
        private readonly Dictionary<byte, ISystemTagSubCategory> _systemTagSubCategory = new Dictionary<byte, ISystemTagSubCategory>()
        {
            { 0x00 , new Ruby() }
        };

        public string Read(BinaryReader br)
        {
            byte[] subCategory_2Byte = br.ReadBytes(2);

            return _systemTagSubCategory[subCategory_2Byte[1]].Read(br);
        }
    }
}
