using DuplicateCode.GenericBaseClass.Support;

namespace DuplicateCode.GenericBaseClass.Original {
   public class Statboard: ChartBase {
      private StatboardDefinition _chartDef;

      public Statboard() {
      }

      public Statboard( StatboardDefinition chartDef ) {
         _chartDef = chartDef;
      }

      public override IChartDefCommon ChartDefinition {
         get { return _chartDef; }
         set { _chartDef = ( StatboardDefinition ) value; }
      }

      protected override ChartBase CreateNewInstance() {
         return new Statboard();
      }

      public override string Serialize( IChartSerializer chartSerializer ) {
         return chartSerializer.Serialize( _chartDef );
      }
   }
}