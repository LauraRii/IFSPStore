using IFSPStore.Domain.Base;

namespace IFSPStore.Domain.Entities
{
    internal class Customer : BaseEntity<int>
    {

        public Customer(int id, string name, string adress, string ssnumber, string neighborhood, string city) : base(id) {
            Name = name;
            Adress = adress;
            SSNumber = ssnumber;
            Neighborhood = neighborhood;
            City = city;
            cityId = costumerCity.Id;

        }

        public string Name { get; set; }
        public string Adress { get; set; }
        public string SSNumber { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public City costumerCity { get; set; }
        public int cityId { get; set; }

    }
}
