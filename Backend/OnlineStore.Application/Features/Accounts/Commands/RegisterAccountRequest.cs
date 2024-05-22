using AutoMapper;
using OnlineStore.Domain.Commons.Interface;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Application.Features.Accounts.Commands;
public record RegisterAccountRequest(AccountDto Account) : IRequest<ItemResponse<bool>>;

public class RegisterAccountRequestHandler : IRequestHandler<RegisterAccountRequest, ItemResponse<bool>>
{
    private readonly IOnlineStoreRepository<Account> _accountRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterAccountRequestHandler(IOnlineStoreRepository<Account> accountRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _accountRepository = accountRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<ItemResponse<bool>> Handle(RegisterAccountRequest request, CancellationToken cancellationToken)
    {
        var account = _mapper.Map<Account>(request.Account);
        account.Customer = _mapper.Map<Customer>(request.Account);
        await _accountRepository.InsertAsync(account);
        await _unitOfWork.CommitChangesAsync();
        return new(true);
    }
}