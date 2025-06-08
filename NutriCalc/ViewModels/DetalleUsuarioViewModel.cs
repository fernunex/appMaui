using CommunityToolkit.Mvvm.Input;

namespace NutriCalc.ViewModels
{
    [QueryProperty(nameof(Id), nameof(Id))]
    public partial class DetalleUsuarioViewModel : ObservableObject
    {
        private readonly IUsuariosDao _usuariosDao;

        private int id;
        public int Id
        {
            get => id;
            set
            {
                SetProperty(ref id, value);
                if (id > 0)
                {
                    CargarUsuario().ConfigureAwait(false);
                }
            }
        }

        private UsuarioModel usuario;
        public UsuarioModel Usuario
        {
            get => usuario;
            set => SetProperty(ref usuario, value);
        }

        public DetalleUsuarioViewModel()
        {
            _usuariosDao = App.Current.Services.GetService<IUsuariosDao>();
        }

        private async Task CargarUsuario()
        {
            Usuario = await _usuariosDao.GetUsuarioById(Id);
        }

        [RelayCommand]
        public async Task Volver()
        {
            await Shell.Current.Navigation.PushAsync(new ListadoUsuarios(), false);
        }
    }
}