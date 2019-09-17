using Autofac;

namespace ConferenceTrackManagement
{
    public static class DependencyInjector
    {
        private static IContainer _container;
        public static void SetupDI()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<FileReader>().As<IFileReader>();
            builder.RegisterType<TrackPlanner>().As<ITrackPlanner>();
            builder.RegisterType<SessionPlanner>().As<ISessionPlanner>();
            builder.RegisterType<ConferenceManager>().As<IConferenceManager>();
            _container = builder.Build();
        }

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

    }
}
