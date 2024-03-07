using HouseBrokerApp.Domain.Models;

namespace HouseBrokerApp.Infrastructure.Services
{
    public interface IJwtTokenService
    {
        string GenerateJwtToken(LoginVM user);
    }
}