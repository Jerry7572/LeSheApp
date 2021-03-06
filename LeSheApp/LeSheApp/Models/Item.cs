using System;

namespace LeSheApp.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        //
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