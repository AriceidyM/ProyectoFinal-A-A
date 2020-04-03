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
    public class EntradaController
    {
        public bool Guardar(Entradas entrada)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                if (entrada.EntradaId == 0)
                {
                    paso = Insertar(entrada);

                }
                else
                {
                    paso = Modificar(entrada);

                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        private bool Insertar(Entradas entrada)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
              
                contexto.Productos.Find(entrada.ProductoId).Existencia += entrada.Cantidad;
                
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        private bool Modificar(Entradas entrada)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Entradas.Add(entrada);
                contexto.Entry(entrada).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public Entradas Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Entradas entrada = new Entradas();

            try
            {
                entrada = contexto.Entradas.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            return entrada;
        }

        public bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            Entradas entrada = new Entradas();

            try
            {
                entrada = contexto.Entradas.Find(id);
                contexto.Entry(entrada).State = EntityState.Deleted;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public List<Entradas> GetList(Expression<Func<Entradas, bool>> expression)
        {
            Contexto contexto = new Contexto();
            List<Entradas> lista;

            try
            {
                lista = contexto.Entradas.Where(expression).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }
    }
}
