using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica3
{
    public class Singleton<T> where T : class, new()
    {
        private static T _instance;
        protected Singleton() { }

        public static T GetInstance()
        {
            if (_instance == null)
            {
                _instance = new T();
            }
            return _instance;
        }
    }
}