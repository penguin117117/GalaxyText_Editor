using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GalaxyFileLibrary.FileExtentionType.SectionDataSys.LBL1Data
{
    public interface ILBL1
    {
        void Read(BinaryReader br);
        LabelEntries LabelEntries { get; }
        LabelNameEntries LabelNameEntries { get; }
    }
}
