using CleanArchitecture.Application.Repositories;
using CleanArchitecture.Domain;
using CleanArchitecture.Domain.ValueObjects;
using CleanArchitecture.Infrastructure.Persistence;

namespace CleanArchitecture.Infrastructure.Repositories;

public class ItemRepository(AppDbContext context) : GenericRepository<Item, ItemId>(context), IItemRepository;