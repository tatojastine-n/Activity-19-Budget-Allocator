using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget_Allocator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] categories = { "Food", "Rent", "Utilities", "Transport", "Others" };
            decimal[] expenses = new decimal[categories.Length];
            decimal monthlyIncome = 25000m;

            Console.WriteLine("Enter your budget for the following categories:");

            for (int i = 0; i < categories.Length; i++)
            {
                Console.Write($"{categories[i]}: ");
                while (!decimal.TryParse(Console.ReadLine(), out expenses[i]) || expenses[i] < 0)
                {
                    Console.WriteLine("Invalid input. Please enter a non-negative number.");
                    Console.Write($"{categories[i]}: ");
                }
            }

            decimal totalExpenses = 0;
            for (int i = 0; i < expenses.Length; i++)
            {
                totalExpenses += expenses[i];
            }

            Console.WriteLine($"\nTotal Expenses: {totalExpenses:C}");
            Console.WriteLine($"Monthly Income: {monthlyIncome:C}");

            if (totalExpenses > monthlyIncome)
            {
                Console.WriteLine("You are over budget!");
                // Find the category with the highest expense
                decimal maxExpense = expenses[0];
                string categoryToCut = categories[0];

                for (int i = 1; i < expenses.Length; i++)
                {
                    if (expenses[i] > maxExpense)
                    {
                        maxExpense = expenses[i];
                        categoryToCut = categories[i];
                    }
                }

                Console.WriteLine($"Consider reducing your budget in the '{categoryToCut}' category.");
            }
            else
            {
                Console.WriteLine("You are within your budget.");
            }
        }
    }
}
