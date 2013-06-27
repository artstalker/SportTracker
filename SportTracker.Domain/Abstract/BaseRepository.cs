#region using
using System.Data.Entity.Validation;
using System.Linq;

#endregion

namespace SportTracker.Domain.Abstract
{
   public class BaseRepository
   {
      protected ModelContext _container;

      protected BaseRepository()
      {
         _container = new ModelContext();
      }

      public void Save()
      {
         if (_container.GetValidationErrors().Any())
         {
            throw new DbEntityValidationException("Validation error", _container.GetValidationErrors().ToList());
         }
         _container.SaveChanges();
      }
   }
}