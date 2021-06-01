using CircusTrein.Logic.Enums;
using CircusTrein.Logic.Models.Animals;
using NUnit.Framework;

namespace CircusTrein.Tests
{
    public class AnimalTests
    {
        [Test]
        public void TestCanBeInWagonHerbivores()
        {
            Herbivore herbivore = new Herbivore(Size.Large);
            Herbivore herbivore2 = new Herbivore(Size.Large);
            
            Assert.AreEqual(Error.None, herbivore.CanBeInWagonWith(herbivore2));
        }
        
        [Test]
        public void TestCanBeInWagonCarnivores()
        {
            Carnivore carnivore = new Carnivore(Size.Medium);
            Carnivore carnivore2 = new Carnivore(Size.Medium);
            
            Assert.AreEqual(Error.TwoCarnivores, carnivore.CanBeInWagonWith(carnivore2));
        }
        
        [Test]
        public void TestCanBeInWagonCombinedTooLarge()
        {
            Carnivore carnivore = new Carnivore(Size.Medium);
            Herbivore herbivore = new Herbivore(Size.Medium);
            
            Assert.AreEqual(Error.CarnivoreSizeTooLarge, carnivore.CanBeInWagonWith(herbivore));
        }
        
        [Test]
        public void TestCanBeInWagonCombined()
        {
            Carnivore carnivore = new Carnivore(Size.Medium);
            Herbivore herbivore = new Herbivore(Size.Large);
            
            Assert.AreEqual(Error.None, carnivore.CanBeInWagonWith(herbivore));
        }
    }
}