using DuplicateCode.GenericBaseClass.Original;

namespace DuplicateCode.GenericBaseClass.Support {
   public interface IChartSerializer {
      string Serialize( MultichartDefinition chartDef );
      string Serialize( StatboardDefinition chart );
   }
}