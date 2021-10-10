namespace İhaleTakip.Data.Infrastructure
{
    using İhaleTakip.Data.Infrastructure.Entities;
    using İhaleTakip.Model.Core;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;

    public class EntityBaseData<T> : IData<T> where T : ModelBase
    {
        protected readonly DbContext _context;

        public EntityBaseData(DbContext context)
        {
            _context = context;
        }

        public void DetachAllEntites()
        {
            var entries = _context.ChangeTracker.Entries().Where(e => e.State != EntityState.Detached).ToList();
            foreach(var entry in entries)
            {
                if(entry.Entity != null)
                {
                    entry.State = EntityState.Detached;
                }
            }
        }

        protected virtual void BeforeUpdate() { }
        protected virtual void AfterUpdate() { }
        protected virtual void BeforeInsert(T t) { }
        protected virtual void AfterInsert() { }
        protected virtual void BeforeDelete() { }
        protected virtual void AfterDelete() { }

        public DataResult<T> Delete(T t)
        {
            try
            {
                return DeleteByKey(t.Id);
            }
            catch(Exception ex)
            {
                return new DataResult<T>(false, null, ex.Message + ex.InnerException == null ? "" : "(" + ex.InnerException + ")");
            }
        }

        public DataResult<T> DeleteByKey(int id)
        {
            try
            {
                T aModel = _context.Set<T>().Where(x => x.Id == id).FirstOrDefault();
                
                if(aModel == null)
                {
                    return new DataResult<T>(false, null, "Silinecek Kayıt Bulunamadı");
                }

                BeforeDelete();

                _context.Set<T>().Remove(aModel);

                AfterDelete();

                _context.SaveChanges();

                return new DataResult<T>(true, null, "");
            }
            catch(Exception ex)
            {
                return new DataResult<T>(false, null, ex.Message + ex.InnerException == null ? "" : "(" + ex.InnerException + ")");
            }
        }

        public DataResult<T> FirstOrDefault(Expression<Func<T, bool>> predicate, bool asNoTracking = false)
        {
            try
            {
                var query = _context.Set<T>().AsQueryable();

                if (asNoTracking)
                    query = query.AsNoTracking();

                T data = query.Where(predicate).Take(1).FirstOrDefault();
                return new DataResult<T>(true, data, "");
            }
            catch(Exception ex)
            {
                return new DataResult<T>(false, null, ex.Message + ex.InnerException == null ? "" : "(" + ex.InnerException + ")");
            }
        }

        public DataResult<List<T>> GetAll()
        {
            try
            {
                List<T> data = _context.Set<T>().ToList();
                return new DataResult<List<T>>(true, data, "");
            }
            catch(Exception ex)
            {
                return new DataResult<List<T>>(false, null, ex.Message + ex.InnerException == null ? "" : "(" + ex.InnerException + ")");
            }
        }

        public DataResult<List<T>> GetAll(string orderBy, bool isDesc = false)
        {
            try
            {
                List<T> data = isDesc
               ? _context.Set<T>().OrderByDescending(orderBy).ToList() :
               _context.Set<T>().OrderBy(orderBy).ToList();
                return new DataResult<List<T>>(true, data, "");
            }
            catch(Exception ex)
            {
                return new DataResult<List<T>>(false, null, ex.Message + ex.InnerException == null ? "" : "(" + ex.InnerException + ")");
            }
        }

        public DataResult<List<T>> GetBy(Expression<Func<T, bool>> predicate)
        {
            try
            {
                List<T> data = _context.Set<T>().Where(predicate).ToList();
                return new DataResult<List<T>>(true, data, "");
            } 
            catch(Exception ex)
            {
                return new DataResult<List<T>>(false, null, ex.Message + ex.InnerException == null ? "" : "(" + ex.InnerException + ")");
            }
        }

        public DataResult<List<T>> GetBy(Expression<Func<T, bool>> predicate, string orderBy, bool isDesc = false)
        {
            try
            {
                List<T> data = isDesc
                   ? _context.Set<T>().Where(predicate).OrderByDescending(orderBy).ToList() :
                   _context.Set<T>().Where(predicate).OrderBy(orderBy).ToList();
                return new DataResult<List<T>>(true, data, "");
            }
            catch(Exception ex)
            {
                return new DataResult<List<T>>(false, null, ex.Message + ex.InnerException == null ? "" : "(" + ex.InnerException + ")");
            }
        }

        public DataResult<T> GetByKey(int id)
        {
            try
            {
                T data = _context.Set<T>().Where(x => x.Id == id).FirstOrDefault();
                return new DataResult<T>(true, data, "");
            }
            catch(Exception ex)
            {
                return new DataResult<T>(false, null, ex.Message + ex.InnerException == null ? "" : "(" + ex.InnerException + ")");
            }
        }

        public DataResult<int> GetCount()
        {
            try
            {
                int data = _context.Set<T>().Select(x => x.Id).Count();
                return new DataResult<int>(true, data, "");
            }
            catch (Exception ex)
            {
                return new DataResult<int>(false, -1, ex.Message + ex.InnerException == null ? "" : "(" + ex.InnerException + ")");
            }
        }

        public DataResult<int> GetCount(Expression<Func<T, bool>> predicate)
        {
            try
            {
                int data = _context.Set<T>().Where(predicate).Count();
                return new DataResult<int>(true, data, "");
            }
            catch (Exception ex)
            {
                return new DataResult<int>(false, -1, ex.Message + ex.InnerException == null ? "" : "(" + ex.InnerException + ")");
            }
        }

        public DataResult<T> Insert(T t)
        {
            try
            {
                BeforeInsert(t);
                _context.Set<T>().Add(t);
                AfterInsert();

                _context.SaveChanges();
                return new DataResult<T>(true, null, "");
            }
            catch(Exception ex)
            {
                return new DataResult<T>(false, null, ex.Message + ex.InnerException == null ? "" : "(" + ex.InnerException + ")");
            }
        }

        public DataResult<T> InsertBulk(List<T> ts, bool validateAndIgnoreBefore = false)
        {
            if (ts.Count <= 0)
                return new DataResult<T>(true, null, "");

            try
            {
                foreach(var item in ts)
                {
                    if (validateAndIgnoreBefore && typeof(IValidatableObject).IsAssignableFrom(item.GetType()))
                    {
                        var results = new List<ValidationResult>();
                        bool isValid = Validator.TryValidateObject(item, new ValidationContext(item, null, null), results, true);

                        if (!isValid)
                        {
                            var resultFirst = results[0];
                            continue;
                        }

                        _context.Set<T>().Add(item);
                    }
                }

                _context.SaveChanges();

                return new DataResult<T>(true, null, "");
            }
            catch(Exception ex)
            {
                return new DataResult<T>(false, null, ex.Message + ex.InnerException == null ? "" : "(" + ex.InnerException + ")");
            }
        }

        public DataResult<T> Update(T t)
        {
            try
            {
                int updateId = t.Id;

                T aModel = _context.Set<T>().Where(x => x.Id == updateId).FirstOrDefault();

                if(aModel == null)
                {
                    return new DataResult<T>(false, null, "Güncelleme Yapılacak Kayıt Bulunamadı");
                }

                BeforeUpdate();

                foreach(var propertyInfo in typeof(T).GetProperties())
                {
                    var hasIgnore = Attribute.IsDefined(propertyInfo, typeof(IgnoredAttribute));
                    if (hasIgnore)
                        continue;

                    propertyInfo.SetValue(aModel, propertyInfo.GetValue(t, null), null);
                }

                AfterUpdate();

                _context.SaveChanges();

                return new DataResult<T>(true, null, "");
            }
            catch(Exception ex)
            {
                return new DataResult<T>(false, null, ex.Message + ex.InnerException == null ? "" : "(" + ex.InnerException + ")");
            }
        }
    }
}
