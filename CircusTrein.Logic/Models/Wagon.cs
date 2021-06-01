using System;
using System.Collections.Generic;
using System.Linq;
using CircusTrein.Common;
using CircusTrein.Logic.Enums;
using CircusTrein.Logic.Models.Animals;

namespace CircusTrein.Logic.Models
{
    public class Wagon
    {
        public Guid Id { get; }

        public int CurrentSize
        {
            get
            {
                return Animals.Sum(animal => (int)animal.Size);
            }
        }

        public int MaxSize { get; } = 10;
        public List<Animal> Animals { get; } = new List<Animal>();
        public Wagon(WagonDTO dto = null)
        {
            // Todo: ask how to improve this
            if (dto != null)
            {
                Id = dto.Id;

                foreach (AnimalDTO animal in dto.Animals)
                {
                    if (animal.Carnivore)
                    {
                        Animals.Add(new Carnivore((Size)animal.Size));
                    }
                    else
                    {
                        Animals.Add(new Herbivore((Size)animal.Size));
                    }
                }
            }
        }
        
        public Error AddAnimal(Animal animal)
        {
            if ((CurrentSize + (int) animal.Size) > MaxSize)
            {
                return Error.TooLarge;
            }

            foreach (Animal _animal in Animals)
            {
                Error err = animal.CanBeInWagonWith(_animal);
                if (err != Error.None)
                    return err;
            }

            Animals.Add(animal);
            
            return Error.None;
        }
    }
}