namespace Serialization;

public class JsonManualConvert
{
    public static string Serialize(Hero source)
    {
        var result = 
            "{" +
            SerializeProperty(nameof(Hero.FirstName), source.FirstName) +
            SerializeProperty(nameof(Hero.LastName), source.LastName) +
            SerializeProperty(nameof(Hero.Age), source.Age) +
            SerializeProperty(nameof(Hero.IsAvenger), source.IsAvenger, true) +
            "}";

        return result;
    }

    private static string SerializeProperty(string propName, object? propValue, bool isLast = false)
    {
        string propEnding = isLast ? "" : ",";
        return $"\"{propName}\":{SerializePropValue(propValue)}{propEnding}";
    }

    private static string SerializePropValue(object propValue)
    {
        //string propAsString;

        //if (propValue is string stringProp)
        //{
        //    propAsString = $"\"{stringProp}\"";
        //}
        //else if (propValue is bool boolProp)
        //{
        //    propAsString = boolProp.ToString().ToLower();
        //}
        //else
        //{
        //    propAsString = propValue.ToString();
        //};

        //switch (propValue)
        //{
        //    case string:
        //        propAsString = $"\"{(string)propValue}\"";
        //        break;
        //    case bool:
        //        propAsString = propValue.ToString().ToLower();
        //        break;
        //    default:
        //        propAsString = propValue?.ToString();
        //        break;
        //}

        if (propValue is null)
            return "";

        return propValue switch
        {
            string => $"\"{(string)propValue}\"",
            bool => propValue.ToString().ToLower(),
            _ => propValue.ToString()
        };
    }
}
