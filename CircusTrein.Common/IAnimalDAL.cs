using System.Collections.Generic;

namespace CircusTrein.Common
{
    public interface IAnimalDAL
    {
        void Save(AnimalDTO dto);
        List<AnimalDTO> GetAll();
        AnimalDTO FindById(string guid);
    }
}