using CircusTrein.Logic.Enums;
using CircusTrein.Logic.Models;
using CircusTrein.Logic.Models.Animals;
using NUnit.Framework;

namespace CircusTrein.Tests
{
    public class WagonTests
    {
        [Test]
        public void TestWagon()
        {
            Wagon wagon = new Wagon();
            wagon.AddAnimal(new Herbivore(Size.Large));

            Assert.AreEqual(Error.None, wagon.AddAnimal(new Herbivore(Size.Medium)));
        }
        
        [Test]
        public void TestWagonTooMany()
        {
            Wagon wagon = new Wagon();
            wagon.AddAnimal(new Herbivore(Size.Large));
            wagon.AddAnimal(new Herbivore(Size.Large));

            Assert.AreEqual(Error.TooLarge, wagon.AddAnimal(new Herbivore(Size.Medium)));
        }
        
        [Test]
        public void TestWagonTooManyCarnivores()
        {
            Wagon wagon = new Wagon();
            wagon.AddAnimal(new Carnivore(Size.Tiny));

            Assert.AreEqual(Error.TwoCarnivores, wagon.AddAnimal(new Carnivore(Size.Large)));
        }
        
        [Test]
        public void TestWagonHerbivoreAndCarnivore()
        {
            Wagon wagon = new Wagon();
            wagon.AddAnimal(new Carnivore(Size.Tiny));

            Assert.AreEqual(Error.None, wagon.AddAnimal(new Herbivore(Size.Large)));
        }
    }
}