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
    public class ClienteController
    {
        public bool Guardar(Clientes clientes)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                if (clientes.ClienteId == 0)
                {
                    paso = Insertar(clientes);
                }
                else
                {
                    paso = Modificar(clientes);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return paso;
        }

        private bool Insertar(Clientes clientes)
        {
            Contexto db = new Contexto();
            bool paso = false;

            db.Clientes.Add(clientes);
            paso = db.SaveChanges() > 0;

            return paso;
        }

        private bool Modificar(Clientes clientes)
        {
            Contexto db = new Contexto();
            bool paso = false;

            db.Clientes.Add(clientes).State = EntityState.Modified;
            paso = db.SaveChanges() > 0;

            return paso;
        }

        public Clientes Buscar(int id)
        {
            Contexto db = new Contexto();
            Clientes clientes = new Clientes();

            try
            {
                clientes = db.Clientes.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            return clientes;
        }

        public bool Eliminar(int id)
        {
            Contexto db = new Contexto();
            bool paso = false;
            Clientes Clientes = new Clientes();

            try
            {
                Clientes = db.Clientes.Find(id);
                db.Entry(Clientes).State = EntityState.Deleted;

                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }

            return paso;
        }

        public List<Clientes> GetClientes(Expression<Func<Clientes, bool>> expression)
        {
            List<Clientes> lista;
            Contexto db = new Contexto();
            try
            {
                lista = db.Clientes.Where(expression).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return lista;
        }
    }
}
