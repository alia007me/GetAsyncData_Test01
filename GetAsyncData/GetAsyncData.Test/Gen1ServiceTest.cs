using GetAsyncData.Aggregators;
using GetAsyncData.Services;
using System.Diagnostics;
using Xunit;

namespace GetAsyncData.Test
{
    public class Gen1ServiceTest
    {
        [Fact]
        public async Task Get_People_And_Principles_Base_On_Their_Roles_Success_In_5_Sec()
        {
            // Arrage
            var gen1Service = new Gen1Service();
            var timer = new Stopwatch();
            var gen1Aggregator = new Gen1Aggregator();
            var roles = new string[] { "Developer", "ProductOwner" };

            timer.Start();

            var people = await gen1Service.GetPeopleData();

            timer.Stop();

            //Assert.
        }
    }
}
