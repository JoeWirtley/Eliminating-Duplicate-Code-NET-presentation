using System;
using DuplicateCode.Delegate.Support;

namespace DuplicateCode.Delegate.Refactored {
   public abstract class RepositoryBase {
      private readonly IOrm _orm;

      protected RepositoryBase( IOrm orm ) {
         _orm = orm;
      }

      protected internal void Exec( Action<ISession> toExecute ) {
         using ( var session = _orm.NewSession() ) {
            using ( var transaction = session.BeginTransaction() ) {
               toExecute( session );
               transaction.Commit();
            }
         }
      }

      protected T Exec< T >( Func<ISession, T> toExecute ) {
         T result;
         using ( var session = _orm.NewSession() ) {
            using ( var transaction = session.BeginTransaction() ) {
               result = toExecute( session );
               transaction.Commit();
            }
         }
         return result;
      }
   }
}