using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories;

public interface ICastRepository
{
 public Cast GetById(int id);
    
}