using System;
using System.Collections.Generic;

namespace CircusTrein.Common
{
    public class WagonDTO
    {
        public Guid Id { get; set; }
        public List<AnimalDTO> Animals { get; set; } = new List<AnimalDTO>();
    }
}