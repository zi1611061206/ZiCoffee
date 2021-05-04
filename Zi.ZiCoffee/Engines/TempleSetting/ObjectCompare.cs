using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Zi.ZiCoffee.Engines.TempleSetting
{
    public class ObjectCompare
    {
        #region Instance
        private static ObjectCompare instance;
        public static ObjectCompare Instance
        {
            get { if (instance == null) instance = new ObjectCompare(); return instance; }
            private set { instance = value; }
        }
        private ObjectCompare() { }
        #endregion

        public bool IsModified(TempleSetting modifyObj, TempleSetting sourceObj)
        {
            foreach (var prop1 in modifyObj.GetType().GetProperties())
            {
                foreach (var prop2 in sourceObj.GetType().GetProperties())
                {
                    if (prop1.Name.Equals(prop2.Name))
                    {
                        if (!prop1.GetValue(modifyObj).ToString().Equals(prop2.GetValue(sourceObj).ToString()))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
