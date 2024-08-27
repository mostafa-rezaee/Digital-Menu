using Common.Query;

namespace DigiMenu.Query.Users.DTO
{
    public class UserFilterParams : BaseFilterParam
    {
        public string? Username { get; set; }
        public long? Id { get; set; }
    }
}
