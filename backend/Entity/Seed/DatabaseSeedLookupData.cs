using Entity.Entities;
using Entity.Extensions;
using System;
using System.Collections.Generic;

namespace Entity.Seed
{
    public static class DatabaseSeedLookupData
    {
        public static IEnumerable<T> GetCollectionSeedFromEnum<T, Enum>()
        {
            var collection = new List<T>();

            foreach (var enumValue in DictionaryExtension.GetDictionaryOf<Enum>())
            {
                collection.Add((T)Activator.CreateInstance(typeof(T), enumValue.Key, enumValue.Value));
            }

            return collection;
        }
    }
}
