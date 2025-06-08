namespace NutriCalc
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ListadoUsuarios), typeof(ListadoUsuarios));
            Routing.RegisterRoute(nameof(UsuarioRegistro), typeof(UsuarioRegistro));
            Routing.RegisterRoute(nameof(DetalleUsuario), typeof(DetalleUsuario));
        }
    }
}
