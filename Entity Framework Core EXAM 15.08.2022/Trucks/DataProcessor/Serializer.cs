namespace Trucks.DataProcessor
{
    using System;
    using System.Linq;
    using Data;
    using Newtonsoft.Json;
    using Trucks.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportDespatchersWithTheirTrucks(TrucksContext context)
        {
            /*Export all despatchers that are managing at least one truck. For each despatcher, export their name and trucks count.
             * For each truck, export its registration number and make type. Order the trucks by registration number (ascending).
             * Order the despatchers by trucks count (descending), then by name (ascending).
            NOTE: You may need to call .ToArray() function before the selection, in order to detach entities from the database and avoid runtime errors (EF Core bug). */
            var xmlView = context.Despatchers
                .Where(x => x.Trucks.Any())
                .ToArray()
                .Select(x => new DespatcherWithTrucksXmlView
                {
                    TrucksCount = x.Trucks.Count,
                    DespatcherName = x.Name,
                    Trucks = x.Trucks.Select(t => new TruckXmlView
                    {
                        RegistrationNumber = t.RegistrationNumber,
                        Make = t.MakeType.ToString()
                    })
                    .OrderBy(o => o.RegistrationNumber)
                    .ToArray()
                })
                .OrderByDescending(o => o.Trucks.Count())
                .ThenBy(o => o.DespatcherName)
                .ToArray();
            var result = XmlConverter.Serialize<DespatcherWithTrucksXmlView>(xmlView, "Despatchers");
            return result;
        }

        public static string ExportClientsWithMostTrucks(TrucksContext context, int capacity)
        {
            /*Select the top 10 clients that have at least one truck that their tank capacity is bigger or equal to the given capacity.
            * Select them with their trucks which meet the same criteria (their tank capacity is bigger or equal to the given one).
            * For each client, export their name and their trucks. For each truck, export its registration number, VIN number,
            * tank capacity, cargo capacity, category and make type. Order the trucks by make type (ascending), then by cargo capacity (descending).
            * Order the clients by all trucks (meeting above condition) count (descending), then by name (ascending).
           NOTE: You may need to call .ToArray() function before the selection in order to detach entities from the database and avoid runtime errors (EF Core bug). */

            var jsonView = context.Clients
                .Where(x => x.ClientsTrucks.Any(t => t.Truck.TankCapacity >= capacity))
                .ToList()
                .Select(x => new ClientWithMostTrucksJsonView
                {
                    Name = x.Name,
                    Trucks = x.ClientsTrucks.Where(t => t.Truck.TankCapacity >= capacity)
                    .OrderBy(o => o.Truck.MakeType)
                    .ThenByDescending(o => o.Truck.CargoCapacity)
                    .Select(x => new TruckJsonViewModel
                    {
                        TruckRegistrationNumber = x.Truck.RegistrationNumber,
                        VinNumber = x.Truck.VinNumber,
                        TankCapacity = x.Truck.TankCapacity,
                        CargoCapacity = x.Truck.CargoCapacity,
                        CategoryType = x.Truck.CategoryType.ToString(),
                        MakeType = x.Truck.MakeType.ToString()
                    })
                    .ToList()
                })
                .OrderByDescending(o => o.Trucks.Count())
                .ThenBy(o => o.Name)
                .Take(10)
                .ToList();
            var result = JsonConvert.SerializeObject(jsonView, Formatting.Indented);
            return result;
        }
    }
}
