using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class IdGenerator
    {
        private static IdGenerator _instance = new IdGenerator();
        public static IdGenerator Instanse
        {
            get
            {
                return _instance;
            }
        }

        private Dictionary<string, int> _objectTypeIds = new Dictionary<string, int>();


        public int GetId<T>()
        {
            string typeName = typeof(T).Name;

            if (_objectTypeIds.ContainsKey(typeName))
                return _objectTypeIds[typeName]++;


            else
            {
                _objectTypeIds.Add(typeName, 6);
                return _objectTypeIds[typeName]++;
            }
        }
    }
}