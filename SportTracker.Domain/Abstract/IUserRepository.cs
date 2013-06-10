using System.Linq;

namespace SportTracker.Domain.Abstract
{
   public interface IUserRepository: IBaseRepository
   {
      IQueryable<User> Users { get; }
      void Add(User user);
      void Update(User user);
   }
}