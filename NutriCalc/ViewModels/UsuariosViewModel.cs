using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;

namespace NutriCalc.ViewModels

{
    public partial class UsuariosViewModel: ObservableObject
    {
        public ObservableCollection<UsuarioModel> Usuarios { get; set; } = new();

        [RelayCommand]
        public async Task ListarUsuarios()
        {
            Usuarios.Clear();
            Usuarios.Add(new UsuarioModel {
                Id = 1,
                Nombre = "Juan",
                Apellido = "Pérez",
                Edad = 30
            });
            Usuarios.Add(new UsuarioModel
            {
                Id = 2,
                Nombre = "Roberto",
                Apellido = "Solis",
                Edad = 75
            });
            Usuarios.Add(new UsuarioModel
            {
                Id = 3,
                Nombre = "Pedro",
                Apellido = "Nuñez",
                Edad = 45
            });
        }
    }
}
