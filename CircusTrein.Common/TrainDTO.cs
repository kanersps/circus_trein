using System;
using System.Collections.Generic;

namespace CircusTrein.Common
{
    public class TrainDTO
    {
        public Guid Id { get; set; } = Guid.Empty;
        public List<WagonDTO> Wagons { get; set; } = new();
    }
}