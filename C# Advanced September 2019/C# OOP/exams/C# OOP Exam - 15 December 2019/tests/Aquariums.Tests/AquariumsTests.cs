namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    public class AquariumsTests
    {

        [Test]
        public void Property_Name_Should_Be_Correct()
        {
            var aquarium = new Aquarium("name", 15);
            var expected = "name";
            Assert.AreEqual(expected, aquarium.Name);
        }
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Property_Name_Should_Throw_ArgumentNullException(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            new Aquarium(name, 15));
        }

        [Test]
        public void Property_Capacity_Should_Be_Correct()
        {
            var aquarium = new Aquarium("name", 15);
            var expected = 15;
            Assert.AreEqual(expected, aquarium.Capacity);
        }
        [Test]
        [TestCase(-1)]
        public void Property_Capacity_Should_Throw_ArgumentNullException(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
           new Aquarium("name", capacity));
        }
        [Test]
        public void Add_Method_Should_Add_Fish()
        {
            var aquarium = new Aquarium("2", 12);
            aquarium.Add(new Fish("name"));
            var expected = aquarium.Count;
            Assert.AreEqual(expected, 1);
        }
        [Test]
        public void Add_Method_Should_Throw_InvalidOperationException_When_Aquarium_Is_Full()
        {
            var aquarium = new Aquarium("2", 2);
            aquarium.Add(new Fish("name"));
            aquarium.Add(new Fish("name"));

            Assert.Throws<InvalidOperationException>(() =>
            aquarium.Add(new Fish("name")));
        }
        [Test]
        public void Remove_Method_Should_Remove_Fish()
        {
            var aquarium = new Aquarium("2", 12);
            aquarium.Add(new Fish("name"));
            aquarium.RemoveFish("name");
            var expected = 0;
            Assert.AreEqual(expected, aquarium.Count);
        }
        [Test]
        [TestCase("No")]
        [TestCase(null)]
        [TestCase("")]
        public void Remove_Method_Should_Throw_InvalidOperationException_When_Fish_Is_Null(string name)
        {
            var aquarium = new Aquarium("2", 2);
            Assert.Throws<InvalidOperationException>(() =>
            aquarium.RemoveFish(name));
        }
        [Test]
        [TestCase("No")]
        [TestCase(null)]
        [TestCase("")]
        public void SellFish_Method_Should_Throw_InvalidOperationException_When_Fish_Is_Null(string name)
        {
            var aquarium = new Aquarium("2", 2);
            Assert.Throws<InvalidOperationException>(() =>
            aquarium.SellFish(name));
        }
        [Test]
        public void SellFish_Method_Should_Change_Availability_When_Fish_Is_Sold()
        {
            var aquarium = new Aquarium("2", 2);
            var fish = new Fish("name");
            aquarium.Add(fish);
            aquarium.SellFish("name");
           var expected = false;
            Assert.AreEqual(expected, fish.Available);
           
        }
        [Test]
        public void SellFish_Method_Should_Return_Fish()
        {
            var aquarium = new Aquarium("2", 2);
            var fish = new Fish("name");
            aquarium.Add(fish);
           var soldFish= aquarium.SellFish("name");
            Assert.AreEqual(fish, soldFish);
        }
        [Test] 
        public void Report_Method_Should_Work_Correctly()
        {
            var aquarium = new Aquarium("Aqua", 15);
            aquarium.Add(new Fish("1"));
            aquarium.Add(new Fish("2"));
            aquarium.Add(new Fish("3"));
            var expected = "Fish available at Aqua: 1, 2, 3";
            Assert.AreEqual(expected, aquarium.Report());
        }
        [Test]
        public void Report_Method_Should_Work_Corectly_Without_Fishes()
        {
            var aquarium = new Aquarium("Aqua", 15);
            var expected = "Fish available at Aqua: ";
            Assert.AreEqual(expected, aquarium.Report());
        }
        [Test]
        public void Property_Count_Should_Work_Correctly()
        {
            var aquarium = new Aquarium("name", 5);
            aquarium.Add(new Fish("asd"));
            aquarium.Add(new Fish("asd"));
            aquarium.Add(new Fish("asd"));
            aquarium.Add(new Fish("asd"));
            aquarium.Add(new Fish("asd"));
            var expected = 5;
            Assert.AreEqual(expected, aquarium.Count);
        }
    }
}
