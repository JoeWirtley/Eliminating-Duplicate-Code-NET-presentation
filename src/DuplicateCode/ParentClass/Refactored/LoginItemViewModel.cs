using DuplicateCode.ParentClass.Original;
using DuplicateCode.ParentClass.Support;

namespace DuplicateCode.ParentClass.Refactored {
   internal class LoginDifferentUserMenuItemViewModel: MenuItemViewModelBase {
      private readonly IModalDialogService _modalDialogService;

      public LoginDifferentUserMenuItemViewModel( IRegionManager regionManager, IModalDialogService modalDialogService ): base ( regionManager ) {
         _modalDialogService = modalDialogService;
      }

      protected override void Initialize() {
         Text = "Login";
         ToolTip = "Login as a different user";
         Order = 11;
         SeparatorAfter = true;
         IconName = "user_list_menu_icon";
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