using System;
using System.IO;
using System.Threading;

namespace Homework11_2
{
    class Program
    {
        public static string destinationFile = "DestinationFile.txt";

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string sourseFile1 = "FirstSourceFile.txt";
            string sourseFile2 = "SecondSourceFile.txt";
            

            FileCreator(sourseFile1);
            FileCreator(sourseFile2);

            ParameterizedThreadStart p_thread1 = new ParameterizedThreadStart(FileCopy);
            Thread thread1 = new Thread(p_thread1);
            thread1.Start(sourseFile1);
            thread1.Join();

            ParameterizedThreadStart p_thread2 = new ParameterizedThreadStart(FileCopy);
            Thread thread2 = new Thread(p_thread2);
            thread2.Start(sourseFile2);
            thread2.Join();


            Console.WriteLine($"Data was saved successfully in {destinationFile}");


            Console.ReadKey();

        }


        



        static void FileCreator(string fileName)
        {
            var file = new FileInfo(fileName);

            StreamWriter writer = file.CreateText();

            for (int i = 0; i < 10; i++)
            {
                writer.WriteLine(fileName);
            }
            writer.Close();
        }



        static void FileCopy(object fileName)
        {
            Console.WriteLine((string)fileName);
            
            var reader = new StreamReader((string)fileName);
            var writer = new StreamWriter(destinationFile, append: true);

            
            writer.WriteLine(reader.ReadToEnd());
            writer.Close();

        }



    }
}
