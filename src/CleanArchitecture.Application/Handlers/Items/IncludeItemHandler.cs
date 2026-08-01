using CleanArchitecture.Application.Handlers.Items.Commands.Create;
using CleanArchitecture.Application.Handlers.Items.Commands.Delete;
using CleanArchitecture.Application.Handlers.Items.Commands.Update;
using CleanArchitecture.Application.Handlers.Items.Queries.GetById;
using CleanArchitecture.Application.Handlers.Items.Queries.GetPaged;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Application.Handlers.Items;

public static class IncludeItemHandlers
{
    public static void Include(IServiceCollection builder)
    {
        builder.AddScoped<CreateItemHandler>();
        builder.AddScoped<UpdateItemHandler>();
        builder.AddScoped<DeleteItemHandler>();
        builder.AddScoped<GetItemByIdHandler>();
        builder.AddScoped<GetItemsPagedHandler>();
    }
}