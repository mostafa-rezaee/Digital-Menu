using Common.Query;

namespace DigiMenu.Query.Users.DTO
{
    public class UserFilterData : BaseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string AvatarName { get; set; }
    }
}
