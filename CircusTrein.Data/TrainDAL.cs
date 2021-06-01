using System.Collections.Generic;
using CircusTrein.Common;

namespace CircusTrein.Data
{
    public class TrainDAL : ITrainDAL
    {
        // Fake database
        private List<TrainDTO> _database = new (); 
        
        public void Save(TrainDTO dto)
        {
            TrainDTO _dto = _database.Find(train => train.Id == dto.Id);

            if (_dto != null)
            {
                _dto = dto;
            }
            else
            {
                _database.Add(dto);
            }
        }

        public List<TrainDTO> GetAll()
        {
            return _database;
        }

        public TrainDTO FindById(string guid)
        {
            return _database.Find(train => train.Id.ToString() == guid);
        }
    }
}