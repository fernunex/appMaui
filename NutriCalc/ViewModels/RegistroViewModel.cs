using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.Input;

namespace NutriCalc.ViewModels
{
    public partial class RegistroViewModel: ObservableValidator
    {
        private readonly IUsuariosDao _usuariosDao;


        [ObservableProperty]
        private string resultado;

        [ObservableProperty]
        private bool isBusy;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsEnabled))]
        private bool isVisible;

        public bool IsEnabled => !IsVisible;

        [ObservableProperty]
        private int id;


        public RegistroViewModel()
        {
            _usuariosDao = App.Current.Services.GetService<IUsuariosDao>();
        }


        // Para enumerar los errores de validación
        public ObservableCollection<string> ErroresValidacion { get; } = new ();


        // propiedades Fisiologicas
        private int peso;
        [Required(ErrorMessage = "El peso es obligatorio.")]
        [Range(10, 200, ErrorMessage = "El peso debe estar entre 10 y 200 kg.")]
        public int Peso
        {
            get => peso;
            set => SetProperty(ref peso, value, true);
        }

        private int estatura;

        [Required(ErrorMessage = "La estatura es obligatoria.")]
        [Range(40, 250, ErrorMessage = "La estatura debe estar entre 40 y 250 cm.")]
        public int Estatura
        {
            get => estatura;
            set => SetProperty(ref estatura, value, true);
        }

        private int selectedSexo=0;
        [Required(ErrorMessage = "El sexo es obligatorio.")]
        public int SelectedSexo
        {
            get => selectedSexo;
            set => SetProperty(ref selectedSexo, value, true);
        }

        private int selectedActividadFisica = 0;
        [Required(ErrorMessage = "La actividad física es obligatoria.")]
        public int SelectedActividadFisica
        {
            get => selectedActividadFisica;
            set => SetProperty(ref selectedActividadFisica, value, true);
        }

        // Propiedades generales
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
            IsBusy = true;
            IsVisible = false;
            ValidateAllProperties();

            ErroresValidacion.Clear();

            // Agregar errores del selector de sexo y Actividad fisica
            if (SelectedActividadFisica == 0)
            {
                ErroresValidacion.Add("Debe seleccionar un nivel de actividad física válido.");
            }
            if (SelectedSexo == 0)
            {
                ErroresValidacion.Add("Debe seleccionar un sexo válido.");
            }

            GetErrors(nameof(Nombre)).ToList().ForEach(error => ErroresValidacion.Add(error.ErrorMessage)); 
            GetErrors(nameof(Apellido)).ToList().ForEach(error => ErroresValidacion.Add(error.ErrorMessage));
            GetErrors(nameof(Edad)).ToList().ForEach(error => ErroresValidacion.Add(error.ErrorMessage));
            GetErrors(nameof(Peso)).ToList().ForEach(error => ErroresValidacion.Add(error.ErrorMessage));
            GetErrors(nameof(Estatura)).ToList().ForEach(error => ErroresValidacion.Add(error.ErrorMessage));


            IsBusy = false;
            if (ErroresValidacion.Count > 0) return;

            IsBusy = true;
            if (Id == 0) 
                Id = await _usuariosDao.AddUsuario(new UsuarioModel() 
                { Nombre = Nombre, 
                  Apellido = Apellido,
                  Edad = Edad});
            if (Id > 0) await _usuariosDao.UpdateUsuario(new UsuarioModel() 
            { Nombre = Nombre, 
              Apellido = Apellido, 
              Id = Id,
              Edad = Edad
            });

            Resultado = $" Registro id:{Id}";
            IsBusy = false;
            IsVisible = true;

            await Task.Delay(2000);
            LimpiarFormulario();
            await Shell.Current.Navigation.PopToRootAsync();
        }

        private void LimpiarFormulario()
        {
            Nombre = string.Empty;
            Apellido = string.Empty;
            Edad = 0;
            Peso = 0;
            Estatura = 0;
            SelectedSexo = 0;
            SelectedActividadFisica = 0;
            Resultado = string.Empty;
            IsVisible = false;
        }
    }
}
