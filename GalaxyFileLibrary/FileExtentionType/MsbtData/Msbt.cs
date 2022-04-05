﻿using System;
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
            _lbl1 = new LBL1();
            OldBinaryData = binData;
        }

        public void Load() 
        {
            using (MemoryStream ms = new MemoryStream(OldBinaryData)) {

                using (BinaryReader br = new BinaryReader(ms)) {

                    _msbtHeader.Read(br);
                    _lbl1.Read(br);
                };
            } ;
        }
        

        private void HeaderRead(byte[] binData) 
        {
            bool isSupportType = true;
            string magic;

            using (MemoryStream ms = new MemoryStream(binData)) {
                
                using (BinaryReader br = new BinaryReader(ms)) {

                    magic = Encoding.ASCII.GetString(br.ReadBytes(8));
                };
            } ;


            Console.WriteLine("Magic: " + magic);

            if (magic != _msbtHeader.Magic) { 
                isSupportType = false; 
            }

            if (!isSupportType) {
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