using DuplicateCode.ExtensionMethod.Support;

namespace DuplicateCode.ExtensionMethod.Refactored {
   public class MappingProfile: Profile {
      protected override void Configure() {
         Mapper.CreateMap<CategoryModel, CategoryViewModel>()
            .ForViewModel();

         Mapper.CreateMap<CategoryViewModel, CategoryModel>();
      }
   }
}