namespace Snow.Framework.AspNetCore.ServiceExtensions
{
    /// <summary>
    /// 跨域服务扩展
    /// </summary>
    public static class CorsServiceExtensions
    {
        private static readonly string PolicyName = "DefaultPolicy";

        /// <summary>
        ///  添加跨域
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddApiCors(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(PolicyName, policy =>
                {
                    policy.SetIsOriginAllowed(_ => true).AllowAnyMethod().AllowAnyHeader().AllowCredentials();
                });
            });

            return services;
        }

        /// <summary>
        /// 使用跨域
        /// </summary>
        /// <param name="app">应用程序建造者</param>
        /// <returns></returns>
        public static IApplicationBuilder UseApiCors(this IApplicationBuilder app)
        {
            app.UseCors(PolicyName);
            return app;
        }
    }
}
