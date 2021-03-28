// This file was auto-generated by ML.NET Model Builder. 

using System;
using SimulationML.Model;

namespace SimulationML.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create single instance of sample data from first line of dataset for model input
            ModelInput sampleData = new ModelInput()
            {
                Distance = 11.21922F,
                S = 0.3975029F,
                SW = 0.562154F,
                W = 0.7475F,
                NW = 1F,
                N = 1F,
                NE = 0.3500178F,
                E = 0.2475F,
                SE = 0.3500179F,
                Car_Dir = 0F,
                Fire_Dir_X = 10.15F,
                Fire_Dir_Y = -4.78F,
            };

            // Make a single prediction on the sample data and print results
            var predictionResult = ConsumeModel.Predict(sampleData);

            Console.WriteLine("Using model to make single prediction -- Comparing actual Output with predicted Output from sample data...\n\n");
            Console.WriteLine($"Distance: {sampleData.Distance}");
            Console.WriteLine($"S: {sampleData.S}");
            Console.WriteLine($"SW: {sampleData.SW}");
            Console.WriteLine($"W: {sampleData.W}");
            Console.WriteLine($"NW: {sampleData.NW}");
            Console.WriteLine($"N: {sampleData.N}");
            Console.WriteLine($"NE: {sampleData.NE}");
            Console.WriteLine($"E: {sampleData.E}");
            Console.WriteLine($"SE: {sampleData.SE}");
            Console.WriteLine($"Car_Dir: {sampleData.Car_Dir}");
            Console.WriteLine($"Fire_Dir_X: {sampleData.Fire_Dir_X}");
            Console.WriteLine($"Fire_Dir_Y: {sampleData.Fire_Dir_Y}");
            Console.WriteLine($"\n\nPredicted Output value {predictionResult.Prediction} \nPredicted Output scores: [{String.Join(",", predictionResult.Score)}]\n\n");
            Console.WriteLine("=============== End of process, hit any key to finish ===============");
            Console.ReadKey();
        }
    }
}
