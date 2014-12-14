using DuplicateCode.GenericBaseClass.Support;

namespace DuplicateCode.GenericBaseClass.Refactored {
   public abstract class ChartBase< TChart, TChartDefinition >: VisualObject, IChart
      where TChart : ChartBase<TChart, TChartDefinition>, new() 
      where TChartDefinition : IChartDefCommon {
      private TChartDefinition _chartDef;

      public abstract string Serialize( IChartSerializer chartSerializer );

      public TChartDefinition ChartDefinition {
         get { return _chartDef; }
         set { _chartDef = value; }
      }

      // Explicit interface implementation to support existing code
      IChartDefCommon IChart.ChartDefinition {
         get { return _chartDef; }
      }

      public string Name {
         get { return ChartDefinition.Name; }
         set { ChartDefinition.Name = value; }
      }

      public VisualObject Copy( string newChartName ) {
         var newChart = new TChart {
            ChartDefinition = ChartDefinition,
         };
         newChart.ChartDefinition.Name = newChartName;
         return newChart;
      }
   }
}
