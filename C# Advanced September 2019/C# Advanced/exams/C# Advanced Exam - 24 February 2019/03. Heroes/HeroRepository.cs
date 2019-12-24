using System.Collections.Generic;
using System.Linq;
using System;
using System.Text;

namespace Heroes
{
    class HeroRepository
    {
        private List<Hero> data;

        public HeroRepository()
        {
            this.data = new List<Hero>();
        }
        public int Count => this.data.Count;
        public void Add(Hero hero)
        {
            this.data.Add(hero);
        }
        public void Remove(string name)
        {
            var heroToRemove = this.data.FirstOrDefault(x => x.Name == name);
            if (heroToRemove!=null)
            {
                this.data.Remove(heroToRemove);
            }
        }
        public Hero GetHeroWithHighestStrength()
        {
            var maxStr= this.data.Max(x => x.Item.Strength);
            var hero = this.data.FirstOrDefault(x => x.Item.Strength == maxStr);
            return hero;
        }
        public Hero GetHeroWithHighestAbility()
        {
            var maxAbility = this.data.Max(x => x.Item.Ability);
            var hero = this.data.FirstOrDefault(x => x.Item.Ability == maxAbility);
            return hero;
        }
        public Hero GetHeroWithHighestIntelligence()
        {
            var maxIntelligence = this.data.Max(x => x.Item.Intelligence);
            var hero = this.data.FirstOrDefault(x => x.Item.Intelligence == maxIntelligence);
            return hero;
        }
        public override string ToString()
        {
            var output = new StringBuilder();
            foreach (var hero in this.data)
            {
                output.Append(hero.ToString());
                output.Append(hero.Item.ToString());
            }
            return output.ToString();
        }
    }
}
