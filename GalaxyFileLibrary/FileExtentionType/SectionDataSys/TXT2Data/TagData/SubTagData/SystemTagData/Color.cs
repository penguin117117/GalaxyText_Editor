using GalaxyFileLibrary.FileExtentionType.SectionDataSys.TXT2Data.TagData.SystemTagData;
using GalaxyFileStreamLibrary;
using GalaxyFileStreamSupportSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyFileLibrary.FileExtentionType.SectionDataSys.TXT2Data.TagData.SubTagData.SystemTagData
{
    /*
     000E0000
     00030002
     0001
     */
    class Color : ISubCategory
    {
        public string TagText { get; private set; }

        public readonly Dictionary<uint, string> 
            ColorNoPairs = new Dictionary<uint, string> 
            {
                { 0x0000 , "<Color=\"Black\">"   },
                { 0x0001 , "<Color=\"Red\">"     },
                { 0x0002 , "<Color=\"Green\">"   },
                { 0x0003 , "<Color=\"Blue\">"    },
                { 0x0004 , "<Color=\"Yellow\">"  },
                { 0x0005 , "<Color=\"Purple\">"  },
                { 0x0006 , "<Color=\"Orange\">"  },
                { 0x0007 , "<Color=\"Gray\">"    },
                { 0xFFFF , "</Color>"            }
            };

        public void Read(BinaryReader br)
        {
            byte[] stringBytes = br.ReadBytes(2);

            var colorNo = BigEndian.ReadUInt16(br);

            TagText = ColorNoPairs[colorNo];
        }
    }
}
