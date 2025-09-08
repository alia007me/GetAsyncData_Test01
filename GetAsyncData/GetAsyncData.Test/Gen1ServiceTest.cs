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
            var roles = new string[] { "Developer", "ProductOwner" };

            // Act
            timer.Start();

            var people = await gen1Service.GetPeopleData();

            timer.Stop();

            // Assert
            Assert.True(timer.ElapsedMilliseconds <= 10000);
            var peopleInRoles = Gen1Aggregator.PeopleData.Where(c => roles.Contains(c.Value));
            var excpectedPeople = peopleInRoles.Join(Gen1Aggregator.RoleResponsibilities,
                                                     c => c.Value,
                                                     c => c.Key,
                                                     (left, right) =>
                                                     {
                                                         return (FullName:left.Key,Principle: right.Value);
                                                     });
            foreach (var excpectedPerson in excpectedPeople)
            {
                Assert.NotNull(people);

                var computedPeople = people.Where(c => c.FullName == excpectedPerson.FullName);

                Assert.NotEmpty(computedPeople);

                foreach (var computedPerson in computedPeople)
                {
                    Assert.True(computedPerson.Principle == excpectedPerson.Principle);
                }
            }
        }
    }
}
