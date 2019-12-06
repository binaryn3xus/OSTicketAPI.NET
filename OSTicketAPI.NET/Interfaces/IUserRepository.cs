using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using OSTicketAPI.NET.DTO;

namespace OSTicketAPI.NET.Interfaces
{
    public interface IUserRepository<T, TExpression>
    {
        Task<IEnumerable<T>> GetUsers(Expression<Func<TExpression, bool>> expression = null);
        Task<T> GetUserById(int id);
        Task<T> GetUserByEmail(string email);
        Task<T> GetUserByUsername(string username);
        Task<T> CreateRegisteredUser(UserCreationOptions options);
    }
}
