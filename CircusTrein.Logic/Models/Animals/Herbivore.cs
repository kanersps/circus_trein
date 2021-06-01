using CircusTrein.Logic.Enums;

namespace CircusTrein.Logic.Models.Animals
{
    public class Herbivore : Animal
    {
        public Herbivore(Size size)
        {
            Size = size;
            Carnivore = false;
        }

        public override Error CanBeInWagonWith(Animal animal)
        {
            if (animal.Carnivore)
                if ((int) Size <= (int) animal.Size)
                    return Error.CarnivoreSizeTooLarge;
            
            return Error.None;
        }
        
    }
}