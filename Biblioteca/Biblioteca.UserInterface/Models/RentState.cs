﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biblioteca.UserInterface.Models
{
    public class RentState
    {
        public int id_state { get; set; }
        public string description { get; set; }

        public RentState() {
            this.id_state = 0;
            this.description = string.Empty;
        }
        public RentState(int id, string description) {
            this.id_state = id;
            this.description = description;
        }
    }
}