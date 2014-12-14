using System.Linq;
using DuplicateCode.Delegate.Support;

namespace DuplicateCode.Delegate.Original {
   public class PersonRepository: IPersonRepository {
      private readonly IOrm _orm;

      public PersonRepository( IOrm orm ) {
         _orm = orm;
      }

      public void Save( Person toSave ) {
         using ( var session = _orm.NewSession() ) {
            using ( var transaction = session.BeginTransaction() ) {
               session.Save( toSave );
               transaction.Commit();
            }
         }
      }

      public void Update( Person toUpdate ) {
         using ( var session = _orm.NewSession() ) {
            using ( var transaction = session.BeginTransaction() ) {
               session.Update( toUpdate );
               transaction.Commit();
            }
         }
      }

      public Person GetById( int id ) {
         Person result;
         using ( var session = _orm.NewSession() ) {
            using ( var transaction = session.BeginTransaction() ) {
               result = session.Query<Person>().FirstOrDefault( person => person.ID == id );
               transaction.Commit();
            }
         }
         return result;
      }
   }
}