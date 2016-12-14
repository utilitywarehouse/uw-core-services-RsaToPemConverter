using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace RSAToPEMConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length == 0)
                {
                    throw new ArgumentException("Requires xml file path");
                }
                else
                {
                    Converter.Convert(args[0]);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }

    }
}
