using CQRSMediatrDemo.Models;
using MediatR;

namespace CQRSMediatrDemo.Requests.GetStudentById
{
    public record GetStudentByIdQuery(int Id) : IRequest<Student?>;
}
