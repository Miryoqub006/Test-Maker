using TestProject.Api.DTOS;
using TestProject.Api.Entites;
using TestProject.Api.Repositories;

namespace TestProject.Api.Service;

public class QuestionService : IQuestionService
{
    private readonly IQuestionRepository _questionRepository;
    public QuestionService()
    {
        _questionRepository = new QuestionsRepositories();
    }

    public void AddQuestion(Question question)
    {
        Question question1 = new Question()
        {
            QuestionId = Guid.NewGuid(),
            Text = question.Text,
            Answer = question.Answer,
            VariantA = question.VariantA,
            VariantB = question.VariantB,
            VariantC = question.VariantC,
        };
        var questions = _questionRepository.GetAllQuestions();
        questions.Add(question1);
        _questionRepository.SaveAllQuestion(questions);

        Console.WriteLine("Saved");

    }

    public int GetCountOfQuestions()
    {
        int counter = 0;
        List<Question> questions = _questionRepository.GetAllQuestions();

        for (int i = 0; i < questions.Count; i++)
        {
            if (questions[i] is not null)
            {
                counter++;
            }
        }

        return counter;
    }

    public GetQuestionDto GetRandomQuestion()
    {
        List<Question> questions = _questionRepository.GetAllQuestions();

        if (questions == null || questions.Count == 0)
        {
            return null;
        }

        Random random = new Random();
        int randomIndex = random.Next(0, questions.Count);
        var q = questions[randomIndex];

        return new GetQuestionDto
        {
            QuestionId = q.QuestionId,
            Text = q.Text
        };
    }

    public bool IsCorrect(string answer)
    {
        List<Question> questions = _questionRepository.GetAllQuestions();

        for(int i = 0;i < questions.Count; i++)
        {
            if (questions[i].Answer == answer)
            {
                return true;
            }
        }
        return false;
    }

    public (bool,string) SolveQuestion(SolveQuestionDto request)
    {
        List<Question> questions = _questionRepository.GetAllQuestions();

        for(int i = 0;i < questions.Count;i++)
        {
            if (questions[i].QuestionId == request.QuestionId 
                && IsCorrect(request.Answer) )
            {
                
                return (true, $"{request.Answer} is correcto");
            }    
        }
        
        return (false, $"{request.Answer} incorrecto");
    }

   
}

    