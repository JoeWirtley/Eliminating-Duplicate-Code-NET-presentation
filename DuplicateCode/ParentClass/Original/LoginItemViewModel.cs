using System.Linq;
using DuplicateCode.ParentClass.Support;

namespace DuplicateCode.ParentClass.Original {
   internal class LoginMenuItemViewModel: IMenuItemViewModel {
      private bool _visible = true;
      private readonly IRegionManager _regionManager;
      private readonly DelegateCommand<object> _command;
      private readonly IModalDialogService _modalDialogService;

      public LoginMenuItemViewModel( IRegionManager regionManager, IModalDialogService modalDialogService ) {
         _regionManager = regionManager;
         _command = new DelegateCommand<object>( OnExecute, CanExecute );
         _modalDialogService = modalDialogService;
      }

      private bool CanExecute( object arg ) {
         return ( _regionManager.Regions[ Regions.Main ].Views.All( v => v.GetType() != typeof( LoginDialog ) ) );
      }

      private void OnExecute( object obj ) {
         _modalDialogService.Show<LoginDialog>( OnCloseLogin );
      }

      private void OnCloseLogin( LoginDialog obj ) {
      }

      public DelegateCommand<object> Command {
         get { return _command; }
      }

      public string Text {
         get { return "Login"; }
      }

      public string ToolTip {
         get { return "Login as a different user"; }
      }

      public int Order {
         get { return 11; }
      }

      public bool SeparatorAfter {
         get { return true; }
      }

      public string IconName {
         get { return "user_list_menu_icon"; }
      }

      public string NavigationPath {
         get { return typeof( LoginDialog ).FullName; }
      }

      public bool Visible {
         get { return _visible; }
         set { _visible = value; }
      }
   }
}