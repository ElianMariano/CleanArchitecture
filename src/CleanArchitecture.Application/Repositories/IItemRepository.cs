using CleanArchitecture.Contracts;
using CleanArchitecture.Domain;
using CleanArchitecture.Domain.ValueObjects;

namespace CleanArchitecture.Application.Repositories;

public interface IItemRepository : IGenericRepository<Item, ItemId>;