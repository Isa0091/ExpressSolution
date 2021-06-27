using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ExpressSolution.Stores.WebAdmin.Extensions
{
    public static class EnumExtension
    { 
       /// <summary>
      /// obtengo un selectListitem apartir de los datos de un enum
      /// colocando el atributo description como Text del selectListItem
      /// </summary>
      /// <typeparam name="TEnum"></typeparam>
      /// <param name="indexed"></param>
      /// <returns></returns>
        public static SelectList EnumSelectlist<TEnum>(bool indexed = false) where TEnum : struct
        {
            return new SelectList(Enum.GetValues(typeof(TEnum)).Cast<TEnum>().Select(item => new SelectListItem
            {
                Text = GetEnumDescription(item as Enum),
                Value = indexed ? Convert.ToInt32(item).ToString() : item.ToString()
            }).ToList(), "Value", "Text");
        }

        /// <summary>
        /// Obtengo el atributo typo description apartir de lso datos de un enum
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool? GetEnumToBoolValue(this int value)
        {
            switch (value)
            {
                case 1: return true;
                case 0: return false;
                default: throw new ArgumentOutOfRangeException("value");
                    // ^^^ yes, that is possible
            }
        }
    }
}
