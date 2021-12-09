using System.Reflection;

namespace Serialization
{
    public class JsonReflectionConvert
    {
        public static string Serialize(object source)
        {
            PropertyInfo[] propertyInfos = source.GetType().GetProperties();

            string result = "{";
            for (int i = 0; i < propertyInfos.Length; i++)
            {
                PropertyInfo propInfo = propertyInfos[i];

                bool hasGetter = propInfo.GetMethod != null;
                bool isLastProp = i == propertyInfos.Length - 1;

                if (hasGetter)
                {
                    var value = propInfo.GetValue(source);
                    result += SerializeProperty(propInfo.Name, value, isLastProp);
                }
            }

            return result += "}";
        }

        private static string SerializeProperty(string propName, object? propValue, bool isLast = false)
        {
            string propEnding = isLast ? "" : ",";
            return $"\"{propName}\":{SerializePropValue(propValue)}{propEnding}";
        }

        private static string SerializePropValue(object propValue)
        {
            return propValue switch
            {
                null => "",
                string => $"\"{(string)propValue}\"",
                bool => propValue.ToString()!.ToLower(),
                _ => propValue?.ToString()!
            };
        }
    }
}