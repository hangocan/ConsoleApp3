using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Xsl;

namespace ProgramChallenge
{
    public class Tasks
    {
        #region public method
        public static void XMLGenerator(string StartupPath, string LoadPath, string SavePath)
        {
            var numberpair = new List<NumberPair> { };
            numberpair = ReadConvert(LoadPath);
           
            //
            //Create XML
            XDocument xdoc = new XDocument(
           new XDeclaration("1.0", "utf-8", "yes"),
               new XElement("ConvertedNumbers",
                from e in numberpair
                select
                new XElement("NumberPair",
                new XElement("DecimalNumber", e.Decimal),
                new XElement("HexadecimalNumber", e.Hexadecimal))));
            xdoc.Save(SavePath);

        }

        public static void CSVGenerator(string startPath, string loadPath, string savePath)
        {
            var myXslTrans = new XslCompiledTransform();
            myXslTrans.Load(startPath + "\\stylesheet.xslt");
            myXslTrans.Transform(loadPath, savePath);

        }
        #endregion
        #region private method
        private static object convertHexInt(string input)
        {
            object result;
            var isNumeric = int.TryParse(input, out int decnum);

            if (isNumeric)
            {
                result = decnum.ToString("X");
            }

            else
            {
                result = int.Parse(input, System.Globalization.NumberStyles.HexNumber);
            }
            return result;
        }

        public static List<NumberPair> ReadConvert(string LoadPath)
        {
            string hex; int dec;
            string[] lines = System.IO.File.ReadAllLines(LoadPath);
            var numberpair = new List<NumberPair>{ };

            //
            //Prepare the data
            try
            {
                foreach (string line in lines)
                {
                    //var isNumeric = int.TryParse(line.ToString(), out dec);
                    //if (isNumeric)
                    //{
                    //    hex = convertHexInt(dec.ToString()).ToString();
                    //}
                    //else
                    //{
                    //    hex = line.ToString();
                    //    Int32.TryParse(convertHexInt(hex).ToString(), out dec);
                    //}

                    dec = int.Parse(line.ToString());

                    hex = convertHexInt(dec.ToString()).ToString();

                    numberpair.Add(new NumberPair
                    {
                        Decimal = dec,
                        Hexadecimal = hex
                    });
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Only Decimal number is allowed");
            }
            return numberpair;

        }

        #endregion
    }
}
