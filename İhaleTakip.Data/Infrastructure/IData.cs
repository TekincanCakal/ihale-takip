namespace İhaleTakip.Data.Infrastructure
{
    using İhaleTakip.Data.Infrastructure.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public interface IData<T>
    {
        DataResult<T> Insert(T t);
        DataResult<T> Update(T t);
        DataResult<T> Delete(T t);
        DataResult<T> DeleteByKey(int id);
        DataResult<T> InsertBulk(List<T> ts, bool validateAndIgnoreBefore = false);

        DataResult<T> GetByKey(int id);

        DataResult<List<T>> GetAll();
        DataResult<List<T>> GetAll(string orderBy, bool isDesc = false);
        DataResult<List<T>> GetBy(Expression<Func<T, bool>> predicate);
        DataResult<List<T>> GetBy(Expression<Func<T, bool>> predicate, string orderBy, bool isDesc = false);
        DataResult<T> FirstOrDefault(Expression<Func<T, bool>> predicate, bool asNoTracking = false);
        void DetachAllEntites();

        DataResult<int> GetCount();
        DataResult<int> GetCount(Expression<Func<T, bool>> predicate);
    }
}
