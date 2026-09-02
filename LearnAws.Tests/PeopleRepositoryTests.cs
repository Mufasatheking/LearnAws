using LearnAws.Repositories;

namespace LearnAws.Tests;

public class PeopleRepositoryTests
{
    private readonly PeopleRepository _repository = new();

    [Fact]
    public async Task FindByIdAsync_returns_person_when_id_exists()
    {
        var person = await _repository.FindByIdAsync(1);

        Assert.NotNull(person);
        Assert.Equal("Alice", person.Name);
    }

    [Fact]
    public async Task FindByIdAsync_returns_null_when_id_unknown()
    {
        var person = await _repository.FindByIdAsync(999);

        Assert.Null(person);
    }

    [Fact]
    public async Task FindAllAsync_returns_all_people()
    {
        var people = await _repository.FindAllAsync();

        Assert.Equal(5, people.Count());
    }
}
