using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP2_Entity.Models;

namespace TP2_Entity.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext? _context;
        public CustomerController(ApplicationDbContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            var customers = _context.Customers
                            .Include(c=>c.MembershipType)
                            .ToList();
            return View(customers);
        }

        public IActionResult Edit(int?id)
        {
            var customer=_context.Customers
                         .Where(c=>c.Id ==id)
						 .Include(c => c.MembershipType)
						 .FirstOrDefault();
            return View(customer);
        }

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,Name,MembershipTypeId")] Customer customer)
		{
			if (id != customer.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				//form is submitted and valid 
				try
				{
					_context.Update(customer);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!CustomerExists(customer.Id))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			//display the form 
			return View(customer);
		}

		public IActionResult Delete(int? id)
		{
			var cust = _context.Customers
					 .Where(c => c.Id == id)
					 .FirstOrDefault();
			if (cust==null)
			{
				return NotFound();
			}
			_context.Remove(cust);
			_context.SaveChanges();
			return RedirectToAction(nameof(Index));

		}

		public IActionResult Add()
		{
			var MembershipTypes=_context.MembershipTypes
								.ToList();
			List<int> MembershipTypeIds=new List<int>();
			foreach(MembershipType mt in MembershipTypes)
			{
				MembershipTypeIds.Add(mt.Id);
			}
			ViewBag.MembershipTypeIds = MembershipTypeIds;

			return View();
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Add(string Name, int MembershipTypeId)
		{
			if(ModelState.IsValid) {
				Customer c = new Customer()
				{

					MembershipTypeId = MembershipTypeId,
					Name = Name,


				};
				_context.Customers.Add(c);
				await _context.SaveChangesAsync();
				return (RedirectToAction(nameof(Index)));
			}
			return RedirectToAction(nameof(Add));
		}



		private bool CustomerExists(int id)
		{
			return _context.Customers.Any(e => e.Id == id);
		}

	}
}
