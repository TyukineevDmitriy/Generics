using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class Storage
    {
        private Dictionary<Guid, Object> Database;
        private Dictionary<Type, List<Guid>> ObjectTypes;

        public Storage()
        {
            Database = new Dictionary<Guid, object>();
            ObjectTypes = new Dictionary<Type, List<Guid>>();
        }

        public T Save<T>()
            where T : class, new()
        {
            T obj = new T();
            Guid id = Guid.NewGuid();
            Database.Add(id, obj);
            Type objType = obj.GetType();
            if (!ObjectTypes.ContainsKey(objType))
            {
                ObjectTypes.Add(objType, new List<Guid>());
            }
            ObjectTypes[objType].Add(id);
            return obj;
        }

        public IEnumerable<KeyValuePair<Guid, T>> GetPairs<T>()
            where T : class, new()
        {
            List<KeyValuePair<Guid, T>> pairs = new List<KeyValuePair<Guid, T>>();
            List<Guid> ids = ObjectTypes[typeof(T)];
            foreach (Guid id in ids)
            {
                pairs.Add(new KeyValuePair<Guid, T>(id, (T)Database[id]));
            }
            return pairs;
        }

        public T GetObject<T>(Guid id)
            where T : class, new()
        {
            if (Database.ContainsKey(id))
            {
                return (T)Database[id];
            }
            else
            {
                return null;
            }
        }
    }
}
