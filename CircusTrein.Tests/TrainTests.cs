using System.Collections.Generic;
using System.Linq;
using CircusTrein.Logic.Enums;
using CircusTrein.Logic.Models;
using CircusTrein.Logic.Models.Animals;
using NUnit.Framework;

namespace CircusTrein.Tests
{
    public class TrainTests
    {
        [Test]
        public void TestCarnivore()
        {
            Train train = new Train();
            
            train.AddAnimal(new Carnivore(Size.Large));
            train.AddAnimal(new Carnivore(Size.Medium));
            train.AddAnimal(new Carnivore(Size.Medium));
            train.AddAnimal(new Carnivore(Size.Tiny));
            
            train.PrintContents();
            
            if(train.Wagons.Count == 4)
                Assert.Pass();
            else
                Assert.Fail("Wagon count was incorrect");
        }

        [Test]
        public void TestHerbivores()
        {
            Train train = new Train();
            
            for(int i = 0; i < 11; i ++)
                train.AddAnimal(new Herbivore(Size.Tiny));
            
            train.PrintContents();
            
            Assert.AreEqual(train.Wagons.Count, 2);
        }

        [Test]
        public void TestCombined()
        {
            Train train = new Train();
            
            train.AddAnimal(new Carnivore(Size.Large));
            train.AddAnimal(new Carnivore(Size.Medium));
            train.AddAnimal(new Carnivore(Size.Tiny));
            
            for(int i = 0; i < 11; i ++)
                train.AddAnimal(new Herbivore(Size.Tiny));
            
            for(int i = 0; i < 5; i ++)
                
                train.AddAnimal(new Herbivore(Size.Medium));
            
            for(int i = 0; i < 6; i ++)
                train.AddAnimal(new Herbivore(Size.Large));
            
            train.PrintContents();

            foreach (Wagon wagon in train.Wagons)
            {
                foreach (Animal animal in wagon.Animals)
                {
                    if (animal.Carnivore &&
                        wagon.Animals.FirstOrDefault((anim => anim.Size <= animal.Size && animal != anim)) != null)
                    {
                        Assert.Fail("Incorrect sizing for carnivores");
                    }
                }
            }
            
            Assert.AreEqual(train.Wagons.Count, 8);
        }
    }
}