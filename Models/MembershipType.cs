namespace TP2_Entity.Models
{
	public class MembershipType
	{
		public int Id { get; set; }
		public bool SignUpFree { get; set; }
		public int DurationInMonth { get; set; }
		public double DiscountRate { get; set; }
		public Customer? Customers { get; set; }
	}
}
