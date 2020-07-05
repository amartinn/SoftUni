using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SoftUni
{
   public class StartUp
    {
       public static void Main()
        {

            using var context = new SoftUniContext();
                Console.WriteLine(RemoveTown(context));
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var sb = new StringBuilder();
            var employees = context
                  .Employees
                  .Select(e => new
                  {
                      e.FirstName,
                      e.MiddleName,
                      e.LastName,
                      e.Salary,
                      e.JobTitle
                  }).ToList();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
            }
            return sb.ToString().TrimEnd();
        }
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {

            var sb = new StringBuilder();
            var employees = context
                  .Employees
                  .Select(e => new
                  {
                      e.FirstName,
                      e.Salary,
                  })
                  .Where(e => e.Salary > 50000)
                  .OrderBy(e => e.FirstName)
                  .ToList();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
            }
            return sb.ToString().TrimEnd();
        }
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var sb = new StringBuilder();
            var employees = context
                  .Employees
                   .Where(x => x.Department.Name == "Research and Development")
                  .Select(e => new
                  {
                      e.FirstName,
                      e.LastName,
                      DepartmentName = e.Department.Name,
                      e.Salary
                  })
                  .OrderBy(x=>x.Salary)
                  .ThenByDescending(x => x.FirstName)
                  .ToList();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.DepartmentName} - ${employee.Salary:f2}");
            }
            return sb.ToString().TrimEnd();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var newAdress = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
        };
            var nakovEmployee = context.Employees.FirstOrDefault(x => x.LastName == "Nakov");
            nakovEmployee.Address = newAdress;
            context.SaveChanges();

            var adresses = context.
                Employees
                .OrderByDescending(x => x.AddressId)
                .Take(10)
                .Select(e => e.Address.AddressText);
            var sb = new StringBuilder();
            foreach (var adress in adresses)
            {
                sb.AppendLine(adress);
            }
            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var dateTimeFormat = "M/d/yyyy h:mm:ss tt";
            var employees = context
                .Employees
                .Where(e => e.EmployeesProjects.Any(x => x.Project.StartDate.Year >= 2001 && x.Project.StartDate.Year <= 2003))
                .Take(10)
                .Select(e => new
                {
                    Name = $"{ e.FirstName} {e.LastName}",
                    ManagerName = $"{e.Manager.FirstName} {e.Manager.LastName}",
                    Projects = e.EmployeesProjects.
                    Select(p => new {
                     p.Project.Name,
                    StartDate = p.Project.StartDate.ToString(dateTimeFormat,CultureInfo.InvariantCulture),
                    EndDate = p.Project.EndDate == null ? "not finished" : ((DateTime)p.Project.EndDate).ToString(dateTimeFormat,CultureInfo.InvariantCulture)
                    }).ToList()
                }).ToList();
            var sb = new StringBuilder();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.Name} - Manager: {employee.ManagerName}");
                foreach (var project in employee.Projects)
                {
                    sb.AppendLine($"--{project.Name} - {project.StartDate} - {project.EndDate}");
                }
            }
            return sb.ToString().TrimEnd();
                
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var adresses = context
                .Addresses
                .OrderByDescending(x => x.Employees.Count())
                .ThenBy(x => x.Town.Name)
                .ThenBy(x => x.AddressText)
                .Take(10)
                .Select(a => new
                {
                    a.AddressText,
                    TownName = a.Town.Name,
                    EmployeeCount = a.Employees.Count()
                })
                .ToList();
            var sb = new StringBuilder();
            foreach (var adress in adresses)
            {
                sb.AppendLine($"{adress.AddressText}, {adress.TownName} - {adress.EmployeeCount} employees");
            }
            return sb.ToString().TrimEnd();
        }
        public static string GetEmployee147(SoftUniContext context)
        {
            var employee147 = context
                .Employees
                .Single(x => x.EmployeeId == 147);

            var employee147Projects = context
                .EmployeesProjects
                .Where(x=>x.EmployeeId==147)
                .Select(x => x.Project.Name)
                .OrderBy(x=>x)
                .ToList();

            var result = $"{employee147.FirstName} {employee147.LastName} - {employee147.JobTitle}";
            foreach (var projectName in employee147Projects)
            {
                result += Environment.NewLine + projectName;
            }
            return result.TrimEnd();
               
                
        }
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context
                .Departments
                .Where(x => x.Employees.Count() > 5)
                .OrderBy(x => x.Employees.Count())
                .ThenBy(x => x.Name)
                .Select(d => new
                {
                    d.Name,
                    ManagerFirstName = d.Manager.FirstName,
                    ManagerLastName = d.Manager.LastName,
                    departmentEmployees = d.Employees.Select(e => new
                    {
                        e.FirstName,
                        e.LastName,
                        e.JobTitle
                    })
                    .OrderBy(x => x.FirstName)
                    .ThenBy(x => x.LastName)
                    .ToList()
                })
                .ToList();
                
            var sb = new StringBuilder();

            foreach (var department in departments)
            {
                sb.AppendLine($"{department.Name} - {department.ManagerFirstName} {department.ManagerLastName}");
                foreach (var employee in department.departmentEmployees)
                {
                    sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }
            return sb.ToString().TrimEnd();
        }
        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context
                .Projects
                .OrderByDescending(x => x.StartDate)
                .Take(10)
                .Select(x => new
                {
                    x.Name,
                    x.Description,
                    StartDate = x.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                })
                .OrderBy(x => x.Name);
            var sb = new StringBuilder();

            foreach (var project in projects)
            {
                sb.AppendLine(project.Name);
                sb.AppendLine(project.Description);
                sb.AppendLine(project.StartDate);
            }
            return sb.ToString().TrimEnd();
        }
        public static string IncreaseSalaries(SoftUniContext context)
        {
            var desiredDepartments = new List<string>()
            {
                "Engineering",
                "Tool Design",
                "Marketing",
                "Information Services"
            };
            var increaseRate = 1.12m;

            var employees = context
                .Employees
                .Where(x => desiredDepartments.Contains(x.Department.Name))
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    Salary = x.Salary * increaseRate
                })
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList(); 
            var sb = new StringBuilder();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:f2})");
            }
            return sb.ToString().TrimEnd();
        }
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context
                .Employees
                .Where(x => x.FirstName.Substring(0,2) == ("Sa"))
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.JobTitle,
                    x.Salary
                })
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();

            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:f2})");
            }
            return sb.ToString().TrimEnd();
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            var project = context
                .Projects.Single(x=>x.ProjectId == 2);

            context
                .EmployeesProjects
                .ToList()
                .ForEach(ep => context.EmployeesProjects.Remove(ep));

            context.Projects.Remove(project);

            context.SaveChanges();
            var sb = new StringBuilder();

            var projects = context
                .Projects
                .Take(10)
                .Select(x => x.Name)
                .ToList();
            foreach (var name in projects)
            {
                sb.AppendLine(name);
            }
            return sb.ToString().TrimEnd();
        }

        public static string RemoveTown(SoftUniContext context)
        {
            var townName = "Seattle";
            var adressCount = context
                .Employees
                .Where(x => x.Address.Town.Name == townName)
                .ToList()
                .Count();

            context.Employees
                   .Where(e => e.Address.Town.Name == townName)
                   .ToList()
                   .ForEach(e => e.AddressId = null);

            int addressesCount = context.Addresses
                .Where(a => a.Town.Name == townName)
                .Count();

            context.Addresses
                .Where(a => a.Town.Name == townName)
                .ToList()
                .ForEach(a => context.Addresses.Remove(a));

            context.Towns
                .Remove(context.Towns
                    .SingleOrDefault(t => t.Name == townName));

            context.SaveChanges();

            return $"{adressCount} addresses in Seattle were deleted";
        }
    }
}
