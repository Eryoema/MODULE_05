using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB
{
    public interface ITransport
    {
        void Move();
        void FuelUp();
    }

    public class Car : ITransport
    {
        private string model;
        private int speed;

        public Car(string model, int speed)
        {
            this.model = model;
            this.speed = speed;
        }

        public void Move()
        {
            Console.WriteLine($"Автомобиль {model} едет со скоростью {speed} км/ч.");
        }

        public void FuelUp()
        {
            Console.WriteLine($"Заправка автомобиля {model}.");
        }
    }

    public class Motorcycle : ITransport
    {
        private string model;
        private int speed;

        public Motorcycle(string model, int speed)
        {
            this.model = model;
            this.speed = speed;
        }

        public void Move()
        {
            Console.WriteLine($"Мотоцикл {model} едет со скоростью {speed} км/ч.");
        }

        public void FuelUp()
        {
            Console.WriteLine($"Заправка мотоцикла {model}.");
        }
    }

    public class Plane : ITransport
    {
        private string model;
        private int speed;

        public Plane(string model, int speed)
        {
            this.model = model;
            this.speed = speed;
        }

        public void Move()
        {
            Console.WriteLine($"Самолет {model} летит со скоростью {speed} км/ч.");
        }

        public void FuelUp()
        {
            Console.WriteLine($"Заправка самолета {model}.");
        }
    }

    public class Bicycle : ITransport
    {
        private string model;
        private int speed;

        public Bicycle(string model, int speed)
        {
            this.model = model;
            this.speed = speed;
        }

        public void Move()
        {
            Console.WriteLine($"Велосипед {model} движется со скоростью {speed} км/ч.");
        }

        public void FuelUp()
        {
            Console.WriteLine($"Велосипед {model} не требует заправки.");
        }
    }

    public abstract class TransportFactory
    {
        public abstract ITransport CreateTransport(string model, int speed);
    }

    public class CarFactory : TransportFactory
    {
        public override ITransport CreateTransport(string model, int speed)
        {
            return new Car(model, speed);
        }
    }

    public class MotorcycleFactory : TransportFactory
    {
        public override ITransport CreateTransport(string model, int speed)
        {
            return new Motorcycle(model, speed);
        }
    }

    public class PlaneFactory : TransportFactory
    {
        public override ITransport CreateTransport(string model, int speed)
        {
            return new Plane(model, speed);
        }
    }

    public class BicycleFactory : TransportFactory
    {
        public override ITransport CreateTransport(string model, int speed)
        {
            return new Bicycle(model, speed);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите тип транспорта: ");
            Console.WriteLine("1) Автомобиль");
            Console.WriteLine("2) Мотоцикл");
            Console.WriteLine("3) Самолет");
            Console.WriteLine("4) Велосипед");

            int choice = int.Parse(Console.ReadLine());

            Console.Write("Введите модель транспорта: ");
            string model = Console.ReadLine();

            Console.Write("Введите скорость транспорта (км/ч): ");
            int speed = int.Parse(Console.ReadLine());

            TransportFactory factory = null;

            switch (choice)
            {
                case 1:
                    factory = new CarFactory();
                    break;
                case 2:
                    factory = new MotorcycleFactory();
                    break;
                case 3:
                    factory = new PlaneFactory();
                    break;
                case 4:
                    factory = new BicycleFactory();
                    break;
                default:
                    Console.WriteLine("Неверный выбор.");
                    return;
            }

            ITransport transport = factory.CreateTransport(model, speed);
            transport.Move();
            transport.FuelUp();
        }
    }
}
