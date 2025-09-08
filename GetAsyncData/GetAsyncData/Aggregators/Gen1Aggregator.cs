namespace GetAsyncData.Aggregators
{
    public class Gen1Aggregator : GetAggregator
    {
        protected override Task<IEnumerable<string>> FindFullNames(params string[] roles)
        {
            throw new NotImplementedException();
        }

        protected override Task<IEnumerable<(string FullName, string Principle)>> FindPersonPrinciples(params string[] fullNames)
        {
            throw new NotImplementedException();
        }
    }
}
