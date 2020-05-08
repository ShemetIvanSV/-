using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Учёт_Технических_Ресурсов.EnumService
{
    class EnumItemSource : Collection<string>, IValueConverter
    {
        private Type type;
        private IDictionary<Object, Object> valueToNameMap;
        private IDictionary<Object, Object> nameToValueMap;

        public Type Type
        {
            get => type;
            set
            {
                if(!value.IsEnum)
                    throw new ArgumentException("Type is not an enum");
                type = value;
                Initialize();
            }
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return valueToNameMap[value];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return nameToValueMap[value];
        }

        private void Initialize()
        {
            valueToNameMap = type
                .GetFields(BindingFlags.Static | BindingFlags.Public)
                .ToDictionary(fi => fi.GetValue(null), GetDescription);
            nameToValueMap = valueToNameMap
                .ToDictionary(kvp => kvp.Value, kvp => kvp.Key);
            Clear();
            foreach (string name in nameToValueMap.Keys)
                Add(name);
        }

        static Object GetDescription(FieldInfo fieldInfo)
        {
            var descriptionAttribute =
                (DescriptionAttribute) Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute));
            return descriptionAttribute != null ? descriptionAttribute.Description : fieldInfo.Name;
        }
    }
}
