namespace Catalog.Models
{
    public class HeadphonesPrice
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public int SpecId { get; set; }
        public decimal Cost { get; set; }

        public HeadphonesModel Model { get; set; }
        public HeadphonesSpec Spec { get; set; }
    }
}
