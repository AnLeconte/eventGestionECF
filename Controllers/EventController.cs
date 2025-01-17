using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventManagement.Data;
using eventGestion.Models.EventItems;
using System.Threading.Tasks;
using EventManagement.Models;

namespace EventGestion.Controllers
{
    public class EventController : Controller
    {
        private readonly EventContext _context;

        public EventController(EventContext context)
        {
            _context = context;
        }

        // GET: Event
        public async Task<IActionResult> Index()
        {
            var events = await _context.Events.ToListAsync();
            return View(events);
        }

        // GET: Event/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Event/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Location,Date")] Event newEvent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newEvent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(newEvent);
        }

        // GET: Event/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventItem = await _context.Events
                .Include(e => e.Participants)  
                .FirstOrDefaultAsync(e => e.Id == id);

            if (eventItem == null)
            {
                return NotFound();
            }

            return View(eventItem);
        }


        // GET: Event/Register/5
        public async Task<IActionResult> Register(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            
            var eventItem = await _context.Events
                .Include(e => e.Participants)  
                .FirstOrDefaultAsync(e => e.Id == id);

            if (eventItem == null)
            {
                return NotFound();
            }

            var participant = new Participant
            {
                Name = "Participant_" + Guid.NewGuid(), 
                RegistrationDate = DateTime.Now,
                EventId = id.Value,
                Event = eventItem
            };

            _context.Participants.Add(participant);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Details), new { id = id });
        }
    }
}
