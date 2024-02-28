using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HundeProjekt.Data;
using HundeProjekt.Models;

namespace HundeProjekt.Controllers
{
    public class ExercisesController : Controller
    {
        private readonly HundeProjektContext _context;

        public ExercisesController(HundeProjektContext context)
        {
            _context = context;
        }

        // GET: Exercises
        // GET: Exercises
        public async Task<IActionResult> Index()
        {
            var courseExerciseViewModel = new CourseExerciseViewModel
            {
                Exercises = await _context.Exercises.ToListAsync()
            };

            return View(courseExerciseViewModel);
        }


        // GET: Exercises/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercise = await _context.Exercises
                .FirstOrDefaultAsync(m => m.ExerciseID == id);
            if (exercise == null)
            {
                return NotFound();
            }

            return View(exercise);
        }

        // GET: Exercises/Create
        public IActionResult Create()
        {
            // Opret en liste af SelectListItem objekter baseret på MovementEnum værdier
            ViewBag.MovementSelectList = Enum.GetValues(typeof(MovementEnum))
                                             .Cast<MovementEnum>()
                                             .Select(e => new SelectListItem
                                             {
                                                 Value = ((int)e).ToString(),
                                                 Text = e.ToString()
                                             }).ToList();

            // Gør det samme for ClassEnum hvis det også skal være en dropdown
            ViewBag.ClassSelectList = Enum.GetValues(typeof(ClassEnum))
                                          .Cast<ClassEnum>()
                                          .Select(e => new SelectListItem
                                          {
                                              Value = ((int)e).ToString(),
                                              Text = e.ToString()
                                          }).ToList();

            return View();
        }





        // POST: Exercises/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExerciseID,Description,MovementEnumID,Sideshift,IllustrationPath,ClassEnumID,SignNumber,PositionX,PositionY")] Exercise exercise)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exercise);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exercise);
        }

        // GET: Exercises/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercise = await _context.Exercises.FindAsync(id);
            if (exercise == null)
            {
                return NotFound();
            }
            return View(exercise);
        }

        // POST: Exercises/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExerciseID,Description,MovementEnumID,Sideshift,IllustrationPath,ClassEnumID,SignNumber,PositionX,PositionY")] Exercise exercise)
        {
            if (id != exercise.ExerciseID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exercise);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExerciseExists(exercise.ExerciseID))
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
            return View(exercise);
        }

        // GET: Exercises/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercise = await _context.Exercises
                .FirstOrDefaultAsync(m => m.ExerciseID == id);
            if (exercise == null)
            {
                return NotFound();
            }

            return View(exercise);
        }

        // POST: Exercises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exercise = await _context.Exercises.FindAsync(id);
            if (exercise != null)
            {
                _context.Exercises.Remove(exercise);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExerciseExists(int id)
        {
            return _context.Exercises.Any(e => e.ExerciseID == id);
        }
    }
}
