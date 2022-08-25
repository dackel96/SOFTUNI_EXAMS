using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Trucks.DataProcessor.ExportDto
{
    [XmlType("Despatcher")]
    public class DespatcherWithTrucksXmlView
    {
        [XmlAttribute("TrucksCount")]
        public int TrucksCount { get; set; }
        [XmlElement("DespatcherName")]
        public string DespatcherName { get; set; }
        [XmlArray("Trucks")]
        public TruckXmlView[] Trucks { get; set; }
    }
    [XmlType("Truck")]
    public class TruckXmlView
    {
        [XmlElement("RegistrationNumber")]
        public string RegistrationNumber { get; set; }
        [XmlElement("Make")]
        public string Make { get; set; }
    }
}

/*<Despatchers>
  <Despatcher TrucksCount="6">
    <DespatcherName>Vladimir Hristov</DespatcherName>
    <Trucks>
      <Truck>
        <RegistrationNumber>CT2462BX</RegistrationNumber>
        <Make>Scania</Make>
      </Truck>
      <Truck>
*/