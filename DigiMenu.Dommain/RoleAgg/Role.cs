using Common.Domain;
using Common.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Domain.RoleAgg
{
    public class Role : AggregateRoot
    {
        private Role() { }
        public Role(string title, List<RolePermission> rolePermissions)
        {
            NullOrEmptyException.CheckNotEmpty(title, nameof(title));
            Title = title;
            RolePermissions = rolePermissions;
        }

        public Role(string title)
        {
            NullOrEmptyException.CheckNotEmpty(title, nameof(title));
            Title = title;
            RolePermissions = new List<RolePermission>();
        }

        public string Title { get; private set; }
        public List<RolePermission> RolePermissions { get; private set; }

        #region Methods

        public void Edit(string title)
        {
            NullOrEmptyException.CheckNotEmpty(title, nameof(title));
            Title = title;
        }

        public void SetPermissions(List<RolePermission> rolePermissions)
        {
            RolePermissions = rolePermissions;
        }


        #endregion

    }
}
