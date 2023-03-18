using OrderHandler.DB.Data.UserAdd;

namespace OrderHandler.DB.Data;

public class User
{
    public int Id { get; set; }
    public string Login { get; set; }
    // Именительный
    public FullName Nominative { get; set; }
    // Родительный
    public FullName Genitive { get; set; }
    // Дательный
    public FullName Dative { get; set; }
    // Винительный
    public FullName Accusative { get; set; }
    // Творительныый
    public FullName Ablative { get; set; }
    // Предложный
    public FullName Prepositional { get; set; }
    
    public User(int id, string login)
    {
        Id = id;
        Login = login;
        Nominative = new();
        Genitive = new();
        Dative = new();
        Accusative = new();
        Ablative = new();
        Prepositional = new();
    }

    public User(
        int id,
        string login,
        FullName nominative,
        FullName genitive,
        FullName dative,
        FullName accusative,
        FullName ablative,
        FullName prepositional)
    {
        Id = id;
        Login = login;
        Nominative = nominative;
        Genitive = genitive;
        Dative = dative;
        Accusative = accusative;
        Ablative = ablative;
        Prepositional = prepositional;
    }
}
