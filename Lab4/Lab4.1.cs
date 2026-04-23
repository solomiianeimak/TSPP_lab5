using System;

public class ResourceManager
{
    private static ResourceManager _instance;

    public static ResourceManager GetInstance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ResourceManager();
            }
            return _instance;
        }
    }

    private List<string> _resources;

    private ResourceManager() => _resources = new List<string>();

    public void LoadResource(string resourceName) => _resources.Add(resourceName);

    public override string ToString()
    {
        string result = string.Join(", ", _resources);
        return result;
    }
}


class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        ResourceManager m1 = ResourceManager.GetInstance;
        ResourceManager m2 = ResourceManager.GetInstance;
        m1.LoadResource("Зображення");
        m1.LoadResource("Шрифт");
        m2.LoadResource("Дані");
        Console.WriteLine("Ресурси в першому менеджері: " + m1);
        Console.WriteLine("Ресурси в другому менеджері: " + m2);
        Console.WriteLine($"Чи посилаються змінні на один і той самий об'єкт? {ReferenceEquals(m1, m2)}");
        Console.ReadKey();
    }
}
