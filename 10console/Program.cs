using System;
using System.IO;

namespace _10console
{
    class Program
    {
        static void Main(string[] args)
        {
            
            if (!Directory.Exists("C:\\temp"))
            {
                Directory.CreateDirectory("C:\\temp");
            }
            Directory.CreateDirectory("C:\\temp\\K1");
            Directory.CreateDirectory("C:\\temp\\K2");
            
            StreamWriter sw = new StreamWriter("C:\\temp\\K1\\t1.txt");
            sw.Write("Иванов Иван Иванович, 1965 года рождения, место жительства г. Саратов");
            sw.Close();
            
            sw = new StreamWriter("C:\\temp\\K1\\t2.txt");
            sw.Write("Петров Сергей Федорович, 1966 года рождения, место жительства г.Энгельс");
            sw.Close();
            
            sw = new StreamWriter("C:\\temp\\K2\\t3.txt");
            StreamReader sr = new StreamReader("C:\\temp\\K1\\t1.txt");
            sw.WriteLine(sr.ReadToEnd());
            sr.Close();
            sr = new StreamReader("C:\\temp\\K1\\t2.txt");
            sw.WriteLine(sr.ReadToEnd());
            sr.Close();
            sw.Close();
            
            DirectoryInfo[] directoryInf = { new DirectoryInfo("C:\\temp\\K1"), new DirectoryInfo("C:\\temp\\K2") };
            foreach (var item in directoryInf)
            {
                FileInfo[] fileInf = item.GetFiles();
                foreach (FileInfo fI in fileInf)
                {
                    Console.WriteLine("Конечный путь: " + fI.FullName.ToString() + " Атрибуты: " + fI.Attributes.ToString() + " Время создания: " + fI.CreationTimeUtc.ToString());
                }
            }
            Console.WriteLine("--------------------");
            
            File.Move("C:\\temp\\K1\\t2.txt", "C:\\temp\\K2\\t2.txt");
            
            File.Copy("C:\\temp\\K1\\t1.txt", "C:\\temp\\K2\\t1.txt");
            
            Directory.Move("C:\\temp\\K2", "C:\\temp\\ALL");
            Directory.Delete("C:\\temp\\K1", true);
            
            DirectoryInfo directoryInfo = new DirectoryInfo("C:\\temp\\ALL");
            FileInfo[] fileInfo = directoryInfo.GetFiles();
            foreach (FileInfo fI in fileInfo)
            {
                Console.WriteLine("Конечный путь: " + fI.FullName.ToString() + " Атрибуты: " + fI.Attributes.ToString() + " Время создания: "+ fI.CreationTimeUtc.ToString());
            }

        }
    }
}
