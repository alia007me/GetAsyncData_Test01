namespace GetAsyncData.Services
{
    public abstract class Service
    {
        public abstract Task<IEnumerable<(string FullName, string Principle)>> GetPeopleData(params string[] roles);
    }
}
