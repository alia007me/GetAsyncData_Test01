namespace GetAsyncData.Services
{
    public abstract class ServiceAggregator
    {
        public abstract Task<IEnumerable<(string FullName, string Principle)>> GetPeopleData(params string[] roles);
    }
}
