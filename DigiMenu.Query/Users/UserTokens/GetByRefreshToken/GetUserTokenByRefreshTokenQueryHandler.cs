using Common.Query;
using Dapper;
using DigiMenu.Infrastracture.Persistent.Dapper;
using DigiMenu.Query.Users.DTO;

namespace DigiMenu.Query.Users.UserTokens.GetByRefreshToken
{
    public class GetUserTokenByRefreshTokenQueryHandler : IQueryHandler<GetUserTokenByRefreshTokenQuery, UserTokenDto?>
    {
        private readonly DapperContext _dapperContext;

        public GetUserTokenByRefreshTokenQueryHandler(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<UserTokenDto?> Handle(GetUserTokenByRefreshTokenQuery request, CancellationToken cancellationToken)
        {
            using var connection = _dapperContext.CreateConnection();
            var query = $"SELECT TOP(1) * FROM {_dapperContext.Tokens}  where HashRefreshToken = @hashedRefreshToken";
            return await connection.QueryFirstOrDefaultAsync<UserTokenDto?>(query, new { request.hashedRefreshToken });
        }
    }
}
