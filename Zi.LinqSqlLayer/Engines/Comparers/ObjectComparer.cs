namespace Zi.LinqSqlLayer.Engines.Comparers
{
    public class ObjectComparer
    {
        #region Instance
        private static ObjectComparer instance;
        public static ObjectComparer Instance
        {
            get { if (instance == null) instance = new ObjectComparer(); return instance; }
            private set { instance = value; }
        }
        private ObjectComparer() { }
        #endregion

        public bool IsModified(object modifyObj, object sourceObj)
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
