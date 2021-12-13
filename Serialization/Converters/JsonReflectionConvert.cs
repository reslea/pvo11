using System.Reflection;
using System.Collections;

namespace Serialization.Converters
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
            string propEnding = isLast ? string.Empty : ",";
            return $"\"{propName}\":{SerializePropValue(propValue)}{propEnding}";
        }

        private static string SerializePropValue(object propValue)
        {
            if (propValue == null)
                return "null";

            Type propType = propValue.GetType();

            bool isBuiltInType = propType.IsPrimitive
                || propType == typeof(string)
                || propType == typeof(DateTime);

            if (isBuiltInType)
            {
                return propValue switch
                {
                    string => $"\"{(string)propValue}\"",
                    bool => propValue.ToString()!.ToLower(),
                    DateTime dateProp => $"\"{dateProp.ToString("yyyy-MM-ddTHH:mm:ss")}\"",
                    _ => propValue.ToString()!
                };
            }

            //if (propValue is IEnumerable enumerableProp)
            if (propValue is IEnumerable)
            {
                IEnumerable enumerableProp = (IEnumerable)propValue;

                string result = "[";

                foreach (object item in enumerableProp)
                {
                    result += $"{Serialize(item)},";
                }

                result = result.Substring(0, result.Length - 1);

                return result += "]";
            }

            return Serialize(propValue);
        }
    }
}