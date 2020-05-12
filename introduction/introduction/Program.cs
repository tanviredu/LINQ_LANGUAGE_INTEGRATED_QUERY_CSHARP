using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;

namespace introduction
{
    class Program
    {
        static void Main(string[] args)
        {
            // linq project
            // search the biggest file 
            // in  folder with ot without usin linq
            string path = @"C:\windows";
            ShowLargeFileWithoutLinq(path);
            Console.WriteLine("**************************");
            ShowLargeFileWithLinq(path);
        }

        
        private static void ShowLargeFileWithoutLinq(string path)
        {

            // we get the file info from a file.io
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles();
            Array.Sort(files,new FileInfoComparer());
            int i = 1;
            foreach (var file in files)
            {
                Console.WriteLine($"Name :{file.Name,-20} size:{file.Length,10:N0} ");
                if (i == 5)
                {
                    break;
                }

                i++;


            
            } // we get the name and the size from the file

        }
        private static void ShowLargeFileWithLinq(string path)
        {
            // same job with linq
            // make a query
            var query = from file in new DirectoryInfo(path).GetFiles() orderby file.Length descending select file;

            // now we get all the file with this query after he execution

            foreach (var file in query.Take(5))
            {
                Console.WriteLine($"Name :{file.Name,-20} size:{file.Length,10:N0} ");
            }
        }

    }

    public class FileInfoComparer : IComparer<FileInfo>
    {


        // this 
        public int Compare(FileInfo file1, FileInfo file2)
        {
            return file2.Length.CompareTo(file1.Length);
        }

        
    }
}
