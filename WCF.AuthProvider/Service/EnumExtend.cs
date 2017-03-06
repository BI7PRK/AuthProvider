using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace WCF.AuthProvider.Service
{
    internal static class EnumExtend
    {
        /// <summary>
        /// 获取枚举的 Description
        /// </summary>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum enumValue)
        {
            var type = enumValue.GetType();
            var field = type.GetField(enumValue.ToString());
            if (field == null) return string.Empty;
            var descriptions = field.GetCustomAttributes(typeof(DescriptionAttribute), true) as DescriptionAttribute[];

            if (descriptions.Any())
                return descriptions.First().Description;

            return string.Empty;
        }
    }
}
