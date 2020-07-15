using System.Collections.Generic;

namespace ParkingControll.App
{
    public class PageResult<T>
    {
        public List<T> Items { get; set; }
        public string NextPageLink { get; set; }
        public string Count { get; set; }
    }
}
