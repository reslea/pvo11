using Serialization;

var spideyJson = "{\"FirstName\":\"Peter\",\"LastName\":\"Parker\",\"Age\":16,\"IsAvenger\":true}";
var spidey = new Hero
{
  FirstName = "Peter",
  LastName = "Parker",
  Age = 16,
  IsAvenger = true
};

Console.ReadLine();