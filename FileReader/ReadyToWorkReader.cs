namespace FileReader
{
    public class ReadyToWorkReader : IReadyToWorkReader
    {
        private string _fileName;

        public ReadyToWorkReader(string fileName)
        {
            _fileName = fileName;
        }

        public IEnumerable<Hero> GetHeroes()
        {
            using StreamReader sr = new StreamReader(_fileName);

            while (!sr.EndOfStream)
            {
                string heroJson = sr.ReadLine()!;
                Hero hero = (Hero)JsonManualConvert_Serialize
                    .Deserialize(heroJson, typeof(Hero));

                yield return hero;
            }
        }
    }
}