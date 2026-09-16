using LearnAws.Api.Dtos;

namespace LearnAws.Api.Repositories;

public interface IPeopleRepository
{
    public Task<Person?> FindByIdAsync(int id);

    public Task<IEnumerable<Person>> FindAllAsync();
}