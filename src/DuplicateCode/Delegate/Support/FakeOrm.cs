using System;
using System.Linq;

namespace DuplicateCode.Delegate.Support {
   public interface IOrm {
      ISession NewSession();
   }
   public interface ISession: IDisposable {
      ITransaction BeginTransaction();
      IQueryable<T> Query<T>();
      void Save<T>( T toSave );
      void Update<T>( T toUpdate );
   }

   public interface ITransaction: IDisposable {
      void Commit();
   }

}