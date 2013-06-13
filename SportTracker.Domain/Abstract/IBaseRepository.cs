using System.Linq;

namespace SportTracker.Domain.Abstract
{
   public interface IBaseRepository<T>
   {
      void Save(T entity);

		IQueryable<T> Entities { get; }
		void Add(T user);
		void Update(T user);
   }
}