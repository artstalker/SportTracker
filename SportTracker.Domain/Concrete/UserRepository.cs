using System;
using System.Data;
using System.Linq;
using SportTracker.Domain.Abstract;

namespace SportTracker.Domain.Concrete
{
   public class UserRepository : BaseRepository, IUserRepository
   {
      #region Implementation of IUserRepository
      public IQueryable<User> Users
      {
         get
         {
            return _container.Users.Include("BodyStamps").Include("Friends").Include("Programs").Include("Tweets").Include("Trainings");
         }
      }
      public void Add(User user)
      {
         user.UserId = Guid.NewGuid();
         _container.Users.Add(user);         
      }

      public void Update(User user)
      {
         _container.Users.Attach(user);
         _container.Entry(user).State = EntityState.Modified;
         _container.ChangeTracker.DetectChanges();
      }      
      #endregion
   }
}