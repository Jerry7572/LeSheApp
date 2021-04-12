using System;
using System.Collections.Generic;
using System.Text;

namespace LeSheApp.Models
{
    public class cSpot
    {
        public int GarbageTruckSpotId { get; set; }
        public short DistrictId { get; set; }
        public string Address { get; set; }
        public short RouteId { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public TimeSpan LeaveTime { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
