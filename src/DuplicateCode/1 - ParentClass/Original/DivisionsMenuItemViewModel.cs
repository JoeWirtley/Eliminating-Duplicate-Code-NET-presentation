using System.Linq;
using DuplicateCode.ParentClass.Support;

namespace DuplicateCode.ParentClass.Original {
   public class DivisionsMenuItemViewModel: IMenuItemViewModel {
      private readonly DelegateCommand<object> _command;
      private readonly IRegionManager _regionManager;
      private bool _visible = true;

      public DivisionsMenuItemViewModel( IRegionManager regionManager ) {
         _command = new DelegateCommand<object>( OnExecute, CanExecute );
         _regionManager = regionManager;
      }

      private bool CanExecute( object arg ) {
         return ( _regionManager.Regions[ Regions.Main ].Views.All( v => v.GetType() != typeof( DivisionsListView ) ) );
      }

      private void OnExecute( object obj ) {
         _regionManager.RequestNavigate( Regions.Main, NavigationPath );
      }

      public DelegateCommand<object> Command {
         get { return _command; }
      }

      public string Text {
         get { return "Divisions"; }
      }

      public string ToolTip {
         get { return "Divisions"; }
      }

      public int Order {
         get { return 2; }
      }

      public bool SeparatorAfter {
         get { return true; }
      }

      public string IconName {
         get { return "divisions_menu_icon"; }
      }

      public string NavigationPath {
         get { return typeof( DivisionsListView ).FullName; }
      }

      public bool Visible {
         get { return _visible; }
         set { _visible = value; }
      }
   }
}