using Microsoft.AspNetCore.Mvc;
using TestProject.Api.Entites;
using TestProject.Api.Repositories;
using TestProject.Api.Service;
using TestProject.Api.DTOS;

namespace TestProject.Api.Controllers;
[ApiController]
[Route("question api")]
public class QuestionController : Controller
{
    private readonly IQuestionService _question;
    private readonly IQuestionRepository _questionRepository;
    
    public QuestionController()
    {
        _question = new QuestionService();
        _questionRepository = new QuestionsRepositories();
    }

    [HttpGet("get question")]
    public GetQuestionDto GetQuestion()
    {
        return _question.GetRandomQuestion();
    }
    [HttpPost("set question")]

    public void PostQuestion(Question question)
    {
        _question.AddQuestion(question);
    }
    [HttpGet("get all questions data : admin")]

    public List<Question> GetAllQuestionsController()
    {
        return _questionRepository.GetAllQuestions();
    }
    [HttpPost("solve question")]

    public (bool, string) SolveQuestionController(SolveQuestionDto solveQuestionDto)
    {
        return _question.SolveQuestion(solveQuestionDto);


    }





    }





