namespace NutriCalc.Views;

public partial class ListadoUsuarios : ContentPage
{
	public ListadoUsuarios()
	{
		BindingContext = App.Current.Services.GetRequiredService<UsuariosViewModel>();
        InitializeComponent();
	}
}