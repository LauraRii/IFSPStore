using IFSPStore.Domain.Base;

namespace IFSPStore.Domain.Entities
{
    internal class Sale : BaseEntity<int>
    {

        public Sale(int id, DateTime date, float totalValue) : base(id) {
            Date = date;
            TotalValue = totalValue;
            UserId = User.Id;

        }

        public DateTime Date { get; set; }
        public float TotalValue { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }

    }
}
