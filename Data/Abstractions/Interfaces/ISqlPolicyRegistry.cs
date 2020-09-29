using Polly;

namespace Data.Abstractions.Interfaces
{
    public interface ISqlPolicyRegistry
    {
        IAsyncPolicy GetStandardRetryPolicy();

        IAsyncPolicy GetStandardSaveQueryRetryPolicy();

        IAsyncPolicy GetOpenConnectionRetryPolicy();
    }
}
