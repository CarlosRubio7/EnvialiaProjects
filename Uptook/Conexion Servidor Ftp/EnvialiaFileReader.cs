﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uptook
{
    public class EnvialiaFileReader
    {
        public String readFile(String fileName)
        {
            try
            {   // Open the text file using a stream reader.
                //using (StreamReader sr = new StreamReader(fileName,Encoding.Default))
                using (StreamReader sr = new StreamReader(fileName, Encoding.Default))
                //using (StreamReader sr = new StreamReader(fileName))
                {
                    // Read the stream to a string, and write the string to the console.
                    String line = sr.ReadToEnd();
                    return line;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);

                return null;
            }
        }
    }
}
