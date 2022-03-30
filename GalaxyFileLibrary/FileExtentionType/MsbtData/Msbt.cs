using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using GalaxyFileLibrary.FileExtentionType.SectionDataSys.LBL1Data;

namespace GalaxyFileLibrary.FileExtentionType.MsbtData
{
    public class Msbt
    {
        public IMSB_X_Header Header => _msbtHeader;
        public ILBL1 LBL1 => _lbl1;

        private IMSB_X_Header _msbtHeader;
        private ILBL1 _lbl1;
        private byte[] OldBinaryData;

        public Msbt(byte[] binData) 
        {
            _msbtHeader = new MsbtHeader();

            

            //HeaderRead(binData);
            _lbl1 = new LBL1();
            OldBinaryData = binData;
        }

        public void Load() 
        {
            //byte[] magic = new byte[8];
            //Array.Copy(OldBinaryData, magic, 8);
            //var str = Encoding.ASCII.GetString(magic);
            //Console.WriteLine(str);
            
            using (MemoryStream ms = new MemoryStream(OldBinaryData)) 
            {
                using (BinaryReader br = new BinaryReader(ms)) 
                {
                    _msbtHeader.Read(br);
                };
            } ;
        }
        

        private void HeaderRead(byte[] binData) 
        {
            bool IsSupportType = true;
            MemoryStream ms = new MemoryStream(binData);
            BinaryReader br = new BinaryReader(ms);
            var magic = Encoding.ASCII.GetString(br.ReadBytes(8));
            Console.WriteLine("Magic: " + magic);
            if (magic != _msbtHeader.Magic) IsSupportType = false;
            br.Close();
            ms.Close();

            if (!IsSupportType)
            {
                Console.WriteLine("***********************************");
                Console.WriteLine("Unsupported Msbt file.\n");
                Console.WriteLine("Supported" + ": " + _msbtHeader.Magic);
                Console.WriteLine("This File" + ": " + magic);
                Console.WriteLine("***********************************");
                throw new Exception("");
            }
                
        }
        

    }
}
