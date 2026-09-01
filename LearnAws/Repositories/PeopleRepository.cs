using LearnAws.Dtos;

namespace LearnAws.Repositories;

public class PeopleRepository : IPeopleRepository
{
    private static readonly List<Person> People =
    [
        new Person { Id = 1, Name = "Alice", Age = 34 },
        new Person { Id = 2, Name = "Bilal", Age = 28 },
        new Person { Id = 3, Name = "Carmen", Age = 45 },
        new Person { Id = 4, Name = "Dev", Age = 52 },
        new Person { Id = 5, Name = "Ethan", Age = 22 },
    ];

    public Task<Person?> FindByIdAsync(int id)
    {
        return Task.FromResult(People.FirstOrDefault(p => p.Id == id));
    }

    public Task<IEnumerable<Person>> FindAllAsync()
    {
        return Task.FromResult<IEnumerable<Person>>(People);
    }
}
