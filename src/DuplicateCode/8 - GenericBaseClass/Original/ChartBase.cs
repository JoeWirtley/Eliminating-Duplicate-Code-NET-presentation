using DuplicateCode.GenericBaseClass.Support;

namespace DuplicateCode.GenericBaseClass.Original {
   public abstract class ChartBase: VisualObject, IChart {
      public abstract IChartDefCommon ChartDefinition { get; set; }
      public abstract string Serialize( IChartSerializer chartSerializer );
      protected abstract ChartBase CreateNewInstance();

      public string Name {
         get { return ChartDefinition.Name; }
         set { ChartDefinition.Name = value; }
      }

      public VisualObject Copy( string newChartName ) {
         var newChart = CreateNewInstance();
         newChart.ChartDefinition = ChartDefinition;
         newChart.ChartDefinition.Name = newChartName;
         return newChart;
      }
   }
}