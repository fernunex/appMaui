namespace NutriCalc.Views;

public partial class DetalleUsuario : ContentPage
{
	public DetalleUsuario()
	{
        BindingContext = App.Current.Services.GetRequiredService<DetalleUsuarioViewModel>();
        InitializeComponent();
	}
}