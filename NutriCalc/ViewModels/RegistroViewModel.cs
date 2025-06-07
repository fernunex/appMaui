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
            GetErrors(nameof(Nombre)).ToList().ForEach(error => ErroresValidacion.Add(error.ErrorMessage)); 
            GetErrors(nameof(Apellido)).ToList().ForEach(error => ErroresValidacion.Add(error.ErrorMessage));
            GetErrors(nameof(Edad)).ToList().ForEach(error => ErroresValidacion.Add(error.ErrorMessage));

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
            await Shell.Current.Navigation.PopToRootAsync();
        }


    }
}
