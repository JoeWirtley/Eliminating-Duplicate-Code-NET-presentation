using System;
using System.Collections.Generic;

namespace DuplicateCode.ParentClass.Support {
   public interface IRegionManager {
      IRegions Regions { get; set; }
      void RequestNavigate( string regionName, string fullName );
   }

   public interface IRegions {
      IRegion this[ string regionName ] { get; }
   }

   public interface IRegion {
      IEnumerable<IView> Views { get; }
   }

   public interface IView {
   }

   public class DelegateCommand< T > {
      public DelegateCommand( Action<T> onExecute, Func<T, bool> canExecute ) {
      }

      public void RaiseCanExecuteChanged() {
      }
   }
}