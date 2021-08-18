using System;

namespace BookMyMovie.Internal.FileIOWrapper
{
    public interface IFileService
    {
        bool Exists(string path);
        bool CanRead(string path);
        string Read(string path);
    }
}
