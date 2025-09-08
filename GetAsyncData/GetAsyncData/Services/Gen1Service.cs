namespace GetAsyncData.Services
{
    public class Gen1Service : Service
    {
        public override Task<IEnumerable<(string FullName, string Principle)>> GetPeopleData(params string[] roles)
        {
            throw new NotImplementedException();
        }
    }
}
