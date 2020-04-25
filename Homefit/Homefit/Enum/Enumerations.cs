using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Homefit.Enum
{
    public static class Enumerations
    {
        public static string GetDescription(this Objectif enumerationValue)
        {
            var type = enumerationValue.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException($"{nameof(enumerationValue)} must be of Enum type", nameof(enumerationValue));
            }
            var memberInfo = type.GetMember(enumerationValue.ToString());
            if (memberInfo.Length > 0)
            {
                var attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }
            return enumerationValue.ToString();
        }
        public static string GetEnumDescription(string value)
        {
            string result = value.ToString();
            DisplayAttribute attribute = typeof(Objectif).GetRuntimeField(value.ToString()).GetCustomAttributes<DisplayAttribute>(false).SingleOrDefault();

            if (attribute != null)
                result = attribute.Description;

            return result;
        }
        public static Objectif GetEnumByDescription(string description)
        {
            return Objectif.GetValues(typeof(Objectif)).Cast<Objectif>().FirstOrDefault(x => string.Equals(GetEnumDescription(x.ToString()), description));
        }
    }
}
