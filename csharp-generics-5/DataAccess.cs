using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace csharp_generics_5
{
  public class EmployeeDb: DbContext
  {
    public DbSet<Employee> Employees{get;set;}
  }
  // 读取仓库
  public interface IReadOnlyRespository<out T>: IDisposable
  {
    T FindById(int id);
    IQueryable<T> FindAll();
  }
  //写入仓库
  public interface IWriteOnlyRespository<in T>: IDisposable
  {
    void Add(T newEntity);
    void Delete(T entity);
    int Commit();
  }
  public interface IRespository<T>: IReadOnlyRespository<T>,IWriteOnlyRespository<T>
  {}
  public class SqlRespository<T>: IRespository<T> where T: class, IEntity
  {
    DbContext _ctx;
    DbSet<T> _set;
    public SqlRespository(DbContext ctx)
    {
      _ctx = ctx;
      _set = _ctx.Set<T>();
    }
    public void Add(T newEntity)
    {
      if(newEntity.IsValid())
      {
        _set.Add(newEntity);
      }
    }
    public void Delete(T entity)
    {
      _set.Remove(entity);
    }
    public T FindById(int id)
    {
      return _set.Find(id);
    }
    public int Commit()
    {
      return _ctx.SaveChanges();
    }
    public void Dispose()
    {
      _ctx.Dispose();
    }
    public IQueryable<T> FindAll()
    {
      return _set;
    }
  }
}