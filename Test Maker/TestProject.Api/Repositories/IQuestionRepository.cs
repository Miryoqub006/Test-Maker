using TestProject.Api.Entites;

namespace TestProject.Api.Repositories;

public interface IQuestionRepository
{
    public List<Question> GetAllQuestions();

    public void SaveAllQuestion(List<Question> questions);

    


}
