using Library.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class BookController : Controller
    {
        private IDal dal;

        public BookController() : this(new Dal())
        {

        }

        public BookController(IDal dalIoc)
        {
            dal = dalIoc;
        }

        public ActionResult Index()
        {
            using (IDal dal = new Dal())
            {
                List<Book> bookList = dal.GetAllBooks();
                return View(bookList);
            }
        }

        public ActionResult AddBook()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBook(Book book)
        {
            if (dal.IsBook(book.Name))
            {
                ModelState.AddModelError("Name", "This book is already registered");
                return View(book);
            }

            if (!ModelState.IsValid)
                return View(book);

            dal.AddBook(book.Name, book.Author, book.Category);
            return RedirectToAction("Index");
        }

        public ActionResult ModifyBook(int? id)
        {
            if (id.HasValue)
            {
                using (IDal dal = new Dal())
                {
                    Book book = dal.GetAllBooks().FirstOrDefault(b => b.Id == id.Value);
                    if (book == null)
                        return View("Error");
                    return View(book);
                }
            }
            else
                return View("Error");
        }

        [HttpPost]
        public ActionResult ModifyBook(Book book)
        {
            if (!ModelState.IsValid)
                return View(book);

            dal.ModifyBook(book.Id, book.Name, book.Author, book.Category);
            return RedirectToAction("Index");
        }

        public ActionResult ShowOne()
        {
            return View(new Book());
        }

        [HttpPost]
        public ActionResult ShowOne(Book book)
        {
            if (book == null)
                return View("Index");

            if (dal.GetByName(book.Name) != null)
            {
                book = dal.GetByName(book.Name);
                return View(book);
            }
            else
                return View("Error");

        }

        public ActionResult DeletBook(int id)
        {
            dal.DeletBook(id);
            return RedirectToAction("Index");
        }

    }
}