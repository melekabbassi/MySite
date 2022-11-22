using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using MySiteBL.Entities;
using MySiteDAL;

namespace MySiteWEB.Controllers
{
    public class PostsController : Controller
    {
		private readonly IFileProvider fileProvider;
		private readonly IWebHostEnvironment hostingEnvironment;
		private readonly MySiteContext _context;

		public PostsController(MySiteContext context, IFileProvider fileProvider, IWebHostEnvironment hostingEnvironment)
		{
			_context = context;
			this.fileProvider = fileProvider;
			this.hostingEnvironment = hostingEnvironment;
		}

        // GET: Posts
        public async Task<IActionResult> Index()
        {
            var mySiteContext = _context.Posts.Include(p => p.Blog);
            return View(await mySiteContext.ToListAsync());
        }

        // GET: Posts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Posts == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .Include(p => p.Blog)
                .FirstOrDefaultAsync(m => m.PostId == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: Posts/Create
        public IActionResult Create()
        {
            ViewData["BlogId"] = new SelectList(_context.Blogs, "BlogId", "BlogId");
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PostId,Title,Content,PublishedDateTime,BlogId,ImagePath")] Post post, IFormFile file)
        {
			if (ModelState.IsValid)
			{
				_context.Add(post);
				await _context.SaveChangesAsync();
				// Code to upload image if not null
				if (file != null || file.Length != 0)
				{
					// Create a File Info
					FileInfo fi = new FileInfo(file.FileName);
					// This code creates a unique file name to prevent duplications
					// stored at the file location
					var newFilename = post.PostId + "_" + String.Format("{0:d}",
					(DateTime.Now.Ticks / 10) % 100000000) + fi.Extension;
					var webPath = hostingEnvironment.WebRootPath;
					var path = Path.Combine("", webPath + @"\ImageFiles\" + newFilename);
					// IMPORTANT: The pathToSave variable will be save on the column in the database
					var pathToSave = @"/ImageFiles/" + newFilename;
					// This stream the physical file to the allocate wwwroot/ImageFiles folder
					using (var stream = new FileStream(path, FileMode.Create))
					{
						await file.CopyToAsync(stream);
					}
					// This save the path to the record
					post.ImagePath = pathToSave;
					_context.Update(post);
					await _context.SaveChangesAsync();
				}
				return RedirectToAction(nameof(Index));
			}
			return View(post);

		}


		// GET: Posts/Edit/5
		public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Posts == null)
            {
                return NotFound();
            }

            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            ViewData["BlogId"] = new SelectList(_context.Blogs, "BlogId", "BlogId", post.BlogId);
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PostId,Title,Content,PublishedDateTime,BlogId,ImagePath")] Post post)
        {
            if (id != post.PostId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(post);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.PostId))
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
            ViewData["BlogId"] = new SelectList(_context.Blogs, "BlogId", "BlogId", post.BlogId);
            return View(post);
        }

        // GET: Posts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Posts == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .Include(p => p.Blog)
                .FirstOrDefaultAsync(m => m.PostId == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Posts == null)
            {
                return Problem("Entity set 'MySiteContext.Posts'  is null.");
            }
            var post = await _context.Posts.FindAsync(id);
            if (post != null)
            {
                _context.Posts.Remove(post);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(int id)
        {
          return _context.Posts.Any(e => e.PostId == id);
        }
    }
}
