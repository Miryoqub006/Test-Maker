using System.Text.Json;
using TestProject.Api.Entites;

namespace TestProject.Api.Repositories;

public class QuestionsRepositories : IQuestionRepository
{
    private readonly string _filePath;
    public QuestionsRepositories()
    {
        var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        _filePath = Path.Combine(directoryPath, "Questions.json");

        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        if (!File.Exists(_filePath))
        {
            var stream = File.Create(_filePath);
            stream.Close();
            File.WriteAllText(_filePath, "[]");
        }
    }

    public List<Question> GetAllQuestions()
    {
        string json = File.ReadAllText(_filePath);

        if (string.IsNullOrWhiteSpace(json))
        {
            return new List<Question>();
        }

        
        try 
        {
            List<Question> questions = JsonSerializer.Deserialize<List<Question>>(json);
            return questions ?? new List<Question>();
        }
        catch(JsonException)
        {
            return new List<Question>();
        }
    }

    public void SaveAllQuestion(List<Question> questions)
    {
        var json = JsonSerializer.Serialize(questions);
        File.WriteAllText(_filePath, json);

    }
}