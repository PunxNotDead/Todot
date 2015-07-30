using System.Collections.Generic;
using Todo.Models;

namespace Todo.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> Users { get; }
    }
}
