namespace NutriCalc
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ListadoUsuarios), typeof(ListadoUsuarios));
        }
    }
}
