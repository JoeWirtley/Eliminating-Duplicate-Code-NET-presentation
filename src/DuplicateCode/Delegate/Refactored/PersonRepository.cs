using System.Linq;
using DuplicateCode.Delegate.Support;

namespace DuplicateCode.Delegate.Refactored {
   public class PersonRepository: RepositoryBase, IPersonRepository {
      public PersonRepository( IOrm orm ): base( orm ) {
      }

      public void Save( Person toSave ) {
         Exec( session => session.Save( toSave ) );
      }

      public void Update( Person toUpdate ) {
         Exec( session => session.Update( toUpdate ) );
      }

      public Person GetById( int id ) {
         return Exec( session => session.Query<Person>().FirstOrDefault( person => person.ID == id ) );
      }
   }
}