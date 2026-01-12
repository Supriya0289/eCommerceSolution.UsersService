

namespace eCommerce.Core.DTO;

public record RegisterRequest(
    String? Email,
    String? Password,
    String? PersonName,
    GenderOptions Gender);
   

