namespace NutriCalc.Views.Templates;

public partial class ItemUsuario : ContentView
{
	private readonly UsuariosViewModel viewModel;
	public ItemUsuario()
	{
		try
		{
            viewModel = App.Current.Services.GetService<UsuariosViewModel>();
            InitializeComponent();
            //BindingContext = viewModel;

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al inicializar ItemUsuario: {ex.Message}");
        }
	}
}