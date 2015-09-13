using CommandQuery.Sample.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace CommandQuery.Sample.Tests
{
    public class TestDbSet<T> : DbSet<T>, IQueryable, IEnumerable<T>, IDbAsyncEnumerable<T>
        where T : class
    {
        private readonly ObservableCollection<T> data;
        private readonly IQueryable query;

        public TestDbSet()
        {
            data = new ObservableCollection<T>();
            query = data.AsQueryable();
        }

        public override T Add(T item)
        {
            data.Add(item);
            return item;
        }

        public override IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            var addRange = entities as T[] ?? entities.ToArray();
            foreach (var entity in addRange)
            {
                data.Add(entity);
            }
            return addRange;
        }

        public override T Remove(T item)
        {
            data.Remove(item);
            return item;
        }

        public override T Attach(T item)
        {
            if (!data.Contains(item) && !EntityExists(item))
                data.Add(item);
            return item;
        }

        private bool EntityExists(T item)
        {
            return data.Any(d =>
            {
                var entity = d as IEntity;
                var entity1 = item as IEntity;
                return entity1 != null && (entity != null && entity.Id == entity1.Id);
            });
        }

        public override T Create()
        {
            return Activator.CreateInstance<T>();
        }

        public override TDerivedEntity Create<TDerivedEntity>()
        {
            return Activator.CreateInstance<TDerivedEntity>();
        }

        public override ObservableCollection<T> Local
        {
            get { return data; }
        }

        Type IQueryable.ElementType
        {
            get { return query.ElementType; }
        }

        Expression IQueryable.Expression
        {
            get { return query.Expression; }
        }

        IQueryProvider IQueryable.Provider
        {
            get { return new TestDbAsyncQueryProvider<T>(query.Provider); }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return data.GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return data.GetEnumerator();
        }

        IDbAsyncEnumerator<T> IDbAsyncEnumerable<T>.GetAsyncEnumerator()
        {
            return new TestDbAsyncEnumerator<T>(data.GetEnumerator());
        }
    }
}