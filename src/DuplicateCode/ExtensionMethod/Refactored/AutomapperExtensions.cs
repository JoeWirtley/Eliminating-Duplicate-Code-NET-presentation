using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows.Input;
using DuplicateCode.ExtensionMethod.Support;

namespace DuplicateCode.ExtensionMethod.Refactored {
   public static class AutoMapperExtensions {
      public static IMappingExpression<TSource, TDestination> IgnoreMember< TSource, TDestination >(
         this IMappingExpression<TSource, TDestination> map,
         Expression<Func<TDestination, object>> destination ) {
         return map.ForMember( destination, opt => opt.Ignore() );
      }

      public static IMappingExpression<TSource, TDestination> ForViewModel< TSource, TDestination >(
         this IMappingExpression<TSource, TDestination> map ) where TDestination : ViewModelBase {
         return map.IgnoreDestinationCommands()
            .IgnoreMember( dest => dest.DoNotRaiseEvents )
            .IgnoreMember( dest => dest.TabRegionManager )
            .IgnoreMember( dest => dest.ViewSettings )
            .IgnoreMember( dest => dest.Container )
            .IgnoreMember( dest => dest.Eventing )
            .IgnoreMember( dest => dest.IsActive )
            .IgnoreMember( dest => dest.DomainEvents );
      }

      private static IMappingExpression<TSource, TDestination> IgnoreDestinationCommands< TSource, TDestination >
         ( this IMappingExpression<TSource, TDestination> expression ) {
         const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;
         var destinationProperties = typeof( TDestination )
            .GetProperties( flags )
            .Where( p => p.PropertyType.GetInterfaces().Contains( typeof( ICommand ) ) );

         foreach ( var property in destinationProperties ) {
            expression.ForMember( property.Name, opt => opt.Ignore() );
         }
         return expression;
      }
   }
}