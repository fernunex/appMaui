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

        public override string ToString()
        {
            return $"{Nombre} {Apellido}, {Edad} años";
        }
    }

}
