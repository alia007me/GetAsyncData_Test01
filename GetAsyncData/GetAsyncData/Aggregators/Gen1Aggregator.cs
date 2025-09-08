
namespace GetAsyncData.Aggregators
{
    public class Gen1Aggregator : GetAggregator
    {
        protected override Task<IEnumerable<string>> FindFullNames(string roles)
        {
            throw new NotImplementedException();
        }

        protected override Task<(string FullName, string Principle)> FindPersonPrinciples(string fullName)
        {
            throw new NotImplementedException();
        }
    }
}
