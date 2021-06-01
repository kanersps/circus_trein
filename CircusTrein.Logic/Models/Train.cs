using System;
using System.Collections.Generic;
using System.Linq;
using CircusTrein.Common;
using CircusTrein.Logic.Enums;
using CircusTrein.Logic.Models.Animals;
using CircusTrein.Service;

namespace CircusTrein.Logic.Models
{
    public class Train
    {
        public Guid Id { get; set; } = Guid.Empty;
        public List<Wagon> Wagons { get; set; } = new();

        public Train(TrainDTO dto = null)
        {
            if (dto != null)
            {
                Id = dto.Id;
                Wagons = dto.Wagons.Select(wagonDto => new Wagon()
                {
                    
                }).ToList();
            }
        }
        
        public void AddAnimal(Animal animal)
        {
            if (Wagons.Count == 0)
            {
                Wagons.Add(new Wagon());
            }

            foreach (var wagonDto in Wagons)
            {
                var wagon = (Wagon) wagonDto;
                
                if (wagon.AddAnimal(animal) == Error.None)
                {
                    return;
                }
            }

            Wagon newWagon = new Wagon();
            newWagon.AddAnimal(animal);
            Wagons.Add(newWagon);
        }

        public void PrintContents()
        {
            int wagonId = 0;
            
            foreach (Wagon wagon in Wagons)
            {
                wagonId++;
                
                Console.WriteLine($"Wagon: {wagonId} ({wagon.CurrentSize} / {wagon.MaxSize})");

                foreach (var animalDto in wagon.Animals)
                {
                    var animal = (Animal) animalDto;
                    Console.WriteLine($"Carnivore: { animal.Carnivore } | Size: { animal.Size }");
                }
            }
        }

        public void Save()
        {
            ITrainDAL dal = Factory.CreateTrainDAL();
            dal.Save(new TrainDTO()
            {
                Id = Id,
                Wagons = Wagons.Select(wagon => new WagonDTO()
                {
                    Id = wagon.Id,
                    Animals = wagon.Animals.Select(animal => new AnimalDTO()
                    {
                        Id = animal.Id,
                        Carnivore = animal.Carnivore,
                        Size = (int) animal.Size
                    }).ToList(),
                    
                }).ToList()
            });
        }
    }
}