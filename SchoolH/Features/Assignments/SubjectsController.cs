using Microsoft.AspNetCore.Mvc;
using SchoolH.Features.Assignments.Models;
using SchoolH.Features.Assignments.Views;

namespace SchoolH.Features.Assignments;

[ApiController]
[Route("subjects")]
public class SubjectsController
{
    private static List<SubjectModel> _mockDb = new List<SubjectModel>();

    public SubjectsController()
    {
    }

    [HttpPost]
    public SubjectResponse Add(SubjectRequest request)
    {
        var subject = new SubjectModel
        {
            Id = Guid.NewGuid().ToString(),
            Created = DateTime.UtcNow,
            Updated = DateTime.UtcNow,
            Name = request.Name,
            ProfessorMail = request.ProfessorMail,
            Grades = request.Grades
        };

        _mockDb.Add(subject);

        return new SubjectResponse
        {
            Id = subject.Id,
            Name = subject.Name,
            ProfessorMail = request.ProfessorMail,
            Grades = request.Grades
        };
    }

    [HttpGet]
    public IEnumerable<SubjectResponse> Get()
    {
        return _mockDb.Select(
            subject => new SubjectResponse
            {
                Id = subject.Id,
                Name = subject.Name,
                ProfessorMail = subject.ProfessorMail,
                Grades = subject.Grades
            }).ToList();
    }

    [HttpGet("{id}")]
    public SubjectResponse Get([FromRoute] string id)
    {
        var subject = _mockDb.FirstOrDefault(x => x.Id == id);

        if (subject is null)
        {
            return null;
        }

        return new SubjectResponse
        {
            Id = subject.Id,
            Name = subject.Name,
            ProfessorMail = subject.ProfessorMail,
            Grades = subject.Grades
        };
    }

    [HttpDelete("{id}")]
    public void Delete([FromRoute] string id)
    {
        var subject = _mockDb.FirstOrDefault(x => x.Id == id);

        if (subject is null)
        {
            return;
        }

        _mockDb.Remove(subject);
    }

    [HttpPatch("{id}")]
    public void Patch([FromRoute] string id, SubjectRequest request)
    {
        var subject = _mockDb.FirstOrDefault(x => x.Id == id);
        
        if (subject is null)
        {
            return;
        }
        
        subject.Updated = DateTime.UtcNow;
        subject.Grades = request.Grades;
        subject.Name = request.Name;
        subject.ProfessorMail = request.ProfessorMail;
    }
}