using CleanArchitecture.Application.Items.Commands.Create;
using CleanArchitecture.Application.Items.Commands.Delete;
using CleanArchitecture.Application.Items.Commands.Update;
using CleanArchitecture.Application.Items.Queries.GetById;
using CleanArchitecture.Application.Items.Queries.GetPaged;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Application.Items;

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