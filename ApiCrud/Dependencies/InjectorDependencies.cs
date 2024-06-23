﻿namespace ApiCrud.Dependencies
{
    public static class InjectorDependencies
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            services.RegisterRepository();
            services.RegisterService();
        }
    }
}
