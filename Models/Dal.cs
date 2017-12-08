using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Models
{
    public class Dal : IDal
    {
        private BddContext bdd;

        public Dal()
        {
            bdd = new BddContext();
        }

        public List<Book> GetAllBooks()
        {
            return bdd.Books.OrderBy(x => x.Name).ToList();
                
        }

        public void AddBook(string name, string author, string category)
        {
            bdd.Books.Add(new Book { Name = name, Author = author, Category = category });
            bdd.SaveChanges();
        }

        public Book GetByName(string name)
        {
           return bdd.Books.FirstOrDefault(book => book.Name == name);
        }

        public void DeletBook(int id)
        {
            Book findBook = bdd.Books.FirstOrDefault(book => book.Id == id);
            if(findBook != null)
                bdd.Books.Remove(findBook);
                bdd.SaveChanges();
        }

        public bool IsBook(string name)
        {
            return bdd.Books.Any(book => string.Compare(book.Name, name, StringComparison.CurrentCultureIgnoreCase) == 0);
        }

        public void ModifyBook(int id, string name, string author, string category)
        {
            Book findBook = bdd.Books.FirstOrDefault(book => book.Id == id);
            if (findBook != null)
            {
                findBook.Name = name;
                findBook.Author = author;
                findBook.Category = category;
                bdd.SaveChanges();
            }
        }

        public void Dispose()
        {
            bdd.Dispose();
        }
    }
}