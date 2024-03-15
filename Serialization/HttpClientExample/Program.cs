using System.Text.Json;

namespace HttpClientExample
{
    internal class Program
    {
        private static readonly HttpClient httpClient = new HttpClient();
        static async Task Main(string[] args)
        {
            var TodoesString = await httpClient.GetStringAsync("https://jsonplaceholder.typicode.com/todos");
            List<ToDo>? TodoesList = JsonSerializer.Deserialize<List<ToDo>>(TodoesString , new JsonSerializerOptions { PropertyNameCaseInsensitive = true});
            TodoesList?.ForEach((item) => Console.WriteLine(item));
        }
    }


    public class ToDo
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }

        public override string ToString()
        {
            return $"{Id} : {UserId} : {Title} \n {Completed} \n\n";
        }
    }

}
