using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReelHub.Website.Data;
using ReelHub.Website.Models.Database;

namespace ReelHub.Website.Controllers
{
    public class MovieDirectorsController : Controller
    {
        private readonly DatabaseContext _context;

        public MovieDirectorsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: MovieDirectors
        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.MovieDirectors.Include(m => m.Director).Include(m => m.Movie);
            return View(await databaseContext.ToListAsync());
        }

        // GET: MovieDirectors/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieDirector = await _context.MovieDirectors
                .Include(m => m.Director)
                .Include(m => m.Movie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movieDirector == null)
            {
                return NotFound();
            }

            return View(movieDirector);
        }

        // GET: MovieDirectors/Create
        public IActionResult Create()
        {
            ViewData["DirectorId"] = new SelectList(_context.Directors, "Id", "FirstName");
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "ImageUrl");
            return View();
        }

        // POST: MovieDirectors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MovieId,DirectorId")] MovieDirector movieDirector)
        {
            if (ModelState.IsValid)
            {
                movieDirector.Id = Guid.NewGuid();
                _context.Add(movieDirector);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DirectorId"] = new SelectList(_context.Directors, "Id", "FirstName", movieDirector.DirectorId);
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "ImageUrl", movieDirector.MovieId);
            return View(movieDirector);
        }

        // GET: MovieDirectors/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieDirector = await _context.MovieDirectors.FindAsync(id);
            if (movieDirector == null)
            {
                return NotFound();
            }
            ViewData["DirectorId"] = new SelectList(_context.Directors, "Id", "FirstName", movieDirector.DirectorId);
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "ImageUrl", movieDirector.MovieId);
            return View(movieDirector);
        }

        // POST: MovieDirectors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,MovieId,DirectorId")] MovieDirector movieDirector)
        {
            if (id != movieDirector.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieDirector);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieDirectorExists(movieDirector.Id))
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
            ViewData["DirectorId"] = new SelectList(_context.Directors, "Id", "FirstName", movieDirector.DirectorId);
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "ImageUrl", movieDirector.MovieId);
            return View(movieDirector);
        }

        // GET: MovieDirectors/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieDirector = await _context.MovieDirectors
                .Include(m => m.Director)
                .Include(m => m.Movie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movieDirector == null)
            {
                return NotFound();
            }

            return View(movieDirector);
        }

        // POST: MovieDirectors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var movieDirector = await _context.MovieDirectors.FindAsync(id);
            if (movieDirector != null)
            {
                _context.MovieDirectors.Remove(movieDirector);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieDirectorExists(Guid id)
        {
            return _context.MovieDirectors.Any(e => e.Id == id);
        }
    }
}
