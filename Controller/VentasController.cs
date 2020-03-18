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
    public class VentasController
    {
        public bool Guardar(Ventas ventas)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                if (ventas.VentaId == 0)
                {
                    paso = Insertar(ventas);
                }
                else
                if (Buscar(ventas.VentaId) != null)
                {
                    paso = false;
                }
                else
                {
                    paso = Modificar(ventas);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }


        private bool Insertar(Ventas ventas)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Ventas.Add(ventas);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            return paso;
        }

        private bool Modificar(Ventas ventas)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Database.ExecuteSqlRaw($"Delete From VentasDetalles where VentaId={ventas.VentaId}");

                foreach (var item in ventas.Detalle)
                {
                    contexto.Entry(ventas).State = EntityState.Added;
                }

                contexto.Ventas.Add(ventas);
                contexto.Entry(ventas).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public Ventas Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Ventas ventas = new  Ventas();

            try
            {
                ventas = contexto.Ventas.Where(e => e.VentaId == id).Include(d => d.Detalle).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            return ventas;
        }

        public bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            Ventas ventas = new Ventas();
            bool paso = false;

            try
            {
                ventas = contexto.Ventas.Find(id);
                contexto.Entry(ventas).State = EntityState.Deleted;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public List<Ventas> GetList(Expression<Func<Ventas, bool>> expression)
        {
            Contexto contexto = new Contexto();
            List<Ventas> list;

            try
            {
                list = contexto.Ventas.Where(expression).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }
    }
}
