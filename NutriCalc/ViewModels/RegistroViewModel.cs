using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.Input;

namespace NutriCalc.ViewModels
{
    public partial class RegistroViewModel: ObservableValidator
    {
        // Para enumerar los errores de validación
        public ObservableCollection<string> ErroresValidacion { get; } = new ();


        private string nombre;

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [MaxLength(30, ErrorMessage = "El nombre no puede exceder los 30 caracteres.")]
        [MinLength(2, ErrorMessage = "El nombre debe tener al menos 2 caracteres.")]
        public string Nombre
        {
            get => nombre;
            set => SetProperty(ref nombre, value, true);
        }



        private string apellido;
        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [MaxLength(30, ErrorMessage = "El apellido no puede exceder los 30 caracteres.")]
        [MinLength(2, ErrorMessage = "El apellido debe tener al menos 2 caracteres.")]
        public string Apellido
        {
            get => apellido;
            set => SetProperty(ref apellido, value, true);
        }


        private int edad;
        [Required(ErrorMessage = "La edad es obligatoria.")]
        [Range(3, 90, ErrorMessage = "La edad debe estar entre 3 y 90 años.")]
        public int Edad
        {
            get => edad;
            set => SetProperty(ref edad, value, true);
        }

        [RelayCommand]
        public async Task GuardarUsuario()
        {
            ValidateAllProperties();
            
            ErroresValidacion.Clear();
            GetErrors(nameof(Nombre)).ToList().ForEach(error => ErroresValidacion.Add(error.ErrorMessage)); 
            GetErrors(nameof(Apellido)).ToList().ForEach(error => ErroresValidacion.Add(error.ErrorMessage));
            GetErrors(nameof(Edad)).ToList().ForEach(error => ErroresValidacion.Add(error.ErrorMessage));

        }


    }
}
