using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using sub_schema_two;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ProductRepository>();

builder.Services
    .AddGraphQLServer()
    .AddApolloFederation()
    .AddQueryType<Query>()
    .AddType<User>()
    .RegisterService<ProductRepository>();

var app = builder.Build();
app.MapGraphQL();
app.Run("http://localhost:4002");