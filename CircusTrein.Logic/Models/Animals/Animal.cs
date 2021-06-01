using System;
using CircusTrein.Common;
using CircusTrein.Logic.Enums;

namespace CircusTrein.Logic.Models.Animals
{
    public abstract class Animal
    {
        public Guid Id { get; set; }
        public Size Size { get; set; }
        public bool Carnivore { get; set; }
        public abstract Error CanBeInWagonWith(Animal animal);
    }
}