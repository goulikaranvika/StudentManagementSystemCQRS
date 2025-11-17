using MediatR;

namespace CQRSMediatrDemo.Commands.CreateStudent
{
    public record CreateStudentCommand(string FirstName, string LastName, string Email, DateTime DateOfBirth, string? Course) : IRequest<int>;
}
