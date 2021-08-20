using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace IOFilePrac
{
    class Practice
    {
        static void Main(string[] args)
        {
            try
            {

                string path = @"D:\";
                string fileName = "demo.json";
                string toCreate = path + fileName;

                List<Hashtable> register = new List<Hashtable>() {
                    new Hashtable() { { "Name", "Abhishek Bhovar" }, { "Mobile", 8454008905 } },
                    new Hashtable() { { "Name", "Rahul Singh" }, { "Mobile", 8923457599 } },
                    new Hashtable() { { "Name", "Bhumesh Bhodalia" }, { "Mobile", 8647378382 } },
                    new Hashtable() { { "Name", "Sarvesh Adekar" }, { "Mobile", 6323565165 } },
                };

                DirectoryInfo dirInfo = new DirectoryInfo(path);
                Console.WriteLine($"Full Name : {dirInfo.FullName}");
                Console.WriteLine($"Name : {dirInfo.Name}\n");
            
                DirectoryInfo[] subDirs = dirInfo.GetDirectories();

                Console.WriteLine("");
                foreach (var dir in subDirs)
                {                
                    FileInfo[] files = dir.GetFiles();
                    if (files.Length > 0)
                    {
                        Console.WriteLine($"------------------<{dir.Name}>----------------");
                        foreach (var file in files)
                        {
                            Console.WriteLine(file.Name);
                        }
                        Console.WriteLine($"------------------<*******>----------------");
                    }
                }

                // for writing to the file 
                /*using(FileStream fs = new FileStream(toCreate, FileMode.Create, FileAccess.Write)) // where and how to write 
                {
                    using(StreamWriter sw = new StreamWriter(fs)) // StreamWriter writes the stream to file we want it to write to 
                    {
                        foreach (var record in register)
                        {
                            foreach (var person in record.Keys)
                            {
                                sw.WriteLine($"{person} : {record[person]}");
                            }
                            sw.WriteLine();
                            Console.WriteLine();
                        }
                    }
                }*/
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            Console.WriteLine("Created file successfully");
            return;
        }
    }
}
