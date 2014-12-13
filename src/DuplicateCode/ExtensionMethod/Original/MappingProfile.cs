using DuplicateCode.ExtensionMethod.Support;

namespace DuplicateCode.ExtensionMethod.Original {
   public class MappingProfile: Profile {
      protected override void Configure() {
         Mapper.CreateMap<CategoryModel, CategoryViewModel>()
            // Base class properties to ignore
            .ForMember( dest => dest.DoNotRaiseEvents, opt => opt.Ignore() )
            .ForMember( dest => dest.TabRegionManager, opt => opt.Ignore() )
            .ForMember( dest => dest.ViewSettings, opt => opt.Ignore() )
            .ForMember( dest => dest.Container, opt => opt.Ignore() )
            .ForMember( dest => dest.Eventing, opt => opt.Ignore() )
            .ForMember( dest => dest.IsActive, opt => opt.Ignore() )
            .ForMember( dest => dest.DomainEvents, opt => opt.Ignore() )

            // Commands to ignore
            .ForMember( dest => dest.SaveCommand, opt => opt.Ignore() )
            .ForMember( dest => dest.CancelCommand, opt => opt.Ignore() );

         Mapper.CreateMap<CategoryViewModel, CategoryModel>();
      }
   }
}