namespace Project_Case_Two
{
    public class DataModel
    {
        public string locale { get; set; }
        public string description { get; set; }
        public Bounding boundingPoly { get; set; }
    }

    public class Bounding
    {
        public List<CoordinateModel> vertices { get; set; }
    }

    public class CoordinateModel
    {
        public int x { get; set; }
        public int y { get; set; }
    }
}
