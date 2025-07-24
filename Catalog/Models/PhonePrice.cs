namespace Catalog.Models
{
    public class PhonePrice
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public int SpecId { get; set; }
        public decimal Cost { get; set; }

        public PhoneModel Model { get; set; }
        public PhoneSpec Spec { get; set; }
    }
}
