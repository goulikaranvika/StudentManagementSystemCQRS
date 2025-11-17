using CQRSMediatrDemo.Models;
using MediatR;
using System.Collections.Generic;

namespace CQRSMediatrDemo.Requests.GetAllStudents
{
    public record GetAllStudentsQuery() : IRequest<IEnumerable<Student>>;
}
