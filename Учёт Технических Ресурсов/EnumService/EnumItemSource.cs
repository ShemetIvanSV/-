using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Windows.Data;

namespace Учёт_Технических_Ресурсов.EnumService
{
    class EnumItemSource : Collection<string>, IValueConverter
    {
        Type type;
        IDictionary<object, object> valueToNameMap;
        IDictionary<object, object> nameToValueMap;

        public Type Type
        {
            get { return this.type; }
            set
            {
                if (!value.IsEnum)
                    throw new ArgumentException("Type is not an enum.", "value");
                this.type = value;
                Initialize();
            }
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((Enum) value).ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return this.nameToValueMap[value];
        }

        void Initialize()
        {
            this.valueToNameMap = this.type
                .GetFields(BindingFlags.Static | BindingFlags.Public)
                .ToDictionary(fi => fi.GetValue(null), GetDescription);
            this.nameToValueMap = this.valueToNameMap
                .ToDictionary(kvp => kvp.Value, kvp => kvp.Key);
            Clear();
            foreach (String name in this.nameToValueMap.Keys)
                Add(name);
        }

        static object GetDescription(FieldInfo fieldInfo)
        {
            var descriptionAttribute =
                (DescriptionAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute));
            return descriptionAttribute != null ? descriptionAttribute.Description : fieldInfo.Name;
        }
    }
}
