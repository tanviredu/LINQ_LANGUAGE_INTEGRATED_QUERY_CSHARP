using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;

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
        }

        private static void ShowLargeFileWithoutLinq(string path)
        {

            // we get the file info from a file.io
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles();
            // now we need to sort the files
            // but before sort the array
            // you need to pass a icomparable
            // object that is used to compare the file 
            // to sort
            // and it will sort in the assending order


            Array.Sort(files,new FileInfoComparer());

            // now we want to print the first 5 file
            // of the system
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
    }

    public class FileInfoComparer : IComparer<FileInfo>
    {
        // we are comparing the FileInfo object
        // based on the length of the file
        // you need to pass the object of the file
        // to the Array.sort() method
        // this will help this array sort()
        // method to compare the file

        // this 
        public int Compare(FileInfo file1, FileInfo file2)
        {
            // this will help to sort the array in assending 
            // order
            //return file1.Length.CompareTo(file2.Length);
            return file2.Length.CompareTo(file1.Length);
        }

        
    }
}
