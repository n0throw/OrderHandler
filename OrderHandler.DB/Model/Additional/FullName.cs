namespace OrderHandler.DB.Model.Additional;

public struct FullName
{
    public string Surname { get; set; }
    public string Name { get; set; }
    public string Patronymic { get; set; }

    public FullName(
        string surname = "Анонимов",
        string name = "Аноним",
        string patronymic = "Анонимович")
    {
        Surname = surname;
        Name = name;
        Patronymic = patronymic;
    }
}