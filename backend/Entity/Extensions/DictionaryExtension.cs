using System;
using System.Collections.Generic;
using System.Linq;

namespace Entity.Extensions
{
    public class DictionaryExtension
	{
		public static Dictionary<int, string> GetDictionaryOf<T>()
		{
			Type t = typeof(T);
			if (t.IsEnum)
			{
				return (from Enum e in Enum.GetValues(t)
						select new { ID = Convert.ToInt32(e), Name = e.GetDescription() }).ToDictionary(e => e.ID, e => e.Name);

			}
			return null;
		}
	}
}
