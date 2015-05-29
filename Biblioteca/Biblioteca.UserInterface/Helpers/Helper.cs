using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Biblioteca.UserInterface.Models;

namespace Biblioteca.UserInterface.Helpers
{
    public class Helper
    {
        #region ModelToEntities
        public Entities.Book ModelToEntities(Book modBook){
            Helper helper = new Helper();
            return new Entities.Book(modBook.id_book, modBook.title, modBook.publisher, modBook.authorName, modBook.authorLastName, modBook.genre,modBook.stock);
            
        }

        public Entities.Gender ModelToEntities(Gender modGender) {
            return new Entities.Gender(modGender.id_gender, modGender.description);
        }

        public Entities.Publisher ModelToEntities(Publisher modPublisher)
        {
            return new Entities.Publisher(modPublisher.id_publisher, modPublisher.full_name);
        }

        public Entities.Author ModelToEntities(Author modAuthor) { 
            return new Entities.Author(modAuthor.id_author,modAuthor.first_name,modAuthor.last_name);
        }

        public Entities.Genre ModelToEntities(Genre modGenre) {
            return new Entities.Genre(modGenre.id_genre, modGenre.description);
        }

        public Entities.User ModelToEntities(User modUser){

            return new Entities.User(modUser.id_user, modUser.username, modUser.password, modUser.first_name, modUser.last_name, ModelToEntities(modUser.role), ModelToEntities(modUser.gender), modUser.birthDate, modUser.mail);
       }

        public Entities.UserRole ModelToEntities(UserRole modUserRole) {
            return new Entities.UserRole(modUserRole.id_role, modUserRole.description);
        }

        public Entities.Rent ModelToEntities(Rent modRent) {
            return new Entities.Rent(modRent.id_rent,
                                     new Entities.RentState(modRent.state.id_state,
                                                            modRent.state.description),
                                     ModelToEntities(modRent.user),
                                     ModelToEntities(modRent.book),
                                     modRent.ren_date,
                                     modRent.ret_date,
                                     modRent.res_date);
        }

        #endregion

        #region EntitiesToModel
        public Genre EntitiesToModel(Entities.Genre entGenre) {
            return new Genre(entGenre.id_genre,entGenre.description);
        }

        public Gender EntitiesToModel(Entities.Gender entGender) {
            return new Gender(entGender.id_gender, entGender.description);
        }

        public Author EntitiesToModel(Entities.Author entAuthor) {
            return new Author(entAuthor.id_author, entAuthor.first_name, entAuthor.last_name);
        }
        public Publisher EntitiesToModel(Entities.Publisher entPublisher) {
            return new Publisher(entPublisher.id_publisher,entPublisher.full_name);
        }


        public Book EntitiesToModel(Entities.Book entBook) {
            return new Book(entBook.id_book,entBook.title,entBook.publisher,entBook.authorName, entBook.authorLastName,entBook.genre,entBook.stock);
        }

        public User EntitiesToModel(Entities.User entUser) {
            return new User(entUser.id_user, entUser.username, entUser.password, entUser.first_name, entUser.last_name, EntitiesToModel(entUser.role), EntitiesToModel(entUser.gender), entUser.birthDate, entUser.mail);
        }

        public UserRole EntitiesToModel(Entities.UserRole entUserRole) {
            return new UserRole(entUserRole.Id_userRole, entUserRole.description);
        }

        public Rent EntitiesToModel(Entities.Rent entRent) {
            return new Rent(entRent.id_rent,
                            new RentState(entRent.state.id_state, entRent.state.description),
                            new User(entRent.user.id_user,
                                     entRent.user.username,
                                     "",
                                     entRent.user.first_name,
                                     entRent.user.last_name,
                                     new UserRole(entRent.user.role.Id_userRole,
                                                  entRent.user.role.description),
                           new Gender(entRent.user.gender.id_gender,
                                      entRent.user.gender.description),
                                     entRent.user.birthDate,
                                     entRent.user.mail),
                            new Book(entRent.book.id_book,
                                     entRent.book.title,
                                     entRent.book.publisher,
                                     entRent.book.authorName,
                                     entRent.book.authorLastName,
                                     entRent.book.genre,
                                     entRent.book.stock),
                            entRent.ren_date,
                            entRent.ret_date,
                            entRent.res_date);
        }
        #endregion
    }
}