using Sales.Backoffice.Model.Enums;

namespace Sales.Backoffice.Model;

public class Adress : AssignedToAnAgent
{
    public AdressCategory AdressCategory { get; set; }
    public AdressType AdressType { get; set; }
    public string Street { get; set; }
    public string Number { get; set; }
    public string ZipCode { get; set; }
    public string Neighborhood { get; set; }
    public string City { get; set; }
    public string State { get; set; }
}