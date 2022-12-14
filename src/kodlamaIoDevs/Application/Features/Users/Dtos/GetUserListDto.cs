using Core.Security.Entities;
using Core.Security.Enums;

namespace Application.Features.Users.Dtos;

public class GetUserListDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public bool Status { get; set; }
    public int SocialMediaId { get; set; }
    public string SocialMediaName { get; set; }
    public AuthenticatorType AuthenticatorType { get; set; }

}