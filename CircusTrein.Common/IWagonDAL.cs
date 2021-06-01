using System.Collections.Generic;

namespace CircusTrein.Common
{
    public interface IWagonDAL
    {
        void Save(WagonDTO dto);
        List<WagonDTO> GetAll();
        WagonDTO FindById(string guid);
    }
}