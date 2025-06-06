namespace NutriCalc
{
    public partial class App : Application
    {
        public new static App Current => (App) Application.Current;
        public IServiceProvider Services { get; }


        public App()
        {
            var services = new ServiceCollection();

            Services = ConfigureServices(services);

            InitializeComponent();
        }

        private static IServiceProvider ConfigureServices(ServiceCollection services)
        {

            //ViewModels
            services.AddTransient<UsuariosViewModel>();
            services.AddTransient<RegistroViewModel>();


            //Views
            services.AddSingleton<ListadoUsuarios>();
            services.AddTransient<UsuarioRegistro>();

            //Services


            return services.BuildServiceProvider();
        }


        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}