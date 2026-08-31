using Microsoft.EntityFrameworkCore;
using Person.Data;
using Person.Models;
namespace Person.Routes
{
    public static class PersonRoute
    {
        public static void PersonRoutes(this WebApplication app)
        {
            var route = app.MapGroup(prefix: "person");

            route.MapPost("", 
                async (PersonRequest req, PersonContext context) =>
            {
                var person = new PersonModel(req.name);

                await context.AddAsync(person);

                await context.SaveChangesAsync();
            });

            route.MapGet(pattern: "", async (PersonContext context) =>
            {
                List<PersonModel> people = await context.People.ToListAsync();

                return Results.Ok(people);
            });
                
        }
    }
}
