using System;
using System.Collections.Generic;

namespace Library.Models
{
    public interface IDal : IDisposable
    {
        void AddBook(string name, string author, string category);
        Book GetByName(string name);
        void ModifyBook(int id, string name, string author, string category);
        void DeletBook(int id);
        List<Book> GetAllBooks();
        bool IsBook(string name);
    }
}
