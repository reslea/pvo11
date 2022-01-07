namespace FileReader
{
    public static class ReaderFactory
    {
        public static IReadyToWorkReader? GetReadyToWorkReader(string fileName)
        {
            return File.Exists(fileName)
                ? new ReadyToWorkReader(fileName)
                : null;
        }

        public static FileReader? GetFileReader(string fileName)
        {
            return File.Exists(fileName)
                ? new FileReader(fileName)
                : null;
        }
    }
}
