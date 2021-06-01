using System.Collections.Generic;
using CircusTrein.Common;

namespace CircusTrein.Data
{
    public class WagonDAL : IWagonDAL
    {
        // Fake database
        private List<WagonDTO> _database = new ();

        public void Save(WagonDTO dto)
        {
            WagonDTO _dto = _database.Find(wagon => wagon.Id == dto.Id);

            if (_dto != null)
            {
                _dto = dto;
            }
            else
            {
                _database.Add(dto);
            }
        }

        public List<WagonDTO> GetAll()
        {
            return _database;
        }

        public WagonDTO FindById(string guid)
        {
            return _database.Find(wagon => wagon.Id.ToString() == guid);
        }
    }
}