using Common.Application;
using DigiMenu.Domain.RoleAgg;
using DigiMenu.Domain.RoleAgg.Repositories;

namespace DigiMenu.Application.Roles.Edit
{
    public class EditRoleCommandHandler : IBaseCommandHandler<EditRoleCommand>
    {
        private readonly IRoleRepository _roleRepository;

        public EditRoleCommandHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<OperationResult> Handle(EditRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await _roleRepository.GetTrackingAsync(request.Id);
            if (role == null) return OperationResult.NotFound();
            role.Edit(request.title);

            var permissionList = new List<RolePermission>();
            request.permissions.ForEach(x =>
                permissionList.Add(new RolePermission(x))
            );
            role.SetPermissions(permissionList);
            await _roleRepository.SaveAsync();

            return OperationResult.Success();
        }
    }
}
