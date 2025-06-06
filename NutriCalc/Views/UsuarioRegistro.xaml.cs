namespace NutriCalc.Views;

public partial class UsuarioRegistro : ContentPage
{
	public UsuarioRegistro()
	{
		BindingContext = App.Current.Services.GetRequiredService<RegistroViewModel>();
		InitializeComponent();
	}
}