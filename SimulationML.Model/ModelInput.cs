// This file was auto-generated by ML.NET Model Builder. 

using Microsoft.ML.Data;

namespace SimulationML.Model
{
    public class ModelInput
    {
        [ColumnName("Distance"), LoadColumn(0)]
        public float Distance { get; set; }


        [ColumnName("S"), LoadColumn(1)]
        public float S { get; set; }


        [ColumnName("SW"), LoadColumn(2)]
        public float SW { get; set; }


        [ColumnName("W"), LoadColumn(3)]
        public float W { get; set; }


        [ColumnName("NW"), LoadColumn(4)]
        public float NW { get; set; }


        [ColumnName("N"), LoadColumn(5)]
        public float N { get; set; }


        [ColumnName("NE"), LoadColumn(6)]
        public float NE { get; set; }


        [ColumnName("E"), LoadColumn(7)]
        public float E { get; set; }


        [ColumnName("SE"), LoadColumn(8)]
        public float SE { get; set; }


        [ColumnName("Car_Dir"), LoadColumn(9)]
        public float Car_Dir { get; set; }


        [ColumnName("Fire_Dir_X"), LoadColumn(10)]
        public float Fire_Dir_X { get; set; }


        [ColumnName("Fire_Dir_Y"), LoadColumn(11)]
        public float Fire_Dir_Y { get; set; }


        [ColumnName("Output"), LoadColumn(12)]
        public string Output { get; set; }


    }
}
