using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Polly;

namespace Data
{
    public static partial class DapperHelpers
    {

        private static Task<IEnumerable<T>> QueryAsync<T>(this IDbConnection cnn,
            string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null, IAsyncPolicy policy = null, CancellationToken cancellationToken = default)
        {
            if (policy == null || transaction != null)
            {
                var def = new CommandDefinition(sql, param, transaction, commandTimeout, CommandType.StoredProcedure,
                    cancellationToken: cancellationToken);
                return cnn.QueryAsync<T>(def);
            }

            var context = new Context();
            context["sql"] = sql;

            return policy.ExecuteAsync((c, t) =>
            {
                var def = new CommandDefinition(sql, param, transaction, commandTimeout, CommandType.StoredProcedure,
                    cancellationToken: t);
                return cnn.QueryAsync<T>(def);
            }, context, cancellationToken);
        }

        private static Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TReturn>(this IDbConnection cnn,
            string sql, Func<TFirst, TSecond, TReturn> map, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null, IAsyncPolicy policy = null, string splitOn = "Id", CancellationToken cancellationToken = default)
        {
            if (policy == null || transaction != null)
            {
                var def = new CommandDefinition(sql, param, transaction, commandTimeout, CommandType.StoredProcedure,
                    cancellationToken: cancellationToken);
                return cnn.QueryAsync<TFirst, TSecond, TReturn>(def, map, splitOn);
            }

            var context = new Context
            {
                ["sql"] = sql
            };

            return policy.ExecuteAsync((c, t) =>
            {
                var def = new CommandDefinition(sql, param, transaction, commandTimeout, CommandType.StoredProcedure,
                    cancellationToken: t);
                return cnn.QueryAsync<TFirst, TSecond, TReturn>(def, map, splitOn);
            }, context, cancellationToken);
        }

        private static Task<T> QueryFirstOrDefaultAsync<T>(this IDbConnection cnn,
            string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null, IAsyncPolicy policy = null, CancellationToken cancellationToken = default)
        {
            if (policy == null || transaction != null)
            {
                var def = new CommandDefinition(sql, param, transaction, commandTimeout, CommandType.StoredProcedure,
                    cancellationToken: cancellationToken);
                return cnn.QueryFirstOrDefaultAsync<T>(def);
            }

            var context = new Context();
            context["sql"] = sql;

            return policy.ExecuteAsync((c, t) =>
            {
                var def = new CommandDefinition(sql, param, transaction, commandTimeout, CommandType.StoredProcedure,
                    cancellationToken: t);
                return cnn.QueryFirstOrDefaultAsync<T>(def);
            }, context, cancellationToken);
        }

        private static Task<T> ExecuteScalarAsync<T>(this IDbConnection cnn,
            string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null, IAsyncPolicy policy = null, CancellationToken cancellationToken = default)
        {
            if (policy == null || transaction != null)
            {
                var def = new CommandDefinition(sql, param, transaction, commandTimeout, CommandType.StoredProcedure,
                    cancellationToken: cancellationToken);
                return cnn.ExecuteScalarAsync<T>(def);
            }

            var context = new Context();
            context["sql"] = sql;

            return policy.ExecuteAsync((c, t) =>
            {
                var def = new CommandDefinition(sql, param, transaction, commandTimeout, CommandType.StoredProcedure,
                    cancellationToken: t);
                return cnn.ExecuteScalarAsync<T>(def);
            }, context, cancellationToken);
        }

        private static Task<int> ExecuteAsync(this IDbConnection cnn,
            string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null, IAsyncPolicy policy = null, CancellationToken cancellationToken = default)
        {
            if (policy == null || transaction != null)
            {
                var def = new CommandDefinition(sql, param, transaction, commandTimeout, CommandType.StoredProcedure,
                    cancellationToken: cancellationToken);
                return cnn.ExecuteAsync(def);
            }

            var context = new Context();
            context["sql"] = sql;

            return policy.ExecuteAsync((c, t) =>
            {
                var def = new CommandDefinition(sql, param, transaction, commandTimeout, CommandType.StoredProcedure,
                    cancellationToken: t);
                return cnn.ExecuteAsync(def);
            }, context, cancellationToken);
        }
    }
}
