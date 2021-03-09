using System;
using System.ComponentModel;
using System.Reflection;

namespace Entity.Extensions
{
    public static class EnumExtensions
    {
		public static string GetName(this Enum t)
		{
			return Enum.GetName(t.GetType(), t);
		}

		public static string GetDescription(this Enum value)
		{
			FieldInfo field = value.GetType().GetField(value.ToString());
			if (field != null)
			{
				object[] attribs = field.GetCustomAttributes(typeof(DescriptionAttribute), true);
				if (attribs.Length > 0)
				{
					return ((DescriptionAttribute)attribs[0]).Description;
				}
			}
			return value.GetName();
		}
	}
}
