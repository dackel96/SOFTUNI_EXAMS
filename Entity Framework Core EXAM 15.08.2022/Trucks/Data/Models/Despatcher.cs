﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Trucks.Data.Models
{
    public class Despatcher
    {
        public Despatcher()
        {
            this.Trucks = new HashSet<Truck>();
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Position { get; set; }

        public ICollection<Truck> Trucks { get; set; }
    }
}

/*⦁	Id – integer, Primary Key
⦁	Name – text with length [2, 40] (required)
⦁	Position – text
⦁	Trucks – collection of type Truck
*/
