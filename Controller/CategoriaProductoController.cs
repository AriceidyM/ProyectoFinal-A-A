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
    public class CategoriaProductoController
    {
        public bool Guardar(CategoriaProductos categoria)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                if (categoria.CategoriaId == 0)
                {
                    paso = Insertar(categoria);
                }
                else
                {
                    paso = Modificar(categoria);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        private bool Insertar(CategoriaProductos categoria)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Categorias.Add(categoria);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        private bool Modificar(CategoriaProductos categoria)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Categorias.Add(categoria);
                contexto.Entry(categoria).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public CategoriaProductos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            CategoriaProductos categoria = new CategoriaProductos();

            try
            {
                categoria = contexto.Categorias.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            return categoria;
        }

        public bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            CategoriaProductos categoria = new CategoriaProductos();

            try
            {
                categoria = contexto.Categorias.Find(id);
                contexto.Entry(categoria).State = EntityState.Deleted;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public List<CategoriaProductos> GetList(Expression<Func<CategoriaProductos, bool>> expression)
        {
            Contexto contexto = new Contexto();
            List<CategoriaProductos> lista;

            try
            {
                lista = contexto.Categorias.Where(expression).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }
    }
}
