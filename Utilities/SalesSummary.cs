using System.Text;

namespace PizzaApi.Utilities
{
    public class SalesSummary
    {
        public static void GenerateSalesSummary(string directoryPath)
        {
            string[] files = Directory.GetFiles(directoryPath, "*.txt");

            decimal totalSales = 0;
            Dictionary<string, decimal> details = new();

            foreach (var file in files)
            {
                decimal fileTotal = 0;

                foreach (var line in File.ReadLines(file))
                {
                    if (decimal.TryParse(line, out decimal value))
                    {
                        fileTotal += value;
                    }
                }

                details[file] = fileTotal;
                totalSales += fileTotal;
            }

            StringBuilder report = new();

            report.AppendLine("Sales Summary");
            report.AppendLine("----------------------------");
            report.AppendLine($"Total Sales: {totalSales:C}");
            report.AppendLine();
            report.AppendLine("Details:");

            foreach (var item in details)
            {
                report.AppendLine($"{Path.GetFileName(item.Key)}: {item.Value:C}");
            }

            File.WriteAllText(
                Path.Combine(directoryPath, "sales_summary.txt"),
                report.ToString()
            );

            Console.WriteLine(report.ToString());
        }
    }
}