using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutriCalc.Interfaces
{
    public interface IUsuariosDao
    {
        public Task<List<UsuarioModel>> GetAll();
        public Task<UsuarioModel> GetUsuarioById(int id);
        public Task<int> AddUsuario(UsuarioModel usuario);
        public Task<int> DeleteUsuario(UsuarioModel usuario);
        public Task<int> UpdateUsuario(UsuarioModel usuario);

    }
}
