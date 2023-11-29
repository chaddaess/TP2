namespace TP2_Entity.Models
{
	public class Genre
	{
		public Guid Id { get; set; }
		public string? GenreName{ get; set; }
		public List<Movie>? Movies { get; set; }
		public Genre() { }
		public Genre(string name) {
			GenreName = name;
			Id= Guid.NewGuid();
		}
	}
}
