using System;
using System.Collections.Generic;

namespace CircusTrein.Common
{
    public interface ITrainDAL
    {
        void Save(TrainDTO dto);
        List<TrainDTO> GetAll();
        TrainDTO FindById(string guid);
    }
}