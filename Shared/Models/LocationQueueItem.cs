using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models
{
    public class LocationQueueItem
    {
        public Guid id { get; set; }
        public string city { get; set; }
        public string country { get; set; }
    }
}
