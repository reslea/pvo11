using Serialization.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Serialization.Converters
{
    public partial class JsonManualConvert_Serialize
    {
        internal static object Deserialize(string inputJson, Type type)
        {
            // {
            // "FirstName":"Peter",
            // "LastName":"Parker",
            // "Age":16,
            // "IsAvenger":true
            // }

            object result = Activator.CreateInstance(type)!;

            PropertyInfo[] propertyInfos = type.GetProperties();

            string[] fields = inputJson
                .Trim(new char[] { '{', '}' })
                .Split(',');

            Regex fieldNameRegex = new Regex("\"(\\w[\\w\\d_]+)\":(.*)");

            foreach (var field in fields)
            {
                Match match = fieldNameRegex.Match(field);
                string fieldName = match.Groups[1].Value;
                string value = match.Groups[2].Value;

                PropertyInfo? propertyInfo = FindProperty(propertyInfos, fieldName);
                SetPropertyValue(result, propertyInfo, value);
            }

            return result;
        }

        private static void SetPropertyValue(object result, PropertyInfo propertyInfo, string valueStr)
        {
            Type propType = propertyInfo.PropertyType;

            object? value;
            if (propType == typeof(string))
            {
                value = valueStr.Substring(1, valueStr.Length - 2);
            } else if (propType == typeof(int))
            {
                value = Convert.ToInt32(valueStr);
            } else if (propType == typeof(bool))
            {
                value = Convert.ToBoolean(valueStr);
            }
            else
            {
                throw new ArgumentException($"Type {propType.Name} is not supported");
            }

            propertyInfo.SetValue(result, value);
        }

        private static PropertyInfo FindProperty(PropertyInfo[] propertyInfos, string fieldName)
        {
            PropertyInfo? propertyInfo = propertyInfos
                .Where(p => p.Name == fieldName)
                .FirstOrDefault();

            if (propertyInfo == null)
                throw new ArgumentException($"Object doesn't have '{fieldName}' field");

            return propertyInfo;
        }
    }
}
