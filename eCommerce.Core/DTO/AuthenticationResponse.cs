

namespace eCommerce.Core.DTO;

public record AuthenticationResponse
(
Guid UserID,
String? Email,
String? PersonName,
String? Gender,
    String? Token,
    bool Success
)
{
    public AuthenticationResponse() : 
        this(default, default, default, default, default, default) { }
}

