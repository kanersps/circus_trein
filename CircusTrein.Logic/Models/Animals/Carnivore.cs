using CircusTrein.Logic.Enums;

namespace CircusTrein.Logic.Models.Animals
{
    public class Carnivore : Animal
    {
        public Carnivore(Size size)
        {
            Size = size;
            Carnivore = true;
        }

        public override Error CanBeInWagonWith(Animal animal)
        {                
            if (animal.Carnivore)
                return Error.TwoCarnivores;
                
            if((int) Size >= (int) animal.Size)
                return Error.CarnivoreSizeTooLarge;

            return Error.None;
        }
    }
}