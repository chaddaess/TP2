using System.Drawing;
using Microsoft.AspNetCore.Mvc;
using TP2_Entity.Models;

namespace TP2_Entity.Controllers
{
	public class MovieController : Controller
	{
		private ApplicationDbContext? _context;
		public MovieController(ApplicationDbContext? context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			var movies=_context.Movies
						.ToList();
			return View(movies);
		}

		public IActionResult Add()
		{
			List<Guid> GenreNames=new List<Guid>();
			var Genres=_context.Genres
						.ToList();
			foreach (var item in Genres)
			{
				GenreNames.Add(item.Id);

			}
			ViewBag.GenreNames=GenreNames;
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Add(string Name, Guid GenreId)
		{
	

			if (ModelState.IsValid)
			{
				Movie m = new Movie()
				{
					Name = Name,
					GenreId1 = GenreId,

				};
				_context.Movies.Add(m);
				await _context.SaveChangesAsync();
				return (RedirectToAction(nameof(Index)));

			}
			return RedirectToAction(nameof(Add));


		}
	}
}
