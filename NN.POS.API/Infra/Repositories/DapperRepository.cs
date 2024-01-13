using Microsoft.Data.SqlClient;
using System.Data.Common;
using System.Data;
using System.Diagnostics;

namespace NN.POS.API.Infra.Repositories;

public abstract class DapperRepository<T>
{
    private readonly SqlClientFactory _factory;
    private readonly ILogger<T> _logger;

    // ReSharper disable once ConvertToPrimaryConstructor
    protected DapperRepository(ILogger<T> logger)
    {
        _factory = SqlClientFactory.Instance;
        _logger = logger;
    }

    public IDbConnection CreateDbConnection(string conStr)
    {
        var con = _factory.CreateConnection() ?? throw new Exception("cannot create db_connection");
        con.ConnectionString = conStr;
        return con;
    }

    public DbCommand CreateDbCommand(DbConnection connection, string? commandText = null, CommandType cmdType = CommandType.StoredProcedure)
    {
        var cmd = _factory.CreateCommand() ?? throw new Exception("cannot create db_command");
        cmd.Connection = connection;
        cmd.CommandType = cmdType;
        if (!string.IsNullOrWhiteSpace(commandText))
        {
            cmd.CommandText = commandText;
        }
        return cmd;
    }

    public async Task<TResult?> ExecuteCommandSingleQueryAsync<TResult>(DbConnection connection, DbCommand dbCommand, Func<IDataRecord, TResult> mapData, CancellationToken cancellationToken = default)
    {
        var sw = Stopwatch.StartNew();
        TResult? result = default;
        try
        {
            _logger.LogDebug("opening connection");
            await connection.OpenAsync(cancellationToken);
            _logger.LogDebug("connection opened, {TotalMilliseconds} ms", sw.Elapsed.TotalMilliseconds);
            _logger.LogDebug("executing");
            var reader = await dbCommand.ExecuteReaderAsync(cancellationToken);
            var once = false;
            if (reader.HasRows)
            {
                while (await reader.ReadAsync(cancellationToken) && !once)
                {
                    result = mapData(reader);
                    once = true;
                }
            }
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Error}", e.Message);
        }
        finally
        {
            await connection.CloseAsync();
            _logger.LogDebug("executed, {TotalMilliseconds} ms", sw.Elapsed.TotalMilliseconds);
        }

        return result;
    }

    public async Task<IList<TResult>> ExecuteCommandQueryAsync<TResult>(DbConnection connection, DbCommand dbCommand, Func<IDataRecord, TResult> mapData, CancellationToken cancellationToken = default)
    {
        var sw = Stopwatch.StartNew();
        var results = new List<TResult>();
        try
        {
            _logger.LogDebug("opening connection");
            await connection.OpenAsync(cancellationToken);
            _logger.LogDebug("connection opened, {TotalMilliseconds} ms", sw.Elapsed.TotalMilliseconds);
            _logger.LogDebug("executing");


            var reader = await dbCommand.ExecuteReaderAsync(cancellationToken);
            if (reader.HasRows)
            {
                while (await reader.ReadAsync(cancellationToken))
                {
                    results.Add(mapData(reader));
                }
            }
        }
        catch (Exception e)
        {
            _logger.LogError(e, "{Error}", e.Message);
        }
        finally
        {
            await connection.CloseAsync();
            _logger.LogDebug("executed, {TotalMilliseconds} ms", sw.Elapsed.TotalMilliseconds);
        }
        return results;
    }

    public async Task<int> ExecuteCommandNoneQueryAsync(DbConnection connection, DbCommand dbCommand, CancellationToken cancellationToken = default)
    {
        var sw = Stopwatch.StartNew();
        var result = 0;
        try
        {
            _logger.LogDebug("opening connection");
            await connection.OpenAsync(cancellationToken);
            _logger.LogDebug("connection opened, {TotalMilliseconds} ms", sw.Elapsed.TotalMilliseconds);
            _logger.LogDebug("executing");
            result = await dbCommand.ExecuteNonQueryAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "unexpected error on execute none query");
        }
        finally
        {
            await connection.CloseAsync();
            _logger.LogDebug("executed, {TotalMilliseconds} ms", sw.Elapsed.TotalMilliseconds);
        }
        return result;
    }

    public async Task<int> ExecuteCommandNoneQueryAsync<TEntity>(DbConnection connection, DbCommand dbCommand, IList<TEntity> entities, Action<TEntity, SqlCommand> mapDbCommand, CancellationToken cancellationToken = default)
    {
        var sw = Stopwatch.StartNew();
        var result = 0;
        try
        {
            _logger.LogDebug("opening connection");
            await connection.OpenAsync(cancellationToken);
            _logger.LogDebug("connection opened, {TotalMilliseconds} ms", sw.Elapsed.TotalMilliseconds);
            _logger.LogDebug("executing");
            foreach (var entity in entities)
            {
                try
                {
                    dbCommand.Parameters.Clear();
                    mapDbCommand(entity, (SqlCommand)dbCommand);
                    result += await dbCommand.ExecuteNonQueryAsync(cancellationToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "unexpected error on execute bulk none query");
                }
            }
        }
        finally
        {
            await connection.CloseAsync();
            _logger.LogDebug("executed, {TotalMilliseconds} ms", sw.Elapsed.TotalMilliseconds);
        }
        return result;
    }
}

