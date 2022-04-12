using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GalaxyFileLibrary.FileExtentionType.SectionDataSys.TXT2Data.TagData
{
    public interface ITagData
    {
        string Read(BinaryReader br);
    }
}
