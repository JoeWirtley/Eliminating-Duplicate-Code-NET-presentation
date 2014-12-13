using DuplicateCode.GenericBaseClass.Support;

namespace DuplicateCode.GenericBaseClass.Original {
   public abstract class MultiChartBase: IMultiChart {

      public abstract IChartDefCommon MultiChartDefinition { get; set; }
      public abstract string ChartType { get; }
      public abstract string Serialize( IChartSerializer chartSerializer );
      protected abstract MultiChartBase CreateNewInstance();

      public string Name {
         get { return MultiChartDefinition.Name; }
         set { MultiChartDefinition.Name = value; }
      }

      public IChartDefCommon ChartDefinition {
         get { return MultiChartDefinition; }
      }

      public MultiChartBase Copy( string newChartName ) {
         var newChart = CreateNewInstance();
         newChart.MultiChartDefinition = MultiChartDefinition;
         newChart.MultiChartDefinition.Name = newChartName;
         return newChart;
      }
   }
}