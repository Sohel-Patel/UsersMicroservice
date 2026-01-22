using Dapper;
using eCommers.Domain;
using eCommers.Domain.RepositoryContracts;
using eCommers.Infrastructure.DbContext;
namespace eCommers.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DapperDbContext _context;

        public UserRepository(DapperDbContext context)
        {
            _context = context;
        }

        public async Task<ApplicationUser?> AddUser(ApplicationUser user)
        {
            user.UserId = Guid.NewGuid();
            string query  = "INSERT INTO public.\"Users\"(\"UserId\",\"PersonName\",\"Gender\",\"Email\",\"Password\") VALUES(@UserId,@PersonName,@Gender,@Email,@Password)";
            int numberOfRows = await _context.DbConnection.ExecuteAsync(query,user);
            if (numberOfRows > 0)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? Email, string? Password)
        {
            string query = "SELECT * FROM puBlic.\"Users\" WHERE \"Email\"=@Email AND \"Password\"=@Password";
            var parameters = new {Email = Email,Password = Password};
            ApplicationUser? user = await _context.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query,parameters);
            return user;
        }
    }
}