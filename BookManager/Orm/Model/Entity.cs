using System;
using System.Collections.Generic;

namespace BookManager.Orm.Model
{
    /// <summary>
    /// Generic persistable entity
    /// </summary>
    /// <typeparam name="K"></typeparam>
    public abstract class Entity<K> : IEquatable<Entity<K>>
    {
        // Won't be exported outside
        public Guid Id { get; set; }

        /// <summary>
        /// Business key, unique identifier of each entity. Exporter outside
        /// </summary>
        /// <returns></returns>
        public abstract K GetBusinessKey();

        public bool Equals(Entity<K> other)
        {
            if (other == null)
            {
                return false;
            }

            return GetBusinessKey().Equals(other.GetBusinessKey());
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Entity<K>);
        }

        public override int GetHashCode()
        {
            return -409944030 + EqualityComparer<K>.Default.GetHashCode(GetBusinessKey());
        }
    }
}
