namespace alltdl.Services
{
    public interface IFileService
    {
        /// <inheritdoc cref="Directory.EnumerateFiles(string)"/>
        IEnumerable<string> EnumerateFiles(string path);
    }

    public class FileService : IFileService
    {
        /// <inheritdoc/>
        public IEnumerable<string> EnumerateFiles(string path)
        {
            return Directory.EnumerateFiles(path, "", SearchOption.AllDirectories);
        }
    }
}