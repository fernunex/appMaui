using SQLite;


namespace NutriCalc.Helper
{
    public class SQLLiteHelper<T> : SQLLiteBase where T : BaseModel, new()
    {
        public List<T> GetAllData()
   => _connection.Table<T>().ToList();

        public int Add(T row)
        {
            _connection.Insert(row);
            return row.Id;
        }

        public int Update(T row)
    => _connection.Update(row);

        public int Delete(T row)
    => _connection.Delete(row);

        public T Get(int ID)
    => _connection.Table<T>().Where(w => w.Id == ID).FirstOrDefault();
    }

    public class SQLLiteBase
    {
        private string _rutaDB;
        public SQLiteConnection _connection;

        public SQLLiteBase()
        {
            _rutaDB = FileAccessHelper.GetPathFile("alumnos.db3");
            Console.WriteLine($"Ruta de la base de datos: {_rutaDB}");
            if (_connection != null) return;
            _connection = new SQLiteConnection(_rutaDB);
            _connection.CreateTable<UsuarioModel>();
        }
    }
}
