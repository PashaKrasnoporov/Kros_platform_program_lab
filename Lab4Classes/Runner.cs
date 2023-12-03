using System;

namespace Lab4Classes
{
    public static class Runner
    {
        public static void RunLab(int labNumber, string inputFile, string outputFile)
        {
            switch (labNumber)
            {
                case 1:
                    Lab1.RunLab(inputFile, outputFile);
                    break;
                case 2:
                    Lab2.RunLab(inputFile, outputFile);
                    break;
                case 3:
                    Lab3.RunLab(inputFile, outputFile);
                    break;
                default:
                    throw new ArgumentException("Invalid lab number.");
            }
        }
    }

}