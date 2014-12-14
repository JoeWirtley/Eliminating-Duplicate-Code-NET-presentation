using DuplicateCode.ParentClass.Support;

namespace DuplicateCode.ParentClass.Refactored {
   public class DivisionsMenuItemViewModel: MenuItemViewModelBase {
      public DivisionsMenuItemViewModel( IRegionManager regionManager ): base( regionManager ) {
      }

      protected override void Initialize() {
         LaunchesView<DivisionsListView>();
         Text = "Divisions";
         ToolTip = "Divisions";
         Order = 2;
         IconName = "divisions_settings_menu_icon";
         SeparatorAfter = true;
      }
   }
}