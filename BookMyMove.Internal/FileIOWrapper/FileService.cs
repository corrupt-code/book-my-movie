using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BookMyMovie.Internal.FileIOWrapper
{
    public class FileService : IFileService
    {
        public bool CanRead(string path)
        {
            try
            {
                File.Open(path, FileMode.Open, FileAccess.Read).Dispose();
                return true;
            }
            catch (IOException)
            {
                return false;
            }
        }

        public bool Exists(string path)
        {
            return File.Exists(path);
        }

        public string Read(string path)
        {
            return File.ReadAllText(path);
        }
    }
}
