using DuplicateCode.GenericBaseClass.Support;

namespace DuplicateCode.GenericBaseClass.Original {
   public class Statboard: MultiChartBase {
      private StatboardDefinition _chartDef;

      public Statboard() {
      }

      public Statboard( StatboardDefinition chartDef ) {
         _chartDef = chartDef;
      }

      public override IChartDefCommon MultiChartDefinition {
         get { return _chartDef; }
         set { _chartDef = ( StatboardDefinition ) value; }
      }

      protected override MultiChartBase CreateNewInstance() {
         return new Statboard();
      }

      public override string ChartType {
         get { return StatboardDefinition.ChartTypeKey; }
      }

      public override string Serialize( IChartSerializer chartSerializer ) {
         return chartSerializer.Serialize( _chartDef );
      }
   }
}