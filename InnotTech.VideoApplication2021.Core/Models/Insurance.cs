using System.Collections.Generic;

namespace InnotTech.VideoApplication2021.Core.Models
{
    public class Insurance
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public  List<Video> Videos { get; set; }
    }
}