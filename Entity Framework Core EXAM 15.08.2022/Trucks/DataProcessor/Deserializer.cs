namespace Trucks.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using Data;
    using Newtonsoft.Json;
    using Trucks.Data.Models;
    using Trucks.Data.Models.Enums;
    using Trucks.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedDespatcher
            = "Successfully imported despatcher - {0} with {1} trucks.";

        private const string SuccessfullyImportedClient
            = "Successfully imported client - {0} with {1} trucks.";

        public static string ImportDespatcher(TrucksContext context, string xmlString)
        {
            var output = new StringBuilder();

            var despatcherXmlImport = XmlConverter.Deserializer<DespatcherXmlImportModel>(xmlString, "Despatchers");

            var validDespatchers = new List<Despatcher>();

            foreach (var currDespatcher in despatcherXmlImport)
            {
                /*⦁	If there are any validation errors for the despatcher entity (such as invalid name),
                 * do not import any part of the entity and append an error message to the method output.
                ⦁	If there is a null or empty position for despatcher entity, do not import any part of the entity and append an error message to the method output.
                ⦁	If there are any validation errors for the truck entity (such as invalid registration number or missing VIN number,
                tank capacity or weight capacity is invalid), do not import it (only the truck itself, not the whole despatcher info) and append an error message to the method output.*/

                if (!IsValid(currDespatcher))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var validDespatcher = new Despatcher
                {
                    Name = currDespatcher.Name,
                    Position = currDespatcher.Position,
                };

                foreach (var currTruck in currDespatcher.Trucks)
                {
                    if (!IsValid(currTruck))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    validDespatcher.Trucks.Add(new Truck
                    {
                        RegistrationNumber = currTruck.RegistrationNumber,
                        VinNumber = currTruck.VinNumber,
                        TankCapacity = currTruck.TankCapacity,
                        CargoCapacity = currTruck.CargoCapacity,
                        CategoryType = Enum.Parse<CategoryType>(currTruck.CategoryType),
                        MakeType = Enum.Parse<MakeType>(currTruck.MakeType)
                    });
                }
                validDespatchers.Add(validDespatcher);
                output.AppendLine(String.Format(SuccessfullyImportedDespatcher,validDespatcher.Name,validDespatcher.Trucks.Count));
            }
            context.AddRange(validDespatchers);
            context.SaveChanges();
            return output.ToString().TrimEnd();
        }
        public static string ImportClient(TrucksContext context, string jsonString)
        {
            var output = new StringBuilder();

            var clientsJsonImport = JsonConvert.DeserializeObject<IEnumerable<ClientJsonImportModel>>(jsonString);

            var validClients = new List<Client>();

            foreach (var currClient in clientsJsonImport)
            {
                /*⦁	If any validation errors occur (such as invalid name, missing or invalid nationality or type "usual"),
                 * do not import any part of the entity and append an error message to the method output.
                  ⦁	Take only the unique trucks.
                  ⦁	If a truck does not exist in the database, append an error message to the method output and continue with the next truck.*/
                if (!IsValid(currClient) || currClient.Type == "usual")
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var validClient = new Client
                {
                    Name = currClient.Name,
                    Nationality = currClient.Nationality,
                    Type = currClient.Type
                };

                foreach (var currTruckId in currClient.Trucks.Distinct())
                {
                    if (!context.Trucks.Any(x => x.Id == currTruckId))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }
                    validClient.ClientsTrucks.Add(new ClientTruck { TruckId = currTruckId });
                }
                validClients.Add(validClient);
                output.AppendLine(String.Format(SuccessfullyImportedClient, validClient.Name, validClient.ClientsTrucks.Count));
            }
            context.AddRange(validClients);
            context.SaveChanges();
            return output.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
