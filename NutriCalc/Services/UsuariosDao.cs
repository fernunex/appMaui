

namespace NutriCalc.Services
{
    public class UsuariosDao : IUsuariosDao
    {
        private readonly SQLLiteHelper<UsuarioModel> dataBase;

        public UsuariosDao()
        => dataBase = new();

        public Task<int> AddUsuario(UsuarioModel usuario)
        {
            return Task.FromResult(dataBase.Add(usuario));
        }

        public Task<int> DeleteUsuario(UsuarioModel usuario)
        {
            return Task.FromResult(dataBase.Delete(usuario));
        }

        public Task<List<UsuarioModel>> GetAll()
            => Task.FromResult(dataBase.GetAllData());

        public Task<UsuarioModel> GetUsuarioById(int id)
            => Task.FromResult(dataBase.Get(id));
 

        public Task<int> UpdateUsuario(UsuarioModel usuario)
        {
            return Task.FromResult(dataBase.Update(usuario));
        }
    }
}
