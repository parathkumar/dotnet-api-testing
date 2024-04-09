using System.Text.Json.Serialization;
public record class User (
    [property: JsonPropertyName("userId")] int userId,
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("title")] string Title,
    [property: JsonPropertyName("body")] string UserId
);