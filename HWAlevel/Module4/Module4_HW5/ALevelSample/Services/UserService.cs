using System.Threading.Tasks;
using ALevelSample.Data;
using ALevelSample.Models;
using ALevelSample.Repositories;
using ALevelSample.Repositories.Abstractions;
using ALevelSample.Services.Abstractions;
using Microsoft.Extensions.Logging;

namespace ALevelSample.Services;

public class UserService : BaseDataService<ApplicationDbContext>, IUserService
{
    private readonly IUpdateRepository _updateRepository;
    private readonly IUserRepository _userRepository;
    private readonly INotificationService _notificationService;
    private readonly ILogger<UserService> _loggerService;

    public UserService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        IUserRepository userRepository,
        INotificationService notificationService,
        IUpdateRepository updateRepository,
        ILogger<UserService> loggerService)
        : base(dbContextWrapper, logger)
    {
        _updateRepository = updateRepository;
        _userRepository = userRepository;
        _notificationService = notificationService;
        _loggerService = loggerService;
    }

    public async Task<string> AddUser(string firstName, string lastName)
    {
       return await ExecuteSafeAsync(async () =>
        {
            var id = await _userRepository.AddUserAsync(firstName, lastName);
            _loggerService.LogInformation($"Created user with Id = {id}");
            var notifyMassage = "registration was successful";
            var notifyTo = "user@gmail.com";
            _notificationService.Notify(NotifyType.Email, notifyMassage, notifyTo);
            return id;
        });
    }

    public async Task<string> DeleteUser(string idUser)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var id = await _userRepository.DeleteUserAsync(idUser);
            _loggerService.LogInformation($"Deleted user with Id = {id}");
            var notifyMassage = "registration was successful";
            var notifyTo = "user@gmail.com";
            _notificationService.Notify(NotifyType.Email, notifyMassage, notifyTo);
            return "Succassfully deleted";
        });
    }

    public async Task<string> UpdateUser(string idUser, string lastName = "", string firstName = "")
    {
        return await ExecuteSafeAsync(async () =>
        {
            await _updateRepository.UpdateAsync<User>(userId: idUser, lastName: lastName, firstName: firstName);
            _loggerService.LogInformation($"Updated user with Id = {idUser}");
            var notifyMassage = "registration was successful";
            var notifyTo = "user@gmail.com";
            _notificationService.Notify(NotifyType.Email, notifyMassage, notifyTo);
            return idUser;
        });
    }

    public async Task<User> GetUser(string id)
    {
        var user = await _userRepository.GetUserAsync(id);

        if (user == null)
        {
            _loggerService.LogWarning($"Not founded user with Id = {id}");
            return null!;
        }

        return new User()
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            FullName = $"{user.FirstName} {user.LastName}"
        };
    }
}