
using System.Security.Cryptography.X509Certificates;
using AutoMapper;

namespace OnlineStore.Application.Features.Accounts.Queries;
public record GetUserInfoRequest : IRequest<UserDto>;
public class GetUserInfoRequestHandler : IRequestHandler<GetUserInfoRequest, UserDto>
{
    private readonly IUserService _userService;
    private readonly IOnlineStoreRepository<Account> _accountRepository;
    private readonly IMapper _mapper;

    public GetUserInfoRequestHandler(IUserService userService, IOnlineStoreRepository<Account> accountRepository, IMapper mapper)
    {
        _userService = userService;
        _accountRepository = accountRepository;
        _mapper = mapper;
    }

    public async Task<UserDto> Handle(GetUserInfoRequest request, CancellationToken cancellationToken)
    {
        var data = await _accountRepository.GetItemAsync(new AccountSpecification(_userService.UserName));
        return _mapper.Map<UserDto>(data?.Customer);
    }
}