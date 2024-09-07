namespace Sales.Backoffice.Dto.Requests.Commands;

public class CreateAdressRequest
{
    public int AdressCategory { get; set; }
    public int AdressType { get; set; }
    public string Street { get; set; }
    public string Number { get; set; }
    public string ZipCode { get; set; }
    public string Neighborhood { get; set; }
    public string City { get; set; }
    public string State { get; set; }
}