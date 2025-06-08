using CommunityToolkit.Mvvm.Input;

namespace NutriCalc.ViewModels
{
    [QueryProperty(nameof(Id), nameof(Id))]
    public partial class DetalleUsuarioViewModel : ObservableObject
    {
        private readonly IUsuariosDao _usuariosDao;

        private string sexoString;
        public string SexoString
        {
            get => sexoString;
            set => SetProperty(ref sexoString, value);
        }


        private string actividadFisicaString;
        public string ActividadFisicaString
        {
            get => actividadFisicaString;
            set => SetProperty(ref actividadFisicaString, value);
        }


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
                    SexoString = GetSexoString(Usuario?.Sexo ?? 0);
                    ActividadFisicaString = GetActividadFisicaString(Usuario?.ActividadFisica ?? 0);
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


        public string GetSexoString(int sexoNum)
        {
            return sexoNum switch
            {
                1 => "Masculino",
                2 => "Femenino",
                _ => "No especificado"
            };
        }

        public string GetActividadFisicaString(int actividadFisicaNum)
        {
            return actividadFisicaNum switch
            {
                1 => "Rara vez",
                2 => "1 a 3 días a la semana",
                3 => "3 a 5 días a la semana",
                4 => "6 a 7 días a la semana",
                5 => "Trabajo físico intenso + Ejercicio Diario",
                _ => "No especificado"
            };

        }
    }
}