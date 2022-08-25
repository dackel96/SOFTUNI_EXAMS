using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Trucks.Data.Models.Enums;

namespace Trucks.Data.Models
{
    public class Truck
    {
        public Truck()
        {
            this.ClientsTrucks = new HashSet<ClientTruck>();
        }
        public int Id { get; set; }
        [Required]
        public string RegistrationNumber { get; set; } //text with length 8. First two characters are upper letters [A-Z], followed by four digits and the last two characters are upper letters [A-Z] again.
        [Required]
        public string VinNumber { get; set; } //text with length 17 (required)

        public int? TankCapacity { get; set; } //integer in range [950…1420]

        public int? CargoCapacity { get; set; } //integer in range [5000…29000]

        public CategoryType CategoryType { get; set; }

        public MakeType MakeType { get; set; }

        public int DespatcherId { get; set; }

        public Despatcher Despatcher { get; set; }

        public ICollection<ClientTruck> ClientsTrucks { get; set; }
    }
}


/*⦁	Id – integer, Primary Key
⦁	RegistrationNumber – text with length 8. First two characters are upper letters [A-Z], followed by four digits and the last two characters are upper letters [A-Z] again.
⦁	VinNumber – text with length 17 (required)
⦁	TankCapacity – integer in range [950…1420]
⦁	CargoCapacity – integer in range [5000…29000]
⦁	CategoryType – enumeration of type CategoryType, with possible values (Flatbed, Jumbo, Refrigerated, Semi) (required)
⦁	MakeType – enumeration of type MakeType, with possible values (Daf, Man, Mercedes, Scania, Volvo) (required)
⦁	DespatcherId – integer, foreign key (required)
⦁	Despatcher – Despatcher 
⦁	ClientsTrucks – collection of type ClientTruck
*/