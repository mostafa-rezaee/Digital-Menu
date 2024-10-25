using Common.Query;
using DigiMenu.Infrastracture.Persistent.EF;
using DigiMenu.Query.PageSettings.DTO;
using Microsoft.EntityFrameworkCore;

namespace DigiMenu.Query.PageSettings.Get
{
    internal class GetPageSettingQueryHandler : IQueryHandler<GetPageSettingQuery, PageSettingDto?>
    {
        private readonly DigiMenuContext _context;

        public GetPageSettingQueryHandler(DigiMenuContext context)
        {
            _context = context;
        }

        public async Task<PageSettingDto?> Handle(GetPageSettingQuery request, CancellationToken cancellationToken)
        {
            var model = await _context.PageSettings.FirstOrDefaultAsync(cancellationToken);
            return model.Map();
        }
    }
}
