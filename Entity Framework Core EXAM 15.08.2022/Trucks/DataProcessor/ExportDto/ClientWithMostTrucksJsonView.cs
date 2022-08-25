using System;
using System.Collections.Generic;
using System.Text;

namespace Trucks.DataProcessor.ExportDto
{
    public class ClientWithMostTrucksJsonView
    {
        public string Name { get; set; }

        public IEnumerable<TruckJsonViewModel> Trucks { get; set; }
    }

    public class TruckJsonViewModel
    {
        public string TruckRegistrationNumber { get; set; }

        public string VinNumber { get; set; }

        public int? TankCapacity { get; set; }

        public int? CargoCapacity { get; set; }

        public string CategoryType { get; set; }

        public string MakeType { get; set; }
    }
}

/*
    {
    "Name": "Gebr. Mayer GmbH & Co. KG",
    "Trucks": [
      {
        "TruckRegistrationNumber": "CT5206MM",
        "VinNumber": "WDB96341311261287",
        "TankCapacity": 1420,
        "CargoCapacity": 28058,
        "CategoryType": "Flatbed",
        "MakeType": "Daf"
      },
*/