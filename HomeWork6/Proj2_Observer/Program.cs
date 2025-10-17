﻿using Project2_Observer;

var exchange = new CurrencyExchange();

var dollar = new DollarObserver();
var euro = new EuroObserver();
var ruble = new RubleObserver();

exchange.AddSubscriber(dollar);
exchange.AddSubscriber(euro);
exchange.AddSubscriber(ruble);

exchange.EurToKzt = 485.2;
exchange.UsdToKzt = 512.7;
exchange.RubToKzt = 5.02;

Console.WriteLine("Евро отписалась");

exchange.RemoveSubscriber(euro);

Console.WriteLine("Новые цены");
exchange.UsdToKzt = 486.5;
exchange.EurToKzt = 511.3;
exchange.RubToKzt = 5.10;


namespace Project2_Observer
{
    public interface IObserver
    {
        void Update(ISubject subject);
    }   

    public interface ISubject
    {
        void AddSubscriber(IObserver observer);
        void RemoveSubscriber(IObserver observer);
        void NotifySubscriber();
    
    }

    public class CurrencyExchange : ISubject
    {
        private readonly List<IObserver> _observers = new ();
        private double _usdToKzt;
        private double _rubToKzt;
        private double _eurToKzt;

        public double UsdToKzt
        {
            get => _usdToKzt;
            set
            {
                _usdToKzt = value;
                NotifySubscriber();
            }
        }
    
        public double RubToKzt
        {
            get => _rubToKzt;
            set
            {
                _rubToKzt = value;
                NotifySubscriber();
            }
        }
    
        public double EurToKzt
        {
            get => _eurToKzt;
            set
            {
                _eurToKzt = value;
                NotifySubscriber();
            }
        }
    
        public void AddSubscriber(IObserver observer)
        {
            Console.WriteLine($"Субъект: {observer} подписался на издателя");
            _observers.Add(observer);
        }

        public void RemoveSubscriber(IObserver observer)
        {
            Console.WriteLine($"Субъект: {observer} отписался от издателя");
            _observers.Remove(observer);
        }

        public void NotifySubscriber()
        {
            Console.WriteLine("Субъект: Уведомление подписчиков");
            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }
    }

    public class DollarObserver : IObserver
    {

        public void Update(ISubject subject)
        {
            if (subject is CurrencyExchange exchange)
                Console.WriteLine($"Курс USD обновлен: {exchange.UsdToKzt} KZT");
        }
    }

    public class RubleObserver : IObserver
    {
        public void Update(ISubject subject)
        {
            if (subject is CurrencyExchange exchange)
                Console.WriteLine($"Курс RUBLE обновлен: {exchange.RubToKzt} KZT");
        }
    }

    public class EuroObserver : IObserver
    {

        public void Update(ISubject subject)
        {
            if (subject is CurrencyExchange exchange)
                Console.WriteLine($"Курс EURO обновлен: {exchange.EurToKzt} KZT");
        }
    }
}