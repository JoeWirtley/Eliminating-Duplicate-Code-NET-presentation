using DuplicateCode.GenericBaseClass.Support;

namespace DuplicateCode.GenericBaseClass.Refactored {
   public abstract class MultiChartBase< TChart, TChartDefinition >: Chart, IMultiChart
      where TChart : MultiChartBase<TChart, TChartDefinition>, new()
      where TChartDefinition : class, IChartDefCommon {
      private TChartDefinition _chartDef;

      public abstract string ChartType { get; }
      public abstract string Serialize( IChartSerializer chartSerializer );

      public TChartDefinition MultiChartDefinition {
         get { return _chartDef; }
         set { _chartDef = value; }
      }

      // Explicit interface implementation to support existing code
      IChartDefCommon IMultiChart.MultiChartDefinition {
         get { return _chartDef; }
      }

      public IChartDefCommon ChartDefinition {
         get { return _chartDef; }
      }

      public string Name {
         get { return MultiChartDefinition.Name; }
         set { MultiChartDefinition.Name = value; }
      }

      public Chart Copy( string newChartName ) {
         var newChart = new TChart {
            MultiChartDefinition = MultiChartDefinition,
         };
         newChart.MultiChartDefinition.Name = newChartName;
         return newChart;
      }
   }
}
