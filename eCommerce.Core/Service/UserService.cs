

using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContrast;
using eCommerce.Core.ServiceContracts;

namespace eCommerce.Core.Service;

internal class UserService : IUserService
{
    private readonly IUsersRepository _usersRepository;
    private readonly IMapper _mapper;

    public UserService(IUsersRepository usersRepository, IMapper mapper)
    {
        _usersRepository = usersRepository; 
        _mapper = mapper;   
    }
    public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
    {
        ApplicationUser? user = await _usersRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);

        if (user == null)
        {
            return null;
        }
       // return new AuthenticationResponse
        //    (user.UserID,user.Email,user.PersonName,user.Gender,"token", Success: true);
        return _mapper.Map<AuthenticationResponse>(user) with { Success = true ,Token = "token"};
    }

    public async Task<AuthenticationResponse?> Register(RegisterRequest registerRequest)
    {
        //ApplicationUser user = new ApplicationUser()
        //{

        //    PersonName = registerRequest.PersonName,
        //    Email = registerRequest.Email,
        //    Password = registerRequest.Password,
        //    Gender = registerRequest.Gender.ToString(),
        //};
        ApplicationUser user = _mapper.Map<ApplicationUser>(registerRequest);
        ApplicationUser? registeruser = await _usersRepository.AddUser(user);
        if (registeruser == null)
        {
            return null;
        }
        //return new AuthenticationResponse(registeruser.UserID
        //    , registeruser.Email,
        //    registeruser.PersonName,

        //    registeruser.Gender, "token", Success: true);

        return _mapper.Map<AuthenticationResponse>(registeruser) with { Success = true , Token = "token"};
    }
}

