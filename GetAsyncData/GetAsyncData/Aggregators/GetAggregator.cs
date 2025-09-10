namespace GetAsyncData.Aggregators
{
    public abstract class GetAggregator
    {
        public static Dictionary<string, string> PeopleData = new();
        public static Dictionary<string, string> RoleResponsibilities = new()
        {
            { "TeamLead", "Guides and mentors the development team, facilitates communication, and is responsible for the team's overall technical output and well-being." },
            { "ScrumMaster", "Facilitates Scrum ceremonies, removes impediments for the team, and helps the team adhere to Agile principles and practices." },
            { "Developer", "Writes, tests, and maintains high-quality code. Collaborates with the team to design and implement new features." },
            { "DevOps", "Manages the software development lifecycle, including CI/CD pipelines, infrastructure automation, and ensures system reliability and scalability." },
            { "ProductOwner", "Defines product vision, manages and prioritizes the product backlog, and represents the stakeholders to ensure the team is building the right product." }
        };

        static GetAggregator()
        {
            PopulateData();
        }

        private static void PopulateData()
        {
            string[] firstNames = {
            "Liam", "Olivia", "Noah", "Emma", "Oliver", "Ava", "Elijah", "Charlotte", "William", "Sophia",
            "James", "Amelia", "Benjamin", "Isabella", "Lucas", "Mia", "Henry", "Evelyn", "Alexander", "Harper",
            "Michael", "Camila", "Daniel", "Gianna", "Leo", "Abigail", "Jack", "Luna", "Ryan", "Ella",
            "Joseph", "Elizabeth", "David", "Sofia", "Gabriel", "Emily", "Samuel", "Avery", "John", "Mila",
            "Luke", "Scarlett", "Anthony", "Eleanor", "Caleb", "Madison", "Dylan", "Layla", "Wyatt", "Penelope",
            "Isaac", "Aria", "Grayson", "Chloe", "Levi", "Grace", "Julian", "Ellie", "Mateo", "Nora", "Ezra", "Hazel",
            "Aaron", "Zoey", "Charles", "Riley", "Owen", "Victoria", "Josiah", "Lily", "Hudson", "Aurora"};

            string[] lastNames = {
            "Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Miller", "Davis", "Rodriguez", "Martinez",
            "Hernandez", "Lopez", "Gonzalez", "Wilson", "Anderson", "Thomas", "Taylor", "Moore", "Jackson", "Martin",
            "Lee", "Perez", "Thompson", "White", "Harris", "Sanchez", "Clark", "Ramirez", "Lewis", "Robinson",
            "Walker", "Young", "Allen", "King", "Wright", "Scott", "Torres", "Nguyen", "Hill", "Flores",
            "Green", "Adams", "Nelson", "Baker", "Hall", "Rivera", "Campbell", "Mitchell", "Carter", "Roberts"};

            string[] roles = { "TeamLead", "ScrumMaster", "Developer", "DevOps", "ProductOwner" };

            Random random = new Random();
            HashSet<string> usedNames = new HashSet<string> { };

            while (PeopleData.Count < 301) // 300 new items + 1 initial item
            {
                string firstName = firstNames[random.Next(firstNames.Length)];
                string lastName = lastNames[random.Next(lastNames.Length)];
                string fullName = $"{firstName} {lastName}";

                if (!usedNames.Contains(fullName))
                {
                    usedNames.Add(fullName);
                    string role = roles[random.Next(roles.Length)];
                    PeopleData.Add(fullName, role);
                }
            }
        }

        public async Task<IEnumerable<string>> GetFullNamesByRoles(string role)
        {
            var delay = Task.Delay(1000);

            var result = FindFullNames(role);

            await delay;

            return await result;
        }

        abstract protected Task<IEnumerable<string>> FindFullNames(string roles);

        public async Task<(string FullName, string Principle)> GetPersonPrinciples(string fullName)
        {
            var delay = Task.Delay(1000);

            var result = FindPersonPrinciples(fullName);

            await delay;

            return await result;
        }

        abstract protected Task<(string FullName, string Principle)> FindPersonPrinciples(string fullName);
    }
}
