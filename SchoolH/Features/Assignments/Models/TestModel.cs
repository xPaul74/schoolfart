using SchoolH.Base;

namespace SchoolH.Features.Assignments.Models;

public class TestModel : Model
{
    public string Subject { get; set; }
    
    public DateTime TestDate { get; set; }
}