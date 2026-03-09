using TestProject.Api.DTOS;
using TestProject.Api.Entites;

namespace TestProject.Api.Service;

public interface IQuestionService
{
    public bool IsCorrect( string answer);
    public void AddQuestion(Question question);

    public (bool,string) SolveQuestion(SolveQuestionDto request);

    public GetQuestionDto GetRandomQuestion();

    public int GetCountOfQuestions();

}
