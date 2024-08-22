using Common.Application;
using DigiMenu.Domain.RoleAgg;
using DigiMenu.Domain.RoleAgg.Repositories;

namespace DigiMenu.Application.Roles.Create
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
            var permissionList = new List<RolePermission>();
            request.permissions.ForEach(x =>
                permissionList.Add(new RolePermission(x))
            );
            var role = new Role(request.title, permissionList);
            await _roleRepository.AddAsync(role);
            await _roleRepository.SaveAsync();

            return OperationResult.Success();
        }
    }
}
