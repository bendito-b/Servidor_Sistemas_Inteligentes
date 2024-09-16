using AccesoDatos_Proyecto_SistemasInteligentes.Context;
using AccesoDatos_Proyecto_SistemasInteligentes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos_Proyecto_SistemasInteligentes.Operaciones
{
    public class UsuarioDAO
    {
        
        public ProyectoSistemasInteligentesContext contexto = new ProyectoSistemasInteligentesContext();
        public Usuario validar(string logi, string pass)
        {
            var resultado =  contexto.Usuarios.Where(u => u.LogiUsuario == logi 
                             && u.PassUsuario == pass).FirstOrDefault();
            return resultado;
        }

        //prueba
        public List <Usuario> listartodos()
        {
            var resultado = contexto.Usuarios.ToList<Usuario>();
            return resultado;
        }
    }
}
