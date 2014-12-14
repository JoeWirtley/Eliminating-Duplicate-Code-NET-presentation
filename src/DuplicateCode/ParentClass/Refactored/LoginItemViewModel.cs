using DuplicateCode.ParentClass.Support;

namespace DuplicateCode.ParentClass.Refactored {
   internal class LoginMenuItemViewModel: MenuItemViewModelBase {
      private readonly IModalDialogService _modalDialogService;

      public LoginMenuItemViewModel( IRegionManager regionManager, IModalDialogService modalDialogService ): base( regionManager ) {
         _modalDialogService = modalDialogService;
      }

      protected override void Initialize() {
         Text = "Login";
         ToolTip = "Login as a different user";
         Order = 11;
         SeparatorAfter = true;
         IconName = "login_menu_icon";
      }

      protected override bool CanExecute( object arg ) {
         return base.CanExecute( arg ) && !IsViewOpen<LoginDialog>();
      }

      protected override void OnExecute( object obj ) {
         _modalDialogService.Show<LoginDialog>( OnCloseLogin );
      }

      private void OnCloseLogin( LoginDialog obj ) {
      }
   }
}