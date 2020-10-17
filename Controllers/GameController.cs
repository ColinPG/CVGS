using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CVGS.Models;

namespace CVGS.Controllers
{
    public class GameController : Controller
    {
        private readonly CVGSContext _context;

        public GameController(CVGSContext context)
        {
            _context = context;
        }

        // GET: Game
        public async Task<IActionResult> Index()
        {
            var cVGSContext = _context.Game.Include(g => g.EsrbRatingCodeNavigation).Include(g => g.GameCategory).Include(g => g.GamePerspectiveCodeNavigation).Include(g => g.GameStatusCodeNavigation).Include(g => g.GameSubCategory);
            return View(await cVGSContext.ToListAsync());
        }

        // GET: Game/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Game
                .Include(g => g.EsrbRatingCodeNavigation)
                .Include(g => g.GameCategory)
                .Include(g => g.GamePerspectiveCodeNavigation)
                .Include(g => g.GameStatusCodeNavigation)
                .Include(g => g.GameSubCategory)
                .FirstOrDefaultAsync(m => m.Guid == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // GET: Game/Create
        public IActionResult Create()
        {
            ViewData["EsrbRatingCode"] = new SelectList(_context.EsrbRating, "Code", "Code");
            ViewData["GameCategoryId"] = new SelectList(_context.GameCategory, "Id", "EnglishCategory");
            ViewData["GamePerspectiveCode"] = new SelectList(_context.GamePerspective, "Code", "Code");
            ViewData["GameStatusCode"] = new SelectList(_context.GameStatus, "Code", "Code");
            ViewData["GameSubCategoryId"] = new SelectList(_context.GameSubCategory, "Id", "EnglishCategory");
            return View();
        }

        // POST: Game/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Guid,GameStatusCode,GameCategoryId,GameSubCategoryId,EsrbRatingCode,EnglishName,FrenchName,FrenchVersion,EnglishPlayerCount,FrenchPlayerCount,GamePerspectiveCode,EnglishTrailer,FrenchTrailer,EnglishDescription,FrenchDescription,EnglishDetail,FrenchDetail,UserName")] Game game)
        {
            if (ModelState.IsValid)
            {
                game.Guid = Guid.NewGuid();
                _context.Add(game);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EsrbRatingCode"] = new SelectList(_context.EsrbRating, "Code", "Code", game.EsrbRatingCode);
            ViewData["GameCategoryId"] = new SelectList(_context.GameCategory, "Id", "EnglishCategory", game.GameCategoryId);
            ViewData["GamePerspectiveCode"] = new SelectList(_context.GamePerspective, "Code", "Code", game.GamePerspectiveCode);
            ViewData["GameStatusCode"] = new SelectList(_context.GameStatus, "Code", "Code", game.GameStatusCode);
            ViewData["GameSubCategoryId"] = new SelectList(_context.GameSubCategory, "Id", "EnglishCategory", game.GameSubCategoryId);
            return View(game);
        }

        // GET: Game/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Game.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            ViewData["EsrbRatingCode"] = new SelectList(_context.EsrbRating, "Code", "Code", game.EsrbRatingCode);
            ViewData["GameCategoryId"] = new SelectList(_context.GameCategory, "Id", "EnglishCategory", game.GameCategoryId);
            ViewData["GamePerspectiveCode"] = new SelectList(_context.GamePerspective, "Code", "Code", game.GamePerspectiveCode);
            ViewData["GameStatusCode"] = new SelectList(_context.GameStatus, "Code", "Code", game.GameStatusCode);
            ViewData["GameSubCategoryId"] = new SelectList(_context.GameSubCategory, "Id", "EnglishCategory", game.GameSubCategoryId);
            return View(game);
        }

        // POST: Game/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Guid,GameStatusCode,GameCategoryId,GameSubCategoryId,EsrbRatingCode,EnglishName,FrenchName,FrenchVersion,EnglishPlayerCount,FrenchPlayerCount,GamePerspectiveCode,EnglishTrailer,FrenchTrailer,EnglishDescription,FrenchDescription,EnglishDetail,FrenchDetail,UserName")] Game game)
        {
            if (id != game.Guid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(game);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameExists(game.Guid))
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
            ViewData["EsrbRatingCode"] = new SelectList(_context.EsrbRating, "Code", "Code", game.EsrbRatingCode);
            ViewData["GameCategoryId"] = new SelectList(_context.GameCategory, "Id", "EnglishCategory", game.GameCategoryId);
            ViewData["GamePerspectiveCode"] = new SelectList(_context.GamePerspective, "Code", "Code", game.GamePerspectiveCode);
            ViewData["GameStatusCode"] = new SelectList(_context.GameStatus, "Code", "Code", game.GameStatusCode);
            ViewData["GameSubCategoryId"] = new SelectList(_context.GameSubCategory, "Id", "EnglishCategory", game.GameSubCategoryId);
            return View(game);
        }

        // GET: Game/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Game
                .Include(g => g.EsrbRatingCodeNavigation)
                .Include(g => g.GameCategory)
                .Include(g => g.GamePerspectiveCodeNavigation)
                .Include(g => g.GameStatusCodeNavigation)
                .Include(g => g.GameSubCategory)
                .FirstOrDefaultAsync(m => m.Guid == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        // POST: Game/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var game = await _context.Game.FindAsync(id);
            _context.Game.Remove(game);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GameExists(Guid id)
        {
            return _context.Game.Any(e => e.Guid == id);
        }
    }
}
