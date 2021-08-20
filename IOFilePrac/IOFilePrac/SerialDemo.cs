using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;
using Newtonsoft.Json; 
using System.IO;

namespace IOFilePrac
{
    class SerialDemo
    {

        /*
         * Common thing in serialization is use of StreamWriter and the Serializable object 
         * We have to open the stream writer first to create a file we want 
         * next we need the type of serializer we want to convert the object too
         * types of serializers -> binary, JSON, XML, soap
         * Formatters have binary and soap 
         * for JSON and XML we need different name spaces
         * Binary Formatter -> System.Runtime.Serialization.Formatters.Binary
         * SOAP Formatter -> System.Runtime.Serialization.Formatters.Soap
         * 
         * JSON -> Newtonsoft.json{project -> manage nugget package -> browse -> install newtonsoft.json}
         * XML -> System.xml.Serialization
         * 
         */
        static void Main()
        {
            string binPath = @"D:\capgemini\training\Practice\IOFilePrac\IOFilePrac\mv.bin";
            string soapPath = @"D:\capgemini\training\Practice\IOFilePrac\IOFilePrac\mv.soap";
            string xmlPath = @"D:\capgemini\training\Practice\IOFilePrac\IOFilePrac\mv.xml";
            
            // json can be stored in .josn and in .txt file hence 2 paths 
            string jsonPath = @"D:\capgemini\training\Practice\IOFilePrac\IOFilePrac\mv.json";
            string jsonPath2 = @"D:\capgemini\training\Practice\IOFilePrac\IOFilePrac\mv.json";

            MovieSerializable mv = new MovieSerializable { Director = "Wes Anderson", Name = "The Grand Budapest", Rating = 5 };
            BinaryFormatter bf = new BinaryFormatter();
            SoapFormatter sf = new SoapFormatter();

            #region Binary Formatting 
            using (FileStream fs = new FileStream(binPath, FileMode.Create, FileAccess.Write))
            {
                bf.Serialize(fs, mv); // where to write and what to write 
                Console.WriteLine("Done Bin Serializing");
            }

            using (FileStream fs = new FileStream(binPath, FileMode.Open, FileAccess.Read))
            {
                mv = bf.Deserialize(fs) as MovieSerializable;
                Console.WriteLine("Done Bin De-Serializing");
            }
            Console.WriteLine(mv);
            #endregion

            #region SOAP Formatting
            using (FileStream fs = new FileStream(soapPath, FileMode.Create, FileAccess.Write))
            {
                sf.Serialize(fs, mv); // where to write and what to write 
                Console.WriteLine("Done SOAP Serializing");
            }

            using (FileStream fs = new FileStream(soapPath, FileMode.Open, FileAccess.Read))
            {
                mv = sf.Deserialize(fs) as MovieSerializable;
                Console.WriteLine("Done SOAP De-Serializing");
            }
            Console.WriteLine(mv);
            #endregion

            #region XML Serialization
            // serializeable class has to be public for xml serialization 
            using(FileStream fs = new FileStream(xmlPath, FileMode.Create, FileAccess.Write)) // step 1 creating file stream  
            {
                XmlSerializer xs = new XmlSerializer(typeof(MovieSerializable));
                xs.Serialize(fs, mv);
                Console.WriteLine("Done XML Serializing");
            }

            using (FileStream fs = new FileStream(xmlPath, FileMode.Open, FileAccess.Read)) // step 1 creating file stream  
            {
                XmlSerializer xs = new XmlSerializer(typeof(MovieSerializable));
                mv = xs.Deserialize(fs) as MovieSerializable; // everytime we have to convert as the Deserializers return us objects
                Console.WriteLine("Done XML De-Serializing");
            }
            Console.WriteLine(mv);
            #endregion

            #region JSON Serialization .json file 
            using(StreamWriter sw = new StreamWriter(jsonPath)) // as JSON is type of text we need stream writer obj of the file we want to write to 
            {
                using (JsonWriter jw = new JsonTextWriter(sw)) // should always create an object for the JsonTextWriter as jsonWriter is abstract we can't create object of it 
                {
                    JsonSerializer js = new JsonSerializer();
                    js.Serialize(jw, mv);

                }
                Console.WriteLine("Done JSON Serializing");
            }

            using (StreamReader sr = new StreamReader(jsonPath)) // as JSON is type of text we need stream reader obj of the file we want to read 
            {
                using (JsonReader jr = new JsonTextReader(sr)) // should always create an object for the JsonTextReader as jsonReader is abstract we can't create object of it 
                {
                    JsonSerializer js = new JsonSerializer();
                    mv = js.Deserialize<MovieSerializable>(jr);// strictly use the generic Deserialize method for json 
                }
                Console.WriteLine("Done JSON De-Serializing");
            }
            Console.WriteLine(mv);
            #endregion

            #region JSON Serialization .txt file 
            using (StreamWriter sw = new StreamWriter(jsonPath2)) // as JSON is type of text we need stream writer obj of the file we want to write to 
            {
                using (JsonWriter jw = new JsonTextWriter(sw)) // should always create an object for the JsonTextWriter as jsonWriter is abstract we can't create object of it 
                {
                    JsonSerializer js = new JsonSerializer();
                    js.Serialize(jw, mv);

                }
                Console.WriteLine("Done JSON Serializing");
            }

            using (StreamReader sr = new StreamReader(jsonPath2)) // as JSON is type of text we need stream reader obj of the file we want to read 
            {
                using (JsonReader jr = new JsonTextReader(sr)) // should always create an object for the JsonTextReader as jsonReader is abstract we can't create object of it 
                {
                    JsonSerializer js = new JsonSerializer();
                    mv = js.Deserialize<MovieSerializable>(jr); // strictly use the generic Deserialize method for json 
                }
                Console.WriteLine("Done JSON De-Serializing");
            }
            Console.WriteLine(mv);
            #endregion
        }
    }
}
