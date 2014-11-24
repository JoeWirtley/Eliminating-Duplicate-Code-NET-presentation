namespace DuplicateCode.ParentClass.Support {
   public interface IMenuItemViewModel {
      DelegateCommand<object> Command { get; }
      string Text { get; }
      string ToolTip { get; }
      int Order { get; }
      bool SeparatorAfter { get; }
      string IconName { get; }
      bool Visible { get; set; }
   }
}