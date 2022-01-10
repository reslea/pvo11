
namespace FileReader
{
    public interface IReader
    {
        IEnumerable<string> GetJsonLines();
    }
}