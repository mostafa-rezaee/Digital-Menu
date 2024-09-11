using Common.Query;
using Dapper;
using DigiMenu.Infrastracture.Persistent.Dapper;
using DigiMenu.Query.Users.DTO;

namespace DigiMenu.Query.Users.UserTokens.GetByJwtToken
{
    public class GetUserTokenByJwtTokenQueryHandler : IQueryHandler<GetUserTokenByJwtTokenQuery, UserTokenDto?>
    {
        private readonly DapperContext _dapperContext;

        public GetUserTokenByJwtTokenQueryHandler(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<UserTokenDto?> Handle(GetUserTokenByJwtTokenQuery request, CancellationToken cancellationToken)
        {
            using var connection = _dapperContext.CreateConnection();
            var query = $"SELECT TOP(1) * FROM {_dapperContext.Tokens}  where HashJwtToken = @hashedJwtToken";
            return await connection.QueryFirstOrDefaultAsync<UserTokenDto?>(query, new { hashedJwtToken = request.hashedJwtToken });
        }
    }
}
