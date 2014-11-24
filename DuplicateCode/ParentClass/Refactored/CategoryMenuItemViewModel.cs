using DuplicateCode.ParentClass.Support;

namespace DuplicateCode.ParentClass.Refactored {
   internal class CategoryMenuItemViewModel: MenuItemViewModelBase {
      public CategoryMenuItemViewModel( IRegionManager regionManager ): base( regionManager ) {
      }

      protected override void Initialize() {
         LaunchesView<CategoryListView>();
         Text = "Category";
         ToolTip = "Category";
         Order = 4;
         IconName = "user_list_menu_icon";
      }
   }
}