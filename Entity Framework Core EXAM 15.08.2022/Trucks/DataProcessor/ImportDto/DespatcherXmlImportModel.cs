using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;
using Trucks.Data.Models.Enums;

namespace Trucks.DataProcessor.ImportDto
{
    [XmlType("Despatcher")]
    public class DespatcherXmlImportModel
    {
        [XmlElement("Name")]
        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string Name { get; set; }
        [XmlElement("Position")]
        [Required]
        public string Position { get; set; }
        [XmlArray("Trucks")]
        public TruckXmlImportModel[] Trucks { get; set; }
    }
    [XmlType("Truck")]
    public class TruckXmlImportModel
    {
        [XmlElement("RegistrationNumber")]
        [Required]
        [StringLength(8)]
        [RegularExpression(@"^[A-Z]{2}[0-9]{4}[A-Z]{2}$")]
        public string RegistrationNumber { get; set; } //text with length 8. First two characters are upper letters [A-Z], followed by four digits and the last two characters are upper letters [A-Z] again.
        
        [XmlElement("VinNumber")]
        [Required]
        [StringLength(17)]
        public string VinNumber { get; set; }

        [XmlElement("TankCapacity")]
        [Range(950,1420)]
        public int? TankCapacity { get; set; }

        [XmlElement("CargoCapacity")]
        [Range(5000,29000)]
        public int? CargoCapacity { get; set; }

        [XmlElement("CategoryType")]
        [Required]
        [EnumDataType(typeof(CategoryType))]
        public string CategoryType { get; set; }

        [XmlElement("MakeType")]
        [Required]
        [EnumDataType(typeof(MakeType))]
        public string MakeType { get; set; }
    }
}


/*<Despatchers>
	<Despatcher>
		<Name>Genadi Petrov</Name>
		<Position>Specialist</Position>
		<Trucks>
			<Truck>
				<RegistrationNumber>CB0796TP</RegistrationNumber>
				<VinNumber>YS2R4X211D5318181</VinNumber>
				<TankCapacity>1000</TankCapacity>
				<CargoCapacity>23999</CargoCapacity>
				<CategoryType>0</CategoryType>
				<MakeType>3</MakeType>
			</Truck>
*/
/*⦁	Id – integer, Primary Key
⦁	Name – text with length [2, 40] (required)
⦁	Position – text
⦁	Trucks – collection of type Truck
*/
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