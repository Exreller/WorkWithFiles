using System;
using System.IO;

namespace Task2
{
    public static class DirectoryExtention
    {
        public static long Dirsize(DirectoryInfo directory)
        {
            long size = 0;
            try
            {
                
                FileInfo[] fileInfos = directory.GetFiles();
                foreach (FileInfo fi in fileInfos)
                {
                    size += fi.Length;
                }

                DirectoryInfo[] directoryInfos = directory.GetDirectories();
                foreach (DirectoryInfo di in directoryInfos)
                {
                    size += Dirsize(di);
                }               
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            return size;

        }
    }
}
