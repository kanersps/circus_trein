using System.Collections.Generic;
using CircusTrein.Common;

namespace CircusTrein.Data
{
    public class AnimalDAL : IAnimalDAL
    {
        // Fake database
        private List<AnimalDTO> _database = new ();

        public void Save(AnimalDTO dto)
        {
            AnimalDTO _dto = _database.Find(animal => animal.Id == dto.Id);

            if (_dto != null)
            {
                _dto = dto;
            }
            else
            {
                _database.Add(dto);
            }
        }

        public List<AnimalDTO> GetAll()
        {
            return _database;
        }

        public AnimalDTO FindById(string guid)
        {
            return _database.Find(animal => animal.Id.ToString() == guid);
        }
    }
}