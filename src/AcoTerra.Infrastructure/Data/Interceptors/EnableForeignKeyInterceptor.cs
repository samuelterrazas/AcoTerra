using System.Data.Common;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace AcoTerra.Infrastructure.Data.Interceptors;

internal sealed class EnableForeignKeyInterceptor : DbConnectionInterceptor
{
    public override async Task ConnectionOpenedAsync(
        DbConnection connection,
        ConnectionEndEventData eventData,
        CancellationToken cancellationToken = default
    )
    {
        await using DbCommand command = connection.CreateCommand();
        
        command.CommandText = "PRAGMA foreign_keys = ON;";
        await command.ExecuteNonQueryAsync(cancellationToken);
    }
}