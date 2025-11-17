using MediatR;

namespace CQRSMediatrDemo.Commands.UpdateStudent
{
    public record UpdateStudentCommand(int Id, string FirstName, string LastName, string Email, DateTime DateOfBirth, string? Course) : IRequest<bool>;
}
