

using Dapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContrast;
using eCommerce.Infrastructure.DBContext;

namespace eCommerce.Infrastructure.Repositories;

internal class UserRepository : IUsersRepository
{
    private readonly DapperDbContext _dapperDbContext;

    public UserRepository(DapperDbContext dapperDbContext)
    {
        _dapperDbContext = dapperDbContext;
    }
    public async Task<ApplicationUser?> AddUser(ApplicationUser user)
    {
        user.UserID = Guid.NewGuid();

        string query = "INSERT INTO public.\"Users\"(\"UserID\",\"Email\" ,\"PersonName\", \"Gender\",\"Password\"  )VALUES(@UserID,@Email,@PersonName,@Gender,@Password)";

      int rowcountedaffect= await _dapperDbContext.DbConnection.ExecuteAsync(query,user);
        if (rowcountedaffect > 0)
        {
            return user;
        } 
        else { return null; }
    }
   
    public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
    {
        string query ="SELECT * FROM public.\"Users\" WHERE \"Email\" = @Email AND \"Password\"= @Password";
        var parameter = new { Email = email, Password = password };

        ApplicationUser? user = await _dapperDbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query,parameter);
        return user;
    }
}

