using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _05._Nether_Realms
{
    class Program
    {
        static void Main(string[] args)
        {
            //80/100 pts;
            var healthPattern = @"[A-Za-z]?";
            var damagePattern = @"([-+]?[0-9]*\.?[0-9]+)";
            var multiplyOrDividePattern = @"[*/]";
            var input = Console.ReadLine().Split(new[] {',',' ','\t'},StringSplitOptions.RemoveEmptyEntries);
            var NameHealthAndDamage = new Dictionary<string, Dictionary<int, double>>();
            for (int i = 0; i < input.Length; i++)
            {
                var currentName = input[i];
                var health = 0;
                var damage = 0.0;
                var regex = new Regex(healthPattern);
                var matches = regex.Matches(currentName);
                var sb = new StringBuilder();
                foreach (var match in matches)
                {
                    sb.Append(match);
                }
                for (int j = 0; j < sb.Length; j++)
                {
                    var ch = sb[j];
                    health += (int)ch;
                }
                regex = new Regex(damagePattern);
                matches = regex.Matches(currentName);
                
                foreach (var match in matches)
                {
                    var currentDigit = match.ToString();
                    damage += double.Parse(currentDigit);
                }
                regex = new Regex(multiplyOrDividePattern);
                matches = regex.Matches(currentName);
                foreach (var match in matches)
                {
                    if (match.ToString().Equals("*"))
                    {
                        damage *= 2;
                    }
                    else
                    {
                        damage /= 2;
                    }
                }
                if (!NameHealthAndDamage.ContainsKey(currentName))
                {
                    NameHealthAndDamage[currentName] = new Dictionary<int, double>();
                }
                NameHealthAndDamage[currentName][health] = damage;
            }
            NameHealthAndDamage = NameHealthAndDamage
                .OrderBy(x => x.Key)
                .ToDictionary(k => k.Key, v => v.Value);
            foreach (var name in NameHealthAndDamage)
            {
                var currentName = name.Key;
                foreach (var healthAndDamage in name.Value)
                {
                    Console.WriteLine($"{currentName} - {healthAndDamage.Key} health, {healthAndDamage.Value:f2} damage ");
                }
            }
        }
    }
}
