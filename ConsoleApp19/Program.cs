namespace ConsoleApp19
{
    using System;
    using System.IO;
    using System.Text.Json;
    using System.Collections.Generic;
    using System.Linq;
    using System.Formats.Asn1;
    using ServiceStack.Text;

    // using ServiceStack.Text;

    // Создаем класс для супергероев
    class Superhero
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string SecretIdentity { get; set; }
        public List<string> Powers { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string json = File.ReadAllText("SuperHero.json"); // Загружаем JSON-файл

            var options = new JsonSerializerOptions // Опции для десериализации JSON
            {
                PropertyNameCaseInsensitive = true
            };

            var squad = System.Text.Json.JsonSerializer.Deserialize<SuperheroSquad>(json, options); // Десериализуем JSON в объекты

            List<Superhero> superheroes = squad.Members; // Получаем список супергероев
                                                         // Добавление новых супергероев
                                                         // Добавление новых супергероев
            superheroes.Add(new Superhero
            {
                Name = "Spider-Man",
                Age = 20,
                SecretIdentity = "Peter Parker",
                Powers = new List<string> { "Superhuman strength", "Wall-crawling", "Spider-sense", "Web-shooters" }
            });

            superheroes.Add(new Superhero
            {
                Name = "Wonder Woman",
                Age = 500,
                SecretIdentity = "Diana Prince",
                Powers = new List<string> { "Superhuman strength", "Flight", "Lasso of Truth" }
            });

            List<Superhero> sortedSuperheroes = superheroes.OrderBy(superhero => superhero.Age).ToList(); // Сортировка по возрасту

            Console.WriteLine("Сортировка супергероев по возрасту:");
            foreach (var superhero in sortedSuperheroes)
            {
                Console.WriteLine($"Имя: {superhero.Name}, Возраст: {superhero.Age}");
            }


            using (var reader = new StreamReader("superheroes.csv"))
            using (var csv = new CsvReader(reader))
            {
                var records = csv.GetRecords<Superhero>().ToList();

                Console.WriteLine("Содержимое файла superheroes.csv:");
                foreach (var record in records)
                {
                    Console.WriteLine($"Имя: {record.Name}, Возраст: {record.Age}, Секретная идентичность: {record.SecretIdentity}");
                }
            }


            using (var reader = new StreamReader("superheroes.csv"))
            using (var csv = new CsvReader(reader))
            {
                var records = csv.GetRecords<Superhero>().ToList();

                Console.WriteLine("Содержимое файла superheroes.csv:");
                foreach (var record in records)
                {
                    Console.WriteLine($"Имя: {record.Name}, Возраст: {record.Age}, Секретная идентичность: {record.SecretIdentity}");
                }
                Console.ReadLine();
            }
        }
    }

    // Класс для хранения данных о команде супергероев
    class SuperheroSquad
    {
        public string SquadName { get; set; }
        public string HomeTown { get; set; }
        public int Formed { get; set; }
        public string SecretBase { get; set; }
        public bool Active { get; set; }
        public List<Superhero> Members { get; set; }
    }

}