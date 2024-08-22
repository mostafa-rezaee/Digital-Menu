using Common.Domain;
using DigiMenu.Domain.RoleAgg.Enums;

namespace DigiMenu.Domain.RoleAgg
{
    public class RolePermission : BaseEntity
    {
        public RolePermission(Permissions permission)
        {
            Permission = permission;
        }

        public long RoleId { get; internal set; }
        public Permissions Permission { get; private set; }

    }
}
