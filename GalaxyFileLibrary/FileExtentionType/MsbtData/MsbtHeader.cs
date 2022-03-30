﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace GalaxyFileLibrary.FileExtentionType.MsbtData
{
    

    public class MsbtHeader : IMSB_X_Header
    {
        private Dictionary<int, string> EncodingTypeSelect = new Dictionary<int, string>
        {
            { 0 ,"utf-8"},
            { 1 ,"utf-16"},
            { 2 ,"utf-32" },
            { 3 ,"utf-8"},
            { 4 ,"utf-16BE"},
            { 5 ,"utf-32BE" }
        };
        public string EncodingName { get; private set; }

        public string Magic { get; private set; }
        public ushort Endian { get; private set; }
        public ushort Padding1 { get; private set; }
        public byte   EncodingType { get; private set; }
        public byte   VerNum { get; private set; }
        public ushort SectionCount { get; private set; }
        public ushort Padding2 { get; private set; }
        public uint   FileSize { get; set; }
        public ushort[] Paddings { get; private set; }/* => new ushort[] { 0x0000, 0x0000, 0x0000, 0x0000, 0x0000 };*/
        

        public MsbtHeader() 
        {
            
            
            
        }

        public void Read(BinaryReader br) 
        {
            
            Magic = Encoding.ASCII.GetString(br.ReadBytes(8));

            byte[] tmp;
            tmp = br.ReadBytes(2);
            Array.Reverse(tmp);
            Endian = BitConverter.ToUInt16(tmp,0);

            Console.WriteLine("Target: " + Endian.ToString("X"));

            return;
            var Reverse = (ushort)~Endian;
            var EndianNum = (ushort)(((Reverse >> 8)) * 3);

            Console.WriteLine(EndianNum.ToString());

            EncodingName = EncodingTypeSelect[EndianNum + EncodingType];

            Console.WriteLine(EncodingName);
        }
    }
}
