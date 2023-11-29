namespace TP2_Entity.Models
{
	public class Movie
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public Genre? Genre { get; set; }
		public Guid? GenreId1 { get; set; }
		public List<Customer>? Customers { get; set; }
		public Movie()
		{
		}
		public Movie(int id, string? name)
		{
			Id = id;
			Name = name;
		}
	}
}
