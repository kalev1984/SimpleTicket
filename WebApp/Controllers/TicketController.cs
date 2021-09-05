using System.Collections.Generic;
using System.Linq;
using Domain.App;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class TicketController : Controller
    {
        private static readonly List<Ticket> Tickets = new();

        public IActionResult Index()
        {
            return View(Tickets.OrderBy(x => x.DueDate));
        }

        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(Ticket ticket)
        {
            if (!ModelState.IsValid || Tickets.Contains(ticket)) return View();
            ticket.Id = Tickets.Count;
            Tickets.Add(ticket);
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Remove(int id)
        {
            Tickets.RemoveAt(id);
            return RedirectToAction(nameof(Index));
        }
    }
}