using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReader
{
    public class JsonReader : IJsonReader
    {
        private IReader fileReader;

        public JsonReader(IReader fileReader)
        {
            this.fileReader = fileReader;
        }

        public IEnumerable<Hero> GetHeroes()
        {
            IEnumerable<string> jsonStrings;
            try
            {
                jsonStrings = fileReader.GetJsonLines();
            }
            catch
            {
                yield break;
            }

            foreach (var heroJson in jsonStrings)
            {
                Hero hero = (Hero)JsonManualConvert_Serialize
                    .Deserialize(heroJson, typeof(Hero));

                yield return hero;
            }
        }
    }
}
