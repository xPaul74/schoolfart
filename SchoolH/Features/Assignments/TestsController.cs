using Microsoft.AspNetCore.Mvc;
using SchoolH.Features.Assignments.Models;
using SchoolH.Features.Assignments.Views;

namespace SchoolH.Features.Assignments;

[ApiController]
[Route("tests")]
public class TestsController
{
    private static List<TestModel> _mockDb = new List<TestModel>();

    public TestsController() { }

    [HttpPost]
    public TestResponse Add(TestRequest request)
    {
        var test = new TestModel
        {
            Id = Guid.NewGuid().ToString(),
            Created = DateTime.UtcNow,
            Updated = DateTime.UtcNow,
            Subject = request.Subject,
            TestDate = request.TestDate
        };
        _mockDb.Add(test);

        return new TestResponse
        {
            Id = test.Id,
            Subject = test.Subject,
            TestDate = test.TestDate
        };

    }
    
    [HttpGet]
    public IEnumerable<TestResponse> Get()
    {
        return _mockDb.Select(
            test => new TestResponse()
            {
                Id = test.Id,
                Subject = test.Subject,
                TestDate = test.TestDate,
            }).ToList();
    }

    [HttpGet("{id}")]
    public TestResponse Get([FromRoute] string id)
    {
        var test = _mockDb.FirstOrDefault(x => x.Id == id);
        if (test is null)
        {
            return null;
        }

        return new TestResponse()
        {
            Id = test.Id,
            Subject = test.Subject,
            TestDate = test.TestDate
        };
    }

    [HttpDelete("{id}")]
    public void Delete([FromRoute] string id)
    {
        var test = _mockDb.FirstOrDefault(x => x.Id == id);
        if (test is null)
        {
            return;
        }

        _mockDb.Remove(test);
    }

    [HttpPatch("{id}")]
    public void Patch([FromRoute] string id, TestRequest request)
    {
        var test = _mockDb.FirstOrDefault(x => x.Id == id);
        if (test is null)
        {
            return;
        }
        
        test.Updated = DateTime.UtcNow;
        test.Subject = request.Subject;
        test.TestDate = request.TestDate;
    }
}