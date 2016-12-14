using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace RSAToPEMConverter
{
    public class Converter
    {

        public static bool Convert(string xmlpath)
        {
            FileInfo fi = new FileInfo(xmlpath);
            if(fi.Extension.ToLower() != ".xml")
            {
                throw new FormatException("File is not an xml document");
            }
            Console.WriteLine("Checking File: {0}", fi.FullName);
            if (fi.Exists)
            {
                string xml = File.ReadAllText(fi.FullName);
                Console.WriteLine("Generating Pem");
                string pem = RsaKeyConverter.Converter.RsaKeyConverter.XmlToPem(xml);
                Console.WriteLine("Outputing Pem");
                FileInfo fp = new FileInfo(fi.FullName.Replace(fi.Extension, ".pem"));
                if(fp.Exists)
                {
                    Console.Write("Pem file already exists. Delete(y/n)?");
                    var key = Console.ReadKey();
                    if(key.KeyChar != 'y')
                    {
                        Console.WriteLine("\r\nFile already exists, cancelling conversion");
                        return false;
                    }
                    else
                    {
                        Console.WriteLine("\r\nDeleting existing pem file");
                    }

                }
                File.WriteAllText(fp.FullName, pem);
                Console.WriteLine("{0} successfully generated", fp.FullName);
                return true;
            }
            else
            {
                throw new FileNotFoundException("RSA XML file not found: " + xmlpath);
            }
        }
    }
}
