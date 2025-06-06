using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services;

public interface ICastService
{
    CastModel GetCastDetails(int id);
}