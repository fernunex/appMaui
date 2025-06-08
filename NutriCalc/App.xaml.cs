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
            MainPage = new AppShell();
        }

        private static IServiceProvider ConfigureServices(ServiceCollection services)
        {

            //ViewModels
            services.AddTransient<UsuariosViewModel>();
            services.AddTransient<RegistroViewModel>();
            services.AddTransient<DetalleUsuarioViewModel>();


            //Views
            services.AddSingleton<ListadoUsuarios>();
            services.AddSingleton<UsuarioRegistro>();
            services.AddSingleton<DetalleUsuario>();

            //Services
            services.AddTransient<IUsuariosDao, UsuariosDao>();
            services.AddTransient<IDialogService, DialogService>();


            return services.BuildServiceProvider();
        }

        //protected override Window CreateWindow(IActivationState? activationState)
        //{
        //    return new Window(new AppShell());
        //}
    }
}