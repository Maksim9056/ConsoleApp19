using System.Text.Json;

namespace ConsoleApp19
{ 

    class Program
    {
        static void Main(string[] args)
        {
            try
            {


                string json = File.ReadAllText("SuperHero.json"); // Загружаем JSON-файл

                var options = new JsonSerializerOptions // Опции для десериализации JSON
                {
                    PropertyNameCaseInsensitive = true
                };

                SuperheroSquad squad = System.Text.Json.JsonSerializer.Deserialize<SuperheroSquad>(json, options); // Десериализуем JSON в объекты

                List<Superhero> superheroes = squad.Members; // Получаем список супергероев
                superheroes = Add(superheroes);   // Добавление новых супергероев
                List<Superhero> sortedSuperheroes = superheroes.OrderBy(superhero => superhero.Age).ToList(); // Сортировка по возрасту
                squad.Members = sortedSuperheroes;
                Console.WriteLine("Сортировка супергероев по возрасту:");
                foreach (var superhero in sortedSuperheroes)
                {
                    Console.WriteLine($"Имя: {superhero.Name}, Возраст: {superhero.Age}");
                }
                string filePath = "yourFile.csv";
                System.IO.StreamWriter writer = new System.IO.StreamWriter(filePath);

                writer.WriteLine($"{squad.SquadName},{squad.HomeTown},{squad.Formed},{squad.SecretBase},{squad.Active}");
                foreach (Superhero member in squad.Members)
                {
                    string powers = string.Join<string>(",", member.Powers);
                    writer.WriteLine($"{member.Name},{member.Age},{member.SecretIdentity},{powers}");
                }

                writer.Close();
                Console.WriteLine($"Файл сохранен {filePath}");
                Console.ReadLine();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static List<Superhero> Add(List<Superhero> superheroes)
        {
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
            return superheroes;
        }
    }
}