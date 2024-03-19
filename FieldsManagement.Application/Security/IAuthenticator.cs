using FieldsManagement.Application.DTO;

namespace FieldsManagement.Application.Security;

public interface IAuthenticator
{
    JwtDto CreateToken(Guid userId, string role);
}