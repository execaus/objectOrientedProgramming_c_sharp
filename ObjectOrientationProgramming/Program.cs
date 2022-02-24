using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientationProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            // процедурное программирование
            int width = 8;
            int height = 4;

            int rectArea = calculateRectangleArea(width, height);

            // два основновных понятия - класс и объект
            Rectangle rect1 = new Rectangle(5, 10);
            Rectangle rect2 = new Rectangle(4, 12);
            Rectangle rect3 = new Rectangle(47, 15);
            rect1.calculateArea();
            rect2.calculateArea();
            rect3.calculateArea();

            // модификаторы доступа
            Rectangle2 rect2_1 = new Rectangle2(1, 2);
            // не получится
            // var rect2_1_width = rect2_1.width;
            // только
            int rect2_1_width = rect2_1.Width;

            User user = new User("Tom", 123);
            // не получится
            // user.id = 2;
            int userId = user.Id;

            Person person = new Person("Tom", 23);
            Worker worker = new Worker("Alice", 43);
            Developer developer = new Developer("C#", "senior", 23, "Mark", 33);
            int personAge = person.Age;
            int developerAge = developer.Age;
            worker.Passport = "3425354658";
            worker.Passport = "123";
            string workerPassword = worker.Passport;

            // перегрузка методов
            Calculator calculator = new Calculator();
            calculator.Add(2, 2); // 4
            calculator.Add("2", "2"); // 22

            // параметрический полиморфизм
            person.Say();
            worker.Say();
            developer.Say();

            Person[] people = new Person[3] { person, worker, developer };
            foreach (Person elem in people)
            {
                elem.Say();
            }

            // композиция и агрегация
            Car car = new Car(new Freshener());
            car.drive();
        }

        public static int calculateRectangleArea(int width, int height)
        {
            return width * height;
        }
    }

    class Rectangle
    {
        int width;
        int height;

        public Rectangle(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public int calculateArea()
        {
            return this.width * this.height;
        }

        public int calculatePerimeter()
        {
            return (this.width + this.height) * 2;
        }
    }

    class Rectangle2
    {
        private int width;
        private int height;
        public int Height { get => height; set => height = value; }
        public int Width
        {
            get
            {
                return width;
            }
            set
            {
                if (value <= 0)
                {
                    width = 1;
                }
                else
                {
                    width = value;
                }
            }
        }

        public Rectangle2(int width, int height)
        {
            this.width = width;
            this.height = height;
        }


        public int calculateArea()
        {
            return this.width * this.height;
        }
    }

    class User
    {
        private string username;
        private int password;
        private int id;
        public string Username { get => username; set => username = value; }
        public int Password { get => password; set => password = value; }
        public int Id { get => id; }

        public User(string username, int password)
        {
            this.username = username;
            this.password = password;
            this.id = this.generateRandomId();
        }

        private int generateRandomId()
        {
            var rand = new Random();
            return rand.Next(111111, 222222);
        }
    }

    class Person
    {
        protected string name;
        private int age;

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value <= 0)
                {
                    age = 1;
                }
                else
                {
                    age = value;
                }
            }
        }

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public void Say()
        {
            Console.WriteLine(string.Format("Hi, i'm {0}, i'm person!", this.name));
        }
    }
    class Worker : Person
    {
        private string INN;
        private string SNILS;
        private string passport;

        public string Passport
        {
            get
            {
                return this.passport;
            }
            set
            {
                if (value.Length == 10)
                {
                    this.passport = value;
                } else
                {
                    Console.WriteLine("invalid password indentity");
                }
            }
        }

        public Worker(string name, int age) : base(name, age)
        {

        }

        public new void Say()
        {
            Console.WriteLine(string.Format("Hi, i'm {0}, i'm worker!", this.name));
        }
    }
    class Developer : Worker
    {
        private string programmingLanguage;
        private string level;
        private int teamNumber;

        public Developer(string programmingLanguage, string level, int teamNumber, string name, int age) : base(name, age)
        {
            this.programmingLanguage = programmingLanguage;
            this.level = level;
            this.teamNumber = teamNumber;
        }

        public new void Say()
        {
            Console.WriteLine(string.Format("Hi, i'm {0}, i'm developer!", this.name));
        }
    }


    class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
        public string Add(string a, string b)
        {
            return a + b;
        }
    }


    class Car
    {
        private Engine engine;
        private List<Wheel> listWheel;
        private Freshener freshener;
        public Car(Freshener freshener)
        {
            // композиция
            this.engine = new Engine();
            this.listWheel = new List<Wheel>();
            this.listWheel.Add(new Wheel());
            this.listWheel.Add(new Wheel());
            this.listWheel.Add(new Wheel());
            this.listWheel.Add(new Wheel());

            // агрегация
            this.freshener = freshener;
        }

        // делегирование
        public void drive()
        {
            this.engine.drive();
            foreach (Wheel wheel in this.listWheel)
            {
                wheel.drive();
            }
        }
    }
    class Engine
    {
        public void drive() 
        {
            Console.WriteLine("Двигатель работает!");
        }
    }
    class Wheel
    {
        public void drive() 
        {
            Console.WriteLine("Колёса крутятся!");
        }
    }
    class Freshener
    {

    }
    class House
    {
        private Freshener freshener;

        public House(Freshener freshener)
        {
            // агрегация
            this.freshener = freshener;
        }
    }

    // абстрактные классы и интерфейсы
    interface Client
    {
        void Connect(string url);
        string Read();
        void Write(string data);
    }

    abstract class AbstractClient
    {
        public void Connect(string url)
        {
            Console.WriteLine(string.Format("Клиент с адресом {0} успешно подключен!"), url);
        }

        public abstract string Read();
        public abstract void Write();
    }

    // -------
    interface Reader
    {
        void Read(string url);
    }
    interface Writer
    {
        void Write(string data);
    }
    class FileClient : Reader, Writer
    {
        public void Read(string url)
        {
            throw new NotImplementedException();
        }

        public void Write(string data)
        {
            throw new NotImplementedException();
        }
    }
    
    // -------
    // обобщение (generic)
    interface Repository<T>
    {
        T Create(T elem);
        T Get();
        T Delete(T elem);
        T Update(T elem);
    }
    class PersonRepository : Repository<Person>
    {
        public Person Create(Person elem)
        {
            throw new NotImplementedException();
        }

        public Person Delete(Person elem)
        {
            throw new NotImplementedException();
        }

        public Person Get()
        {
            throw new NotImplementedException();
        }

        public Person Update(Person elem)
        {
            throw new NotImplementedException();
        }
    }
    class CarRepository : Repository<Car>
    {
        public Car Create(Car elem)
        {
            throw new NotImplementedException();
        }

        public Car Delete(Car elem)
        {
            throw new NotImplementedException();
        }

        public Car Get()
        {
            throw new NotImplementedException();
        }

        public Car Update(Car elem)
        {
            throw new NotImplementedException();
        }
    }
}

