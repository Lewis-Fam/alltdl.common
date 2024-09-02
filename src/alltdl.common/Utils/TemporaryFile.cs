using System;
using System.Diagnostics;
using System.IO;

namespace alltdl.Utils
{
    public sealed class TemporaryFile : IDisposable
    {
        public TemporaryFile() : this(Path.GetTempPath()) { }

        public TemporaryFile(string directory)
        {
            Create(Path.Combine(directory, Path.GetRandomFileName()));
        }

        ~TemporaryFile()
        {
            Delete();
        }

        public void Dispose()
        {
            Delete();
            GC.SuppressFinalize(this);
        }

        public string FilePath { get; private set; }
        
        public string Read()
        {
            return File.Exists(FilePath) ? File.ReadAllText(FilePath) : throw new FileNotFoundException(FilePath);
        }

        private void Create(string path)
        {
            FilePath = path;
            Debug.WriteLine($"TemporaryFile: {FilePath}");
            using (File.Create(FilePath)) { }
        }

        private void Delete()
        {
            if (FilePath == null) return;
            File.Delete(FilePath);
            FilePath = null;
        }
    }
}