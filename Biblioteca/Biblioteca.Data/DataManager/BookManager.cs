using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Data
{
    public class BookManager : BiblioDbManager
    {
        public BookManager() : base() { }

        public bool setNewBook(Entities.Book entBook)
        {
            try
            {
                var author = this.db.Set<Authors>().Where(x => x.first_name == entBook.authorName.ToLower() && x.last_name == entBook.authorLastName.ToLower()).FirstOrDefault();
                    if (author == null)
                    {
                        Authors dbAuthor = new Authors();
                        dbAuthor.first_name = entBook.authorName.ToLower();
                        dbAuthor.last_name = entBook.authorLastName.ToLower();
                        this.db.Authors.Add(dbAuthor);
                        this.db.SaveChanges();
                        author = this.db.Set<Authors>().Where(x => x.first_name == entBook.authorName && x.last_name == entBook.authorLastName.ToLower()).FirstOrDefault();
                    }

                    var publisher = this.db.Set<Publishers>().Where(x => x.full_name == entBook.publisher.ToLower()).FirstOrDefault();
                    if (publisher == null)
                    {
                        Publishers dbPublisher = new Publishers();
                        dbPublisher.full_name = entBook.publisher.ToLower();
                        this.db.Publishers.Add(dbPublisher);
                        this.db.SaveChanges();
                        publisher = this.db.Set<Publishers>().Where(x => x.full_name == entBook.publisher.ToLower()).FirstOrDefault();
                    }

                    var genre = this.db.Set<Genres>().Where(x => x.description == entBook.genre.ToLower()).FirstOrDefault();
                    if (genre == null)
                    {
                        Genres dbGenre = new Genres();
                        dbGenre.description = entBook.genre.ToLower();
                        this.db.Genres.Add(dbGenre);
                        this.db.SaveChanges();
                        genre = this.db.Set<Genres>().Where(x => x.description == entBook.genre.ToLower()).FirstOrDefault();
                    }

                    var canSave = this.db.Set<Books>().Where(x => x.id_publisher == publisher.id_publisher && x.id_author == author.id_author && x.id_genre == genre.id_genre && x.titulo == entBook.title).FirstOrDefault();

                    if (canSave == null)
                    {
                        Books dbBook = new Books();
                        dbBook.titulo = entBook.title.ToLower();
                        dbBook.id_publisher = publisher.id_publisher;
                        dbBook.id_author = author.id_author;
                        dbBook.id_genre = genre.id_genre;
                        dbBook.stock = entBook.stock;
                        this.db.Books.Add(dbBook);
                        this.db.SaveChanges();

                       
                        return true;
                    }
                    else {
                        return false;
                    }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Entities.Book> getBookList() {
            try 
            {
                List<Entities.Book> entBookList = new List<Entities.Book>();
                var bookList = this.db.Set<Books>().Where(x => x.stock > 0).ToList();
                foreach(var curBook in bookList){
                    entBookList.Add(this.DBToEntities(curBook));
                }
                return entBookList;    
            }
            catch(Exception ex){
                throw new Exception(ex.Message);
            }
            
        }


        public Entities.Book DBToEntities(Books dbBook)
        {
            
            Entities.Book entBook = new Entities.Book();
            entBook.id_book = dbBook.id_book;
            entBook.title = UppercaseFirst(dbBook.titulo);
            entBook.publisher = UppercaseFirst(dbBook.Publishers.full_name);
            entBook.authorName = UppercaseFirst(dbBook.Authors.first_name);
            entBook.authorLastName = UppercaseFirst(dbBook.Authors.last_name);
            entBook.stock = dbBook.stock;

            return entBook;
        }
    }
}
