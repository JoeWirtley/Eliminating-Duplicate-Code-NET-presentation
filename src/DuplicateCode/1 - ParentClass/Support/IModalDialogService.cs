using System;

namespace DuplicateCode.ParentClass.Support {
   public interface IModalDialogService {
      void Show< T >( Action<T> onCloseDialog );
   }
}