using CircusTrein.Common;
using CircusTrein.Data;

namespace CircusTrein.Service
{
    public static class Factory
    {
        public static ITrainDAL CreateTrainDAL()
        {
            return new TrainDAL();
        }
    }
}