using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReader
{
    public class JsonReader
    {
        private FileReader fileReader;

        public JsonReader(FileReader fileReader)
        {
            this.fileReader = fileReader;
        }

        public IEnumerable<Hero> GetHeroes()
        {
            IEnumerable<string> jsonStrings = fileReader.GetFileLines();
            foreach (var heroJson in jsonStrings)
            {
                Hero hero = (Hero)JsonManualConvert_Serialize
                    .Deserialize(heroJson, typeof(Hero));

                yield return hero;
            }
        }
    }
}
