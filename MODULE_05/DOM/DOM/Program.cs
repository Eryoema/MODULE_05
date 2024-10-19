using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOM
{
    public interface IVehicle
    {
        void Drive();
        void Refuel();
    }

    public class Car : IVehicle
    {
        private string make;
        private string model;
        private string fuelType;

        public Car(string make, string model, string fuelType)
        {
            this.make = make;
            this.model = model;
            this.fuelType = fuelType;
        }

        public void Drive()
        {
            Console.WriteLine($"Вождение автомобиля {make} {model} на {fuelType}.");
        }

        public void Refuel()
        {
            Console.WriteLine($"Заправка автомобиля {make} {model}.");
        }
    }

    public class Motorcycle : IVehicle
    {
        private string type;
        private double engineCapacity;

        public Motorcycle(string type, double engineCapacity)
        {
            this.type = type;
            this.engineCapacity = engineCapacity;
        }

        public void Drive()
        {
            Console.WriteLine($"Вождение {type} мотоцикла с двигателем {engineCapacity}L.");
        }

        public void Refuel()
        {
            Console.WriteLine($"Заправка {type} мотоцикла.");
        }
    }

    public class Truck : IVehicle
    {
        private double payloadCapacity;
        private int axles;

        public Truck(double payloadCapacity, int axles)
        {
            this.payloadCapacity = payloadCapacity;
            this.axles = axles;
        }

        public void Drive()
        {
            Console.WriteLine($"Вождение грузовика с грузоподъемностью {payloadCapacity} тонн и {axles} осями.");
        }

        public void Refuel()
        {
            Console.WriteLine("Заправка грузовика.");
        }
    }

    public abstract class VehicleFactory
    {
        public abstract IVehicle CreateVehicle();
    }

    public class CarFactory : VehicleFactory
    {
        private string make;
        private string model;
        private string fuelType;

        public CarFactory(string make, string model, string fuelType)
        {
            this.make = make;
            this.model = model;
            this.fuelType = fuelType;
        }

        public override IVehicle CreateVehicle()
        {
            return new Car(make, model, fuelType);
        }
    }

    public class MotorcycleFactory : VehicleFactory
    {
        private string type;
        private double engineCapacity;

        public MotorcycleFactory(string type, double engineCapacity)
        {
            this.type = type;
            this.engineCapacity = engineCapacity;
        }

        public override IVehicle CreateVehicle()
        {
            return new Motorcycle(type, engineCapacity);
        }
    }

    public class TruckFactory : VehicleFactory
    {
        private double payloadCapacity;
        private int axles;

        public TruckFactory(double payloadCapacity, int axles)
        {
            this.payloadCapacity = payloadCapacity;
            this.axles = axles;
        }

        public override IVehicle CreateVehicle()
        {
            return new Truck(payloadCapacity, axles);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите тип транспорта: 1) Автомобиль 2) Мотоцикл 3) Грузовик");
            int choice = int.Parse(Console.ReadLine());

            IVehicle vehicle = null;

            switch (choice)
            {
                case 1:
                    Console.Write("Введите марку: ");
                    string make = Console.ReadLine();
                    Console.Write("Введите модель: ");
                    string model = Console.ReadLine();
                    Console.Write("Введите тип топлива: ");
                    string fuelType = Console.ReadLine();
                    var carFactory = new CarFactory(make, model, fuelType);
                    vehicle = carFactory.CreateVehicle();
                    break;

                case 2:
                    Console.Write("Введите тип мотоцикла (спортивный, туристический): ");
                    string type = Console.ReadLine();
                    Console.Write("Введите объем двигателя: ");
                    double engineCapacity = double.Parse(Console.ReadLine());
                    var motorcycleFactory = new MotorcycleFactory(type, engineCapacity);
                    vehicle = motorcycleFactory.CreateVehicle();
                    break;

                case 3:
                    Console.Write("Введите грузоподъемность (тонн): ");
                    double payloadCapacity = double.Parse(Console.ReadLine());
                    Console.Write("Введите количество осей: ");
                    int axles = int.Parse(Console.ReadLine());
                    var truckFactory = new TruckFactory(payloadCapacity, axles);
                    vehicle = truckFactory.CreateVehicle();
                    break;

                default:
                    Console.WriteLine("Неверный выбор.");
                    return;
            }

            vehicle.Drive();
            vehicle.Refuel();
        }
    }
}
