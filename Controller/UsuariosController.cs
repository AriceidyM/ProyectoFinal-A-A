using FerreteriaSystem.Data;
using FerreteriaSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FerreteriaSystem.Controller
{
    public class UsuariosController
    {
        public bool Guardar(Usuarios usuarios)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                if (usuarios.UsuarioId == 0)
                {
                    paso = Insertar(usuarios);
                }
                else
                {
                    paso = Modificar(usuarios);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return paso;
        }

        private bool Insertar(Usuarios usuarios)
        {
            Contexto db = new Contexto();
            bool paso = false;

            db.Usuarios.Add(usuarios);
            paso = db.SaveChanges() > 0;

            return paso;
        }

        private bool Modificar(Usuarios usuarios)
        {
            Contexto db = new Contexto();
            bool paso = false;

            db.Usuarios.Add(usuarios).State = EntityState.Modified;
            paso = db.SaveChanges() > 0;

            return paso;
        }

        public Usuarios Buscar(int id)
        {
            Contexto db = new Contexto();
            Usuarios usuarios = new Usuarios();

            try
            {
                usuarios = db.Usuarios.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            return usuarios;
        }

        public bool Eliminar(int id)
        {
            Contexto db = new Contexto();
            bool paso = false;
            Usuarios usuarios = new Usuarios();

            try
            {
                usuarios = db.Usuarios.Find(id);
                db.Entry(usuarios).State = EntityState.Deleted;

                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }

            return paso;
        }

        public List<Usuarios> GetUsuarios(Expression<Func<Usuarios, bool>> expression)
        {
            List<Usuarios> lista;
            Contexto db = new Contexto();
            try
            {
                lista = db.Usuarios.Where(expression).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return lista;
        }
    }
}
