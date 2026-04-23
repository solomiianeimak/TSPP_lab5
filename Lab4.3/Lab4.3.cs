using System;

public interface IObserver
{
    void Update(string status);
}

public class Customer : IObserver
{
    private string _name;

    public Customer(string name) => _name = name;

    public void Update(string status)
    {
        Console.WriteLine($"Сповіщення для {_name}:\nСтатус замовлення: '{status}'");
    }
}

public class Order
{
    private List<IObserver> _observers = new List<IObserver>();
    private string _status;

    public void Subscribe(IObserver observer) => _observers.Add(observer);

    public void Unsubscribe(IObserver observer) => _observers.Remove(observer);

    public void SetStatus(string newStatus)
    {
        _status = newStatus;
        NotifyObservers();
    }

    private void NotifyObservers()
    {
        foreach (var observer in _observers)
        {
            observer.Update(_status);
        }
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        Order myOrder = new Order();
        Customer c1 = new Customer("Іван");
        Customer c2 = new Customer("Оксана");

        myOrder.Subscribe(c1);
        myOrder.Subscribe(c2);

        myOrder.SetStatus("Обробляється");
        Console.WriteLine("");
        myOrder.SetStatus("Відправлено");
        Console.ReadKey();
    }
}
