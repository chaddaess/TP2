namespace TP2_Entity.Models
{
	public class Customer
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public Customer() { }
		public MembershipType? MembershipType { get; set; } //navigation prop
		public int? MembershipTypeId { get; set; } //foreign key 
		public List <Movie> ?Movies { get; set; }
		public Customer(int id, string name)
		{
			Id = id;
			Name = name;
		}
	}
}
