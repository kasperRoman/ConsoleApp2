using System.Text.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using HttpClientDemo; // підключаємо модель Post

namespace HttpClientDemo
{
    internal class Program
    {
        static readonly HttpClient client = new HttpClient();

        static async Task Main()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("https://jsonplaceholder.typicode.com/posts/1");
                response.EnsureSuccessStatusCode(); // перевірка статусу

                string body = await response.Content.ReadAsStringAsync(); // читаємо JSON як текст

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true // ігнорує регістр у назвах JSON
                };

                Post? post = JsonSerializer.Deserialize<Post>(body, options); // перетворюємо JSON у об’єкт

                if (post == null)
                {
                    Console.WriteLine("Не вдалося перетворити JSON у об’єкт.");
                    return;
                }

                Console.WriteLine($"ID: {post.Id}");
                Console.WriteLine($"Title: {post.Title}");
                Console.WriteLine($"Body: {post.Body}");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("Запит не вдався. Спробуйте пізніше.");
                Console.Error.WriteLine($"[Деталі для розробника] {ex.Message}");
            }
            catch (JsonException jex)
            {
                Console.WriteLine("Помилка при обробці JSON.");
                Console.Error.WriteLine($"[Деталі для розробника] {jex.Message}");
            }
        }
    }
}
