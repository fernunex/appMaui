using SQLite;


namespace NutriCalc.Models
{
    [Table("Usuario")]
    public class UsuarioModel : BaseModel
    {
        [MaxLength(30)]
        public string Nombre { get; set; } = "";

        [MaxLength(30)]
        public string Apellido { get; set; } = "";

        public int Edad { get; set; }

        public int Peso { get; set; }
        public int Estatura { get; set; }
        public int Sexo { get; set; } // 1: Masculino, 2: Femenino
        public int ActividadFisica { get; set; } // 1: Rara vez, 2: 1 a 3 veces a la semana,
                                                 // 3: 3 a 4 veces a la semana, 4: 6 a 7 veces a la semana,
                                                 // 5: Trabajo físico intenso + Ejercicio
        public double IMC { get; set; } // Índice de Masa Corporal
        public string EstadoIMC { get; set; } = ""; // Estado del IMC (Bajo peso, Normal, Sobrepeso, Obesidad)
        public int GrasaCorporal { get; set; } // Porcentaje de grasa corporal
        public string EstadoGrasaCorporal { get; set; } = ""; // Estado de la grasa corporal (Grasa Esencial, Atletas, etc)
        public int PesoIdeal { get; set; } // Peso ideal calculado
        public double GastoTotalEnergetico { get; set; } // Gasto total energético calculado

        public override string ToString()
        {
            return $"{Nombre} {Apellido}, {Edad} años";
        }
    }

}
