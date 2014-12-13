using System;
using System.Windows.Input;

namespace DuplicateCode.ExtensionMethod.Support {
   public class ViewModelBase {
      public object DoNotRaiseEvents { get; set; }
      public object TabRegionManager { get; set; }
      public object ViewSettings { get; set; }
      public object Container { get; set; }
      public object Eventing { get; set; }
      public object IsActive { get; set; }
      public object DomainEvents { get; set; }
   }

   public class CategoryViewModel: ViewModelBase {
      public Guid Id { get; set; }
      public string Description { get; set; }

      public ICommand SaveCommand { get; set; }
      public ICommand CancelCommand { get; set; }
   }

   public class CategoryModel {
      public Guid Id { get; set; }
      public string Description { get; set; }
   }
}