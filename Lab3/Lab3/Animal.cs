using System;

namespace Lab3
{
    public class Animal
    {
        // Вес будет у каждого животного
        public float Weight = 0;

        // Правильный рандом
        protected static Random rnd = new Random();

        // Предоставим информацию о весе и позволим перегружать это свойство
        public virtual string GetInfo()
        {
            var str = string.Format("\nВес: {0} кг", this.Weight);
            return str;
        }
    }

    public class Cow : Animal
    {
        // Счетчики
        public float LengthHorns = 0;
        public float VolumeMilk = 0;

        // Перегружаем функцию, чтобы вывести особые параметры
        public override string GetInfo()
        {
            var str = "Это корова";
            str += base.GetInfo();
            str += string.Format("\nДлина рогов: {0} см", this.LengthHorns);
            str += string.Format("\nМолока в сутки: {0} л", this.VolumeMilk);
            return str;
        }

        // Зададим параметры при создании объекта
        public static Cow Generate()
        {
            return new Cow
            {
                Weight = 20 + rnd.Next() % 300,
                LengthHorns = 5 + rnd.Next() % 20,
                VolumeMilk = rnd.Next() % 20
            };
        }
    }

    public class Dog : Animal
    {
        // Счетчики
        public string Breed = "";
        // И список пород
        public static string[] Breeds = {
            "Немецкая овчарка",
            "Ротвейлер",
            "Доберман",
            "Сибирский хаски"
        };
        public float Range = 0;
        public float TailLength = 0;

        // Перегружаем функцию, чтобы вывести особые параметры
        public override string GetInfo()
        {
            var str = "Это собака";
            str += base.GetInfo();
            str += string.Format("\nПорода: {0}", this.Breed);
            str += string.Format("\nДистанция для команд: {0} м", this.Range);
            str += string.Format("\nДлина хвоста: {0} см", this.TailLength);
            return str;
        }

        // Зададим параметры при создании объекта
        public static Dog Generate()
        {
            return new Dog
            {
                Weight = 1 + rnd.Next() % 90,
                TailLength = rnd.Next() % 100,
                Breed = Breeds[rnd.Next(0, Breeds.Length)],
                Range = rnd.Next() % 500
            };
        }
    }

    public class Cat : Animal
    {
        // Счетчик, наличие шерсти
        public bool IsWool = false;
        public int CountMouse = 0;

        // Перегружаем функцию, чтобы вывести особые параметры
        public override string GetInfo()
        {
            var str = "Это кот";
            str += base.GetInfo();
            str += string.Format("\nШерсть: {0}", this.IsWool ? "Присутствует" : "Отсутсвует");
            str += string.Format("\nМышей в день: {0}", this.CountMouse);
            return str;
        }

        // Зададим параметры при создании объекта
        public static Cat Generate()
        {
            return new Cat
            {
                Weight = 1 + rnd.Next() % 10,
                IsWool = rnd.Next() % 2 == 0,
                CountMouse = rnd.Next() % 20
            };
        }
    }

}