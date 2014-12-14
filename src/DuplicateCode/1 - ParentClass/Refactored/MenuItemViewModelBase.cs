using System;
using System.Linq;
using DuplicateCode.ParentClass.Support;

namespace DuplicateCode.ParentClass.Refactored {
   public abstract class MenuItemViewModelBase: IMenuItemViewModel {
      private Type _viewToLaunch = null;
      private bool _visible = true;

      protected MenuItemViewModelBase( IRegionManager regionManager ) {
         RegionManager = regionManager;
         SeparatorAfter = false;
         Command = new DelegateCommand<object>( OnExecute, CanExecute );
         IconName = "";
         Initialize();
      }                                                            

      protected abstract void Initialize();

      protected virtual void OnExecute( object obj ) {
         if ( _viewToLaunch != null ) {
            RegionManager.RequestNavigate( Regions.Main, _viewToLaunch.FullName );
         }
      }

      protected virtual bool CanExecute( object arg ) {
         return ( _viewToLaunch == null || !IsViewOpen( _viewToLaunch ) );
      }

      private bool IsViewOpen( Type viewType ) {
         return RegionManager.Regions[ Regions.Main ].Views.Any( v => v.GetType() == viewType );
      }

      protected bool IsViewOpen< T >() {
         return RegionManager.Regions[ Regions.Main ].Views.Any( v => v.GetType() == typeof( T ) );
      }

      protected IRegionManager RegionManager { get; set; }

      public DelegateCommand<object> Command { get; private set; }
      public string Text { get; protected set; }
      public string ToolTip { get; protected set; }
      public int Order { get; protected set; }
      public bool SeparatorAfter { get; protected set; }
      public string IconName { get; protected set; }


      public bool Visible {
         get { return _visible; }
         set { _visible = value; }
      }

      protected void LaunchesView< T >() {
         _viewToLaunch = typeof( T );
      }
   }
}