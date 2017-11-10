using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace LearnIO
{
    class Program
    {
        static void Main(string[] args)
        {
            Task t1 = Task.Factory.StartNew(()=>DriveInfoDemo());
            //DirectorInfoDemo();
            Task t2 = Task.Factory.StartNew(() => StreamWriterDemo());
            Task t3 = Task.Factory.StartNew(() => BinaryWriterDemo());
            Task t4 = Task.Factory.StartNew(() => Serialize()).
                ContinueWith((t) => Deserialize());
            Task<long> t5 = GetFileLengthAsync(@"c:\samples\MyTest.txt");
            Task[] allTasks = new Task[] { t1, t2, t3, t4};
            Task.WaitAll(allTasks);
            long t5result = t5.Result;
            Console.WriteLine("All done, Press any key to close the program");
            Console.ReadLine();
        }

        static void Serialize()
        {
            // Create a hashtable of values that will eventually be serialized.
            Hashtable addresses = new Hashtable();
            addresses.Add("Jeff", "123 Main Street, Redmond, WA 98052");
            addresses.Add("Fred", "987 Pine Road, Phila., PA 19116");
            addresses.Add("Mary", "PO Box 112233, Palo Alto, CA 94301");

            // To serialize the hashtable and its key/value pairs,  
            // you must first open a stream for writing. 
            // In this case, use a file stream.
            FileStream fs = new FileStream("DataFile.dat", FileMode.Create);

            // Construct a BinaryFormatter and use it to serialize the data to the stream.
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, addresses);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
        }
        static void Deserialize()
        {
            // Declare the hashtable reference.
            Hashtable addresses = null;

            // Open the file containing the data that you want to deserialize.
            FileStream fs = new FileStream("DataFile.dat", FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();

                // Deserialize the hashtable from the file and 
                // assign the reference to the local variable.
                addresses = (Hashtable)formatter.Deserialize(fs);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }

            // To prove that the table deserialized correctly, 
            // display the key/value pairs.
            foreach (DictionaryEntry de in addresses)
            {
                Console.WriteLine("{0} lives at {1}.", de.Key, de.Value);
            }
        }

        private static void BinaryWriterDemo()
        {
            using (FileStream fs = new FileStream(@"c:\samples\MyTest.bin", FileMode.OpenOrCreate))
            {
                BinaryWriter bw = new BinaryWriter(fs);
                int x = 100; decimal y = 3000;
                bw.Write(x);
                bw.Write(y);
                bw.Flush();
            }
            using (FileStream fs = new FileStream(@"c:\samples\MyTest.bin", FileMode.OpenOrCreate))
            {
                BinaryReader br = new BinaryReader(fs);
                int x = br.ReadInt32(); decimal y = br.ReadDecimal();
                Console.WriteLine($"x: {x} ; y:{y}");
            }
        }

        private static void StreamWriterDemo()
        {
            string path = @"c:\samples\MyTest.txt";


            // Delete the file if it exists.
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            //Create the file.
            using (FileStream fs = File.Create(path))
            {
                StreamWriter sw = new StreamWriter(fs, new UTF8Encoding(true));
               
                    sw.WriteLine("This is some text");
                    sw.WriteLine("This is some more text,");
                    sw.WriteLine("\r\nand this is on a new line");
                    sw.WriteLine("\r\n\r\nThe following is a subset of characters:\r\n");

                    for (int i = 1; i < 120; i++)
                    {
                        sw.Write(Convert.ToChar(i).ToString());
                    }
                    sw.Flush();
              
            }

            //Open the stream and read it back.
            using (FileStream fs = File.OpenRead(path))
            {
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);
                lock (Console.Out)
                {
                    while (fs.Read(b, 0, b.Length) > 0)
                    {
                        Console.WriteLine(temp.GetString(b));
                    }
                }
            }
        }

        private static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }

        private static void DirectorInfoDemo()
        {
            DirectoryInfo d = new DirectoryInfo(@"C:\");
            foreach (var item in d.EnumerateDirectories())
            {
                Console.WriteLine($"{item.FullName} - {item.LastWriteTime}");
            }
        }

        private static void DriveInfoDemo()
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            lock (Console.Out) {
            foreach (DriveInfo d in allDrives)
            {
                Console.WriteLine("Drive {0}", d.Name);
                Console.WriteLine("  Drive type: {0}", d.DriveType);
                if (d.IsReady == true)
                {
                    Console.WriteLine("  Volume label: {0}", d.VolumeLabel);
                    Console.WriteLine("  File system: {0}", d.DriveFormat);
                    Console.WriteLine(
                        "  Available space to current user:{0, 15} bytes",
                        d.AvailableFreeSpace);

                    Console.WriteLine(
                        "  Total available space:          {0, 15} bytes",
                        d.TotalFreeSpace);

                    Console.WriteLine(
                        "  Total size of drive:            {0, 15} bytes ",
                        d.TotalSize);
                }
            }
            }
        }

        private static async Task<long> GetFileLengthAsync(string FileName)
        {
            return await Task<long>.Run(() => {
                FileInfo aFile = new FileInfo(FileName);
                System.Threading.Thread.Sleep(10000);
                return aFile.Length;
            }//end the delegate lambda
            );//end the Run Method
        }
    }
}
