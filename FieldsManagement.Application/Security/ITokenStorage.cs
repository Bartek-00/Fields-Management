using FieldsManagement.Application.DTO;

namespace FieldsManagement.Application.Security;

public interface ITokenStorage
{
    void Set(JwtDto jwt);

    JwtDto Get();
}