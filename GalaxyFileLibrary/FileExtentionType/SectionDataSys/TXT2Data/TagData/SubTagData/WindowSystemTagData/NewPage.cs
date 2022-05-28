using GalaxyFileLibrary.FileExtentionType.SectionDataSys.TXT2Data.TagData.SystemTagData;
using GalaxyFileStreamSupportSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyFileLibrary.FileExtentionType.SectionDataSys.TXT2Data.TagData.SubTagData.WindowSystemTagData
{
    /*
     000E0001
     00010000

     000E0001
     00010000
     000A
     */
    public class NewPage : ISubCategory
    {
        public string TagText { get; private set; }

        public void Read(BinaryReader br)
        {
            var newPageOrNormalCenterData = BigEndian.ReadUInt16(br);

            if (newPageOrNormalCenterData != 0x0000) 
                throw new Exception("未対応のタグが検出されました");

            if (IsNewPage(br)) 
            {
                TagText = "</NewPage>"; 
            }    
            else
            {
                TagText = "</NCenter>";
            }
        }

        /// <summary>
        /// 「NormalCenter」と「NewPage」を区別するための処理<br/>
        /// 「000E000100010000」と「000E000100010000000A」を区別するための処理
        /// </summary>
        /// <param name="br"></param>
        /// <returns></returns>
        private bool IsNewPage(BinaryReader br) 
        {
            UInt16 checkNewPage = BigEndian.ReadUInt16(br);

            if (checkNewPage == 0x000A) 
                return true;

            //0x000Aを判別するために読み込んだ2バイト分バイナリリードを戻す。
            br.BaseStream.Position = br.BaseStream.Position - 2;
            return false;
        }
    }
}
