namespace Person.Routes
{
    public static class PersonRoute
    {
        public static void PersonRoutes(WebApplication app)
        {
            app.MapGet("person", () => "Olá pessoa");
        }
    }
}
