﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteca.UserInterface.Models
{
    public class Genre
    {
        public int id_genre { get; set; }
        public string description { get; set; }

        public Genre() {
            this.id_genre = 0;
            this.description = string.Empty;
        }
        public Genre(int id, string desc) {
            this.id_genre = id;
            this.description = desc;
        }
    }
}