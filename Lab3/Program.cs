// Lab 3
// Student name:Yuhe Luo
// Student number:83212530

using System;
using System.Collections.Generic;

Console.WriteLine("CPEN223 Lab 3");

//Testing: Write some test cases to test well all methods you are to implement    
//         This is to demonstrates what test cases you have considered
//TODO 
// bool actual = SensorAnalyzer.IsUsableReading(21.5, 0.0, 50.0);
// Console.WriteLine($"Expected: True, Actual: {actual}");


//end Testing code

//Do not change the program skeleton
public static class SensorAnalyzer
{
    public static bool IsUsableReading(
        double reading, double minimum, double maximum)
    {
        if(!double.IsFinite(minimum)||
           !double.IsFinite(maximun)||
           minimum > maximum)
        {throw new ArguemntException();
        }
        return double.IsFinite(reading)
        && reading>=minimum
        && reading<=maximun;
    }

    public static List<double> CleanReadings(
        IReadOnlyList<double> readings, double minimum, double maximum)
    {
        if (readings == null ||
            !double.IsFinite(minimum) ||
            !double.IsFinite(maximum) ||
            minimum > maximum)
        {
            throw new ArgumentException();
        }

        List<double> result = new List<double>();

        foreach (double reading in readings)
        {
            if (IsUsableReading(reading, minimum, maximum))
            {
                result.Add(reading);
            }
        }
        return result;
    }

    public static bool ContainsApproximately(
        IReadOnlyList<double> readings, double target, double tolerance)
    {
        if (readings == null ||
            !double.IsFinite(target) ||
            !double.IsFinite(tolerance) ||
            tolerance < 0)
        {
            throw new ArgumentException();
        }
        foreach (double reading in readings)
        {
            if (double.IsFinite(reading) &&
                Math.Abs(reading - target) <= tolerance)
            {
                return true;
            }
        }
        return false;
    }

    public static List<double> MovingAverage(
        IReadOnlyList<double> readings, int windowSize)
    {
        if (readings == null || windowSize <= 0)
        {
            throw new ArgumentException();
        }
        foreach (double reading in readings)
        {
            if (!double.IsFinite(reading))
            {
                throw new ArgumentException();
            }
        }
        List<double> result = new List<double>();
        if (windowSize > readings.Count)
        {
            return result;
        }
        for (int i = 0; i <= readings.Count - windowSize; i++)
        {
            double sum = 0.0;
            for (int j = 0; j < windowSize; j++)
            {
                sum += readings[i + j];
            }
            result.Add(sum / windowSize);
        }
        return result;
    }
}
