using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entities
{
    public class Book
    {
        public int id_book { get; set; }
        public string title { get; set; }
        public string publisher { get; set; }
        public string authorName { get; set; }
        public string authorLastName { get; set; }
        public string genre { get; set; }
        public int stock { get; set; }

        public Book() {
            this.id_book = 0;
            this.title = string.Empty;
            this.publisher = string.Empty;
            this.authorName = string.Empty;
            this.authorLastName = string.Empty;
            this.genre = string.Empty;
            this.stock = 0;
        }
        public Book(int id, string title, string publisher, string authorName, string authorLastName, string genre, int stock) {
            this.id_book = id;
            this.title = title;
            this.publisher = publisher;
            this.authorName = authorName;
            this.authorLastName = authorLastName;
            this.genre = genre;
            this.stock = stock;
        }
    }
}
    




       