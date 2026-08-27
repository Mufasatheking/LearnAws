using LearnAws.Dtos;

namespace LearnAws.Repositories;

public interface IPeopleRepository
{
    public Task<Person?> FindByIdAsync(int id);
    
    public Task<IEnumerable<Person>> FindAllAsync();
}