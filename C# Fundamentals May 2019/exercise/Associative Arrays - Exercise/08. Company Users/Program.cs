using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Company_Users
{
    class Program
    {
        static void Main(string[] args)
        {
            var companyAndEmployee = new Dictionary<string, List<string>>();
            var input = string.Empty;
            while ((input=Console.ReadLine())!="End")
            {
                var line = input.Split(" -> ");
                var company = line[0];
                var employee = line[1];
                if (!companyAndEmployee.ContainsKey(company))
                {
                    companyAndEmployee[company] = new List<string>(); 
                }
                companyAndEmployee[company].Add(employee);
            }
            foreach (var company in companyAndEmployee.OrderBy(x=>x.Key))
            {
                Console.WriteLine(company.Key);
                foreach (var employee in company.Value.Distinct())
                {
                    Console.WriteLine($"-- {employee}");
                }
            }
        }
    }
}
