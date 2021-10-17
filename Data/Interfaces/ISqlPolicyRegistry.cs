using Polly;

namespace Data.Interfaces
{
    public interface ISqlPolicyRegistry
    {
        IAsyncPolicy GetStandardRetryPolicy();

        IAsyncPolicy GetStandardSaveQueryRetryPolicy();

        IAsyncPolicy GetOpenConnectionRetryPolicy();
    }
}
