using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Episodic
{
    public static class EpisodicBootstrapper
    {
        public static IServiceCollection AddEpisodicService(this IServiceCollection services, string storeBasePath)
        {
            services.AddTransient<IEpisodeProvider, EpisodeProvider>();
            services.AddTransient<IEpisodeTemplateProvider, EpisodeTemplateProvider>();
            services.AddTransient<IEpisodeFactory, EpisodeFactory>();
            services.AddTransient<IEpisodeComponentCollectionProvider, EpisodeComponentCollectionProvider>();
            services.AddTransient<IEpisodeStringTemplateParser, EpisodeStringTemplateParser>();
            services.AddScoped<IRandomPicker, RandomPicker>();

            services.AddTransient<IEpisodeComponentProvider, MacGuffinProvider>();
            services.AddTransient<IEpisodeComponentProvider, FactionProvider>();
            services.AddTransient(s=> s.GetServices<IEpisodeComponentProvider>().ToArray());
            services.AddSingleton(new JsonStoreOption(storeBasePath));
            services.AddTransient(typeof(IReadStore<>), typeof(ReadJsonStore<>));
            services.AddSingleton(typeof(IWriteStore<>), typeof(WriteJsonStore<>));
            services.AddComponent<MacGuffin>();
            services.AddComponent<EpisodeTemplate>();
            services.AddComponent<Faction>();


            return services;
        }

        private static IServiceCollection AddComponent<T>(this IServiceCollection services) where T : IComponentSummary
        {
            services.AddTransient<IRequestHandler<GetComponentSummaryQuery<T>, ComponentSummary[]>, GetComponentSummaryQueryHandler<T>>();
            services.AddTransient<IRequestHandler<GetComponentByIdQuery<T>, Maybe<T>>, GetComponentByIdQueryHandler<T>>();
            services.AddTransient<IRequestHandler<UpdateCommand<T>, CommandResult>, UpdateStoreObjectCommandHandler<T>>();
            services.AddTransient<IRequestHandler<DeleteCommand<T>, CommandResult>, DeleteStoreObjectCommandHandler<T>>();
            return services;
        }
    }
}
