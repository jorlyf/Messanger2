using back.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace back.Repositories
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private DataContext DataContext { get; }
		private DbSet<T> DbSet { get; }
		public Repository()
		{
			this.DataContext = new DataContext();
			this.DbSet = this.DataContext.Set<T>();
		}

		public T? Get(int id)
		{
			return this.DbSet.Find(id);
		}
		public T? Get(Expression<Func<T, bool>> where)
		{
			return this.DbSet.Where(where).FirstOrDefault();
		}
		public IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
		{
			return this.DbSet.Where(where).ToList();
		}
		public IEnumerable<T> GetAll()
		{
			return this.DbSet.ToList();
		}
		public void Add(T entity)
		{
			this.DbSet.Add(entity);
		}
		public void Update(T entity)
		{
			this.DbSet.Update(entity);
		}
		public void Delete(int id)
		{
			T? entity = this.DbSet.Find(id);
			if (entity is null) return;

			Delete(entity);
		}
		public void Delete(T entity)
		{
			this.DbSet.Remove(entity);
		}
		public void Save()
		{
			this.DataContext.SaveChanges();
		}
		public void Dispose()
		{
			this.DataContext.Dispose();
		}
	}
}
