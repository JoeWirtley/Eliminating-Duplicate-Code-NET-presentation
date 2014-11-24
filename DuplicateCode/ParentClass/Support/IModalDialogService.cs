using System;

namespace DuplicateCode.ParentClass.Original {
   internal interface IModalDialogService {
      void Show< T >( Action<T> onCloseDialog );
   }
}