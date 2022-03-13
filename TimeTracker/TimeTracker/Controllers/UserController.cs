using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TimeTracker.Data;
using TimeTracker.Models;


namespace TimeTracker.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext db;

        public UserController(ApplicationDbContext db)

        {
            this.db = db;
        }

        public IActionResult Index()
        {

            //using (db)
            //{
                var data = db.User.Select(x => x).ToList();

                ViewBag.Message = "This is Sudent Details using ViewBag";

                return View(data);
            //}


        }

        [HttpGet]
        public IActionResult Index(string search)
        {
            ViewData["GetUserDetails"] = search;

           
                var data = db.User.Select(x => x);
                  
            if (!string.IsNullOrEmpty(search))
                {
                    //data = data.Where(a => a.Name==search);
                    data = data.Where(a => a.Name.Contains(search) || a.Surname.Contains(search));
                }
                return View(data);

        }

        //get
        public IActionResult Create()
        {
            return View();
        }

        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User user)
        {
              if (ModelState.IsValid)
                {

                    db.User.Add(user);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }

                return View(user);

           
        }
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return RedirectToAction("Index");
            }
           
                var user = await db.User.FindAsync(id);

                return View(user);
           

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(User user)
        {
           
                if (ModelState.IsValid)
                {
                    db.User.Update(user);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                return View(user);
          
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {

                return RedirectToAction("Index");
            }

           
                var user = await db.User.FindAsync(id);

                return View(user);
          
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
           
                var user = await db.User.FindAsync(id);
                return View(user);
          
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            
                var user = await db.User.FindAsync(id);
                db.User.Remove(user);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
          
        }



        public IActionResult ViewUsers()
        {
            var data = db.User.Select(x => x);

            //ViewBag.Message = "This is Sudent Details using ViewBag";

            string temp = data.Select(x => x.Name).ToString();

            var list = new List<string>();

            foreach (var item in data)
            {
                list.Add(item.Name);
            }

            list.Add(temp);

            ViewBag.Message = list;

            return View(data);
            
        }

    }
}
