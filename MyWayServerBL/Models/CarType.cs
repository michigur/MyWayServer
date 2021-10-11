using System;
using System.Collections.Generic;

#nullable disable

namespace MyWayServerBL.Models
{
    public partial class CarType
    {
        public CarType()
        {
            Cars = new HashSet<Car>();
        }

        public int CarTypeId { get; set; }
        public string CarTypeName { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
