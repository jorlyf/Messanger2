using System.Linq.Expressions;

namespace back.Repositories
{
	public interface IRepository<T> : IDisposable where T : class
	{
		T? Get(int id);
		T? Get(Expression<Func<T, bool>> where);
		IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
		IEnumerable<T> GetAll();
		void Add(T entity);
		void Update(T entity);
		void Delete(int id);
		void Delete(T entity);
		void Save();
	}
}
