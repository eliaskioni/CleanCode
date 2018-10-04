﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liquid
{
    // Read from a csv file
    // Get the total value of insured houses
    // Store the Value by country
    // The last line must have the total and the current date
    // -----
    // Client 1: Ignore Residential type of housing.
    // Client 2: Ignore Commercial type of housing.
    class Program
    {
        static void Main(string[] args)
        {
            var client = 2;
            var fileLines = File.ReadAllLines(".\\FL_insurance_sample.csv");
            var output = new StreamWriter(File.OpenWrite("MyOutput.csv"));
            output.WriteLine($"Country,Value");
            var total = 0.0;
            for (var i = 1; i < fileLines.Length; i++)
            {
                if (double.TryParse(fileLines[i].Split(',')[8], NumberStyles.Any, CultureInfo.InvariantCulture, out var value))
                {
                    if (client == 1)
                    {
                        if (fileLines[i].Split(',')[15] == "Residential")
                        {
                            output.WriteLine($"{fileLines[i].Split(',')[3]},{value.ToString("F2", CultureInfo.InvariantCulture)}");
                            total += value;
                        }
                    }
                    if (client == 2)
                    {
                        if (fileLines[i].Split(',')[15] == "Commercial")
                        {
                            output.WriteLine($"{fileLines[i].Split(',')[3]},{value.ToString("F2", CultureInfo.InvariantCulture)}");
                            total += value;
                        }
                    }
                }
            }

            output.WriteLine("{0},{1}", total.ToString("F2", CultureInfo.InvariantCulture), DateTime.Now.ToString("d", CultureInfo.InvariantCulture));
            output.Flush();
            output.Close();
        }
    }
}