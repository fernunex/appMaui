using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;

namespace NutriCalc.ViewModels

{
    public partial class UsuariosViewModel : ObservableObject
    {

        // Para jalar los usuarios
        private readonly IUsuariosDao _usuariosDao;
        private readonly IDialogService _dialogService;

        // Auxiliares para cuando carga
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsReady))]
        private bool isLoading;

        [ObservableProperty]
        bool isRefreshing;
        public bool IsReady => !IsLoading;

        public UsuariosViewModel()
        {
            _usuariosDao = App.Current.Services.GetService<IUsuariosDao>();
            _dialogService = App.Current.Services.GetService<IDialogService>();
            Task.Run(async () => await ListarUsuarios());
        }


        // Estos son los usuarios
        public ObservableCollection<UsuarioModel> Usuarios { get; set; } = new();

        [RelayCommand]
        public async Task ListarUsuarios()
        {
            IsLoading = true;
            Usuarios.Clear();
            var lista = await _usuariosDao.GetAll();
            foreach (var usuario in lista) Usuarios.Add(usuario);
            IsLoading = false;
            IsRefreshing = false;
        }

        [RelayCommand]
        public async Task EliminarUsuario(UsuarioModel usuario)
        {
            IsLoading = true;
            var res = await _dialogService.ShowAlertAsync(
                $"¿Estás seguro de eliminar el usuario con id {usuario.Id}?",
                "Confirmación",
                "Sí", "No");
            if (res == false) return;
            var resultadoEliminar = await _usuariosDao.DeleteUsuario(usuario);
            await ListarUsuarios();
        }

        [RelayCommand]
        public async Task EditarUsuario(UsuarioModel usuario)
        {
            await Shell.Current.GoToAsync($"/UsuarioRegistro?" +
                $"Id={usuario.Id}" +
                $"&Nombre={usuario.Nombre}" +
                $"&Apellido={usuario.Apellido}" +
                $"&Edad={usuario.Edad}" +
                $"&Peso={usuario.Peso}" +
                $"&Estatura={usuario.Estatura}" +
                $"&SelectedSexo={usuario.Sexo}" +
                $"&SelectedActividadFisica={usuario.ActividadFisica}", false);
        }

        [RelayCommand]
        public async Task AgregarUsuario()
        {
            await Shell.Current.Navigation.PushAsync(new UsuarioRegistro(), false);
        }

        [RelayCommand]
        public async Task DetalleUsuario(UsuarioModel usuario)
        {
            await Shell.Current.GoToAsync($"/DetalleUsuario?Id={usuario.Id}", false);
        }
    }
}
