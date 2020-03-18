﻿using FerreteriaSystem.Data;
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
        public bool Guardar(Entrada entrada)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                if (entrada.ProductoId == 0)
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

        private bool Insertar(Entrada entrada)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Entrada.Add(entrada);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        private bool Modificar(Entrada entrada)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Entrada.Add(entrada);
                contexto.Entry(entrada).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public Entrada Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Entrada entrada = new Entrada();

            try
            {
                entrada = contexto.Entrada.Find(id);
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
            Entrada entrada = new Entrada();

            try
            {
                entrada = contexto.Entrada.Find(id);
                contexto.Entry(entrada).State = EntityState.Deleted;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public List<Entrada> GetList(Expression<Func<Entrada, bool>> expression)
        {
            Contexto contexto = new Contexto();
            List<Entrada> lista;

            try
            {
                lista = contexto.Entrada.Where(expression).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }
    }
}
