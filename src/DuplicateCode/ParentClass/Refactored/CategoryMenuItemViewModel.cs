using DuplicateCode.ParentClass.Support;

namespace DuplicateCode.ParentClass.Refactored {
   internal class CategoryMenuItemViewModel: MenuItemViewModelBase {
      public CategoryMenuItemViewModel( IRegionManager regionManager ): base( regionManager ) {
      }

      protected override void Initialize() {
         LaunchesView<CategoryListView>();
         Text = "Categories";
         ToolTip = "Categories";
         Order = 4;
         IconName = "categories_menu_icon";
      }
   }
}