using DuplicateCode.Delegate.Support;
using NUnit.Framework;
using Telerik.JustMock;
using Telerik.JustMock.Helpers;

namespace DuplicateCode.Delegate.Test {
   [TestFixture]
   public class DelegateTest {
      private IOrm _orm;
      private ISession _session;
      private ITransaction _transaction;

      [SetUp]
      public void BeforeEachTest() {
         _orm = Mock.Create<IOrm>( Behavior.Strict );

         _session = Mock.Create<ISession>( Behavior.Strict);
         _orm.Arrange( x => x.NewSession() ).Returns( _session );

         _transaction = Mock.Create<ITransaction>( Behavior.Strict);
         _transaction.Arrange( x => x.Commit()  ).OccursOnce();
         _transaction.Arrange( x => x.Dispose()  ).OccursOnce();

         _session.Arrange( x => x.BeginTransaction() ).Returns( _transaction  ).OccursOnce();
         _session.Arrange( x => x.Dispose()  ).OccursOnce();
      }

      public void CoreTestSave( IPersonRepository repository ) {
         _session.Arrange( x => x.Save( Arg.IsAny<Person>() ) ).OccursOnce();

         repository.Save( new Person() );

         _session.AssertAll();
         _transaction.AssertAll();
      }

      [Test]
      public void TestOriginalSave() {
         CoreTestSave( new Original.PersonRepository( _orm )  );
      }

      [Test]
      public void TestRefactoredSave() {
         CoreTestSave( new Refactored.PersonRepository( _orm ) );
      }
   }
}