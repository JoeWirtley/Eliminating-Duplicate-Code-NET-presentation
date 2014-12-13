using System.Linq;
using DuplicateCode.ParentClass.Support;

namespace DuplicateCode.ParentClass.Original {
   internal class CategoryMenuItemViewModel: IMenuItemViewModel {
      private readonly DelegateCommand<object> _command;
      private bool _visible = true;
      private readonly IRegionManager _regionManager;

      public CategoryMenuItemViewModel( IRegionManager regionManager ) {
         _regionManager = regionManager;
         _command = new DelegateCommand<object>( OnExecute, CanExecute );
      }

      private bool CanExecute( object arg ) {
         return ( _regionManager.Regions[ Regions.Main ].Views.All( v => v.GetType() != typeof( CategoryListView ) ) );
      }

      private void OnExecute( object obj ) {
         _regionManager.RequestNavigate( Regions.Main, NavigationPath );
      }

      public DelegateCommand<object> Command {
         get { return _command; }
      }

      public string Text {
         get { return "Categories"; }
      }

      public string ToolTip {
         get { return "Categories"; }
      }

      public int Order {
         get { return 4; }
      }

      public bool SeparatorAfter {
         get { return false; }
      }

      public string IconName {
         get { return "user_list_menu_icon"; }
      }

      public string NavigationPath {
         get { return typeof( CategoryListView ).FullName; }
      }

      public bool Visible {
         get { return _visible; }
         set { _visible = value; }
      }
   }
}