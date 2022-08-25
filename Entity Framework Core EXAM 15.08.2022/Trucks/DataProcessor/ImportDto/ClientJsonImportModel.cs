using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Trucks.DataProcessor.ImportDto
{
    public class ClientJsonImportModel
    {
        [Required]
        [StringLength(40, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string Nationality { get; set; }
        [Required]
        public string Type { get; set; }

        public int[] Trucks { get; set; }
    }
}

/* {
    "Name": "Kuenehne + Nagel (AG & Co.) KGKuenehne + Nagel (AG & Co.) KGKuenehne + Nagel (AG & Co.) KG",
    "Nationality": "The Netherlands",
    "Type": "golden",
    "Trucks": [
      1,
      68,
      73,
      17,
      98,
      98
    ]
  },*/

/*Id – integer, Primary Key
⦁	Name – text with length [3, 40] (required)
⦁	Nationality – text with length [2, 40] (required)
⦁	Type – text (required)*/