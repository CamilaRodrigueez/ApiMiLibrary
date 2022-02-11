using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Utils.Enums
{
    public class Enums
    {
        public enum TypeState
        {
            //Usuario
            Vendido = 1,
            Alquilado = 2,
            Encargado = 3,
            Reparando = 4,

        }
        public enum TypePermission
        {
            Usuarios = 1,
            Roles = 2,
            Permisos = 3,
            Biblioteca = 4,
        }
        public enum Permission
        {
            //Usuarios
            CrearUsuarios = 1,
            ActualizarUsuarios = 2,
            EliminarUsuarios = 3,
            ConsultarUsuarios = 4,

            //Roles
            ActualizarRoles = 5,
            ConsultarRoles = 6,

            //Permisos
            ActualizarPermisos = 7,
            ConsultarPermisos = 8,
            DenegarPermisos = 9,


            //Biblioteca
            InsertarNuevoLibro = 10,
            ActualizarDatosLibro = 11,
            EliminarLibro = 12,
            ConsultarLibros = 13,
            BuscarLibro = 14,
            ActualizarEditorial= 15,
            InsertarEditorial=16,
            EliminarEditorial=17,
            ConsultarEditoriales=18,
            ConsultarEdtadoLibro=19,

        }
        public enum RolUser
        {
            Administrador = 1,
            Bibliotecario = 2,
            Estandar = 3
        }
    }
}
