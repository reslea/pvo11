namespace FirstMvcApp.Database;

public class User
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int Age { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public DateTime CreatedDate { get; set; }
}
