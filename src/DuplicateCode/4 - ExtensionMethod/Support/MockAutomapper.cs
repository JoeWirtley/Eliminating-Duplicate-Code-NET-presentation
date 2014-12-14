using System;
using System.Linq.Expressions;

namespace DuplicateCode.ExtensionMethod.Support {
   public class Mapper {
      public static IMappingExpression<T, T1> CreateMap<T, T1>() {
         throw new NotImplementedException();
      }
   }

   public class Profile {
      protected virtual void Configure() {
         throw new NotImplementedException();
      }
   }

   public interface IMappingExpression< TSource, TDestination > {
      IMappingExpression<TSource, TDestination> ForMember( Expression<Func<TDestination, object>> destinationMember,
         Action<IMemberConfigurationExpression<TSource>> memberOptions );

      IMappingExpression<TSource, TDestination> ForMember( string name, Action<IMemberConfigurationExpression<TSource>> memberOptions );
      void ForAllMembers( Action<IMemberConfigurationExpression<TSource>> memberOptions );

      IMappingExpression<TSource, TDestination> Include< TOtherSource, TOtherDestination >()
         where TOtherSource : TSource
         where TOtherDestination : TDestination;

      IMappingExpression<TSource, TDestination> WithProfile( string profileName );
      IMappingExpression<TSource, TDestination> BeforeMap( Action<TSource, TDestination> beforeFunction );
      IMappingExpression<TSource, TDestination> AfterMap( Action<TSource, TDestination> afterFunction );
      IMappingExpression<TSource, TDestination> ConstructUsing( Func<TSource, TDestination> ctor );
   }

   public interface IMemberConfigurationExpression< TSource > {
      void NullSubstitute( object nullSubstitute );
      void MapFrom( Func<TSource, object> sourceMember );
      void Ignore();
      void SetMappingOrder( int mappingOrder );
      void UseDestinationValue();
   }

   public interface IValueResolver {
      ResolutionResult Resolve( ResolutionResult source );
   }

   public class ResolutionResult {
      public object Value { get; private set; }
      public Type Type { get; private set; }
      public Type MemberType { get; private set; }
   }

}