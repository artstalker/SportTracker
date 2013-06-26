using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.Validation;
using System.Linq;

namespace SportTracker.Domain.Abstract
{
   public class BaseRepository
   {
      protected ModelSportTrackerContainer _container;

      protected BaseRepository()
      {
			
         _container = new ModelSportTrackerContainer(Connection.ConnectionStringName);
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