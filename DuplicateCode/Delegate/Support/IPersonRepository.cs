namespace DuplicateCode.Delegate.Support {
   public interface IPersonRepository {
      void Save( Person toSave );
      void Update( Person toUpdate );
      Person GetById( int id );
   }
}