using Common.Domain;
using DigiMenu.Domain.RoleAgg.Enums;

namespace DigiMenu.Domain.RoleAgg
{
    public class RolePermission : BaseEntity
    {
        public long RoleId { get; private set; }
        public Permissions Permission { get; private set; }

    }
}
