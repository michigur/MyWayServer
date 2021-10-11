using System;
using System.Collections.Generic;

#nullable disable

namespace MyWayServerBL.Models
{
    public partial class CarRoutteType
    {
        public CarRoutteType()
        {
            RoutteCars = new HashSet<RoutteCar>();
        }

        public int CarRoutteTypeId { get; set; }
        public string CarRoutteName { get; set; }

        public virtual ICollection<RoutteCar> RoutteCars { get; set; }
    }
}
