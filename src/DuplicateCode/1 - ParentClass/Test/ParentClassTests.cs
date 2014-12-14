using System;
using DuplicateCode.ParentClass.Support;
using FluentAssertions;
using NUnit.Framework;
using Telerik.JustMock;
using Telerik.JustMock.Helpers;

namespace DuplicateCode.ParentClass.Test {
   [TestFixture]
   public class ParentClassTests {
      private IRegionManager _regionManager;
      private IModalDialogService _modalDialogService;

      [SetUp]
      public void BeforeEachTest() {
         _regionManager = Mock.Create<IRegionManager>();
         _modalDialogService = Mock.Create<IModalDialogService>();
      }


      [Test]
      public void TestOriginalCategoryMenuItem() {
         string expectedNavigationPath = typeof( CategoryListView ).FullName;
         Original.CategoryMenuItemViewModel category = new Original.CategoryMenuItemViewModel( _regionManager );
         _regionManager.Arrange( x => x.RequestNavigate( Regions.Main, expectedNavigationPath ) ).OccursOnce();

         category.Text.Should().Be( "Categories" );
         category.NavigationPath.Should().Be( expectedNavigationPath );
         category.Command.Execute( null );

         _regionManager.AssertAll();
      }

      [Test]
      public void TestRefactoredCategoryMenuItem() {
         string expectedNavigationPath = typeof( CategoryListView ).FullName;
         Refactored.CategoryMenuItemViewModel category = new Refactored.CategoryMenuItemViewModel( _regionManager );
         _regionManager.Arrange( x => x.RequestNavigate( Regions.Main, expectedNavigationPath ) ).OccursOnce();

         category.Text.Should().Be( "Categories" );
         category.Command.Execute( null );

         _regionManager.AssertAll();
      }

      [Test]
      public void TestOriginalLoginMenuItem() {
         string expectedNavigationPath = typeof( LoginDialog ).FullName;
         Original.LoginMenuItemViewModel login = new Original.LoginMenuItemViewModel( _regionManager, _modalDialogService );

         _regionManager.Arrange( x => x.RequestNavigate( Regions.Main, expectedNavigationPath ) ).OccursNever();
         _modalDialogService.Arrange( x => x.Show( Arg.IsAny<Action<LoginDialog>>() ) ).OccursOnce();

         login.Text.Should().Be( "Login" );
         login.NavigationPath.Should().Be( expectedNavigationPath );
         login.Command.Execute( null );

         _regionManager.AssertAll();
         _modalDialogService.AssertAll();
      }

      [Test]
      public void TestRefactoredLoginMenuItem() {
         string expectedNavigationPath = typeof( LoginDialog ).FullName;
         Refactored.LoginMenuItemViewModel login = new Refactored.LoginMenuItemViewModel( _regionManager, _modalDialogService );

         _regionManager.Arrange( x => x.RequestNavigate( Regions.Main, expectedNavigationPath ) ).OccursNever();
         _modalDialogService.Arrange( x => x.Show( Arg.IsAny<Action<LoginDialog>>() ) ).OccursOnce();

         login.Text.Should().Be( "Login" );
         login.Command.Execute( null );

         _regionManager.AssertAll();
         _modalDialogService.AssertAll();
      }

   }
}