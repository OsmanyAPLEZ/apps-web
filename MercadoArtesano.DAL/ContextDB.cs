﻿using MercadoArtesano.EN;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoArtesano.DAL
{
    public class ContextDB
    {
        #region REFERENCIAS DE LAS TABLAS DE LA BD

        public DbSet<Role> Roles { get; set; } //Coleccion que hace referencia a la tabla de la base de datos

        public DbSet<Customer> Customers { get; set; } //Coleccion que hace referencia a la tabla de la base de datos

        #endregion

        // Metodo de Conexion a la Base de Datos
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@""); //Poner str de concexion local
        }
    }
}