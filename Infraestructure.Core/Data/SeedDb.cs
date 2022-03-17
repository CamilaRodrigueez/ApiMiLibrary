using Common.Utils.Enums;
using Infraestructure.Entity.Models.Master;
using Infraestructure.Entity.Models.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Core.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        #region Builder
        public SeedDb(DataContext context)
        {
            _context = context;
        }
        #endregion

        public async Task ExecSeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckTypeStateAsync();

            await CheckTypePermissionAsync();
            await CheckPermissionAsync();
            await CheckRolAsync();
            await CheckRolPermissonAsync();
            await CheckUsersAsync();


        }
        private async Task CheckTypeStateAsync()
        {
            if (!_context.TypeStateEntity.Any())
            {
                _context.TypeStateEntity.AddRange(new List<TypeStateEntity>
                {
                    new TypeStateEntity
                    {
                        IdTypeState=(int)Enums.TypeState.Vendido,
                        TypeState="Vendido"
                    },
                    new TypeStateEntity
                    {
                        IdTypeState=(int)Enums.TypeState.Alquilado,
                        TypeState ="Alquilado"
                    },
                    new TypeStateEntity
                    {
                        IdTypeState=(int)Enums.TypeState.Encargado,
                        TypeState ="Encargado"
                    },new TypeStateEntity
                    {
                        IdTypeState=(int)Enums.TypeState.Reparando,
                        TypeState ="Reparando"
                    }
                });
                await _context.SaveChangesAsync();
            }
        }
        private async Task CheckTypePermissionAsync()
        {
            if (!_context.TypePermissionEntity.Any())
            {
                _context.TypePermissionEntity.AddRange(new List<TypePermissionEntity>
                {
                      new TypePermissionEntity
                      {
                        IdTypePermission=(int)Enums.TypePermission.Usuario,
                        TypePermission="Usuarios"

                      },
                       new TypePermissionEntity
                       {
                        IdTypePermission=(int)Enums.TypePermission.Roles,
                        TypePermission="Roles"

                       },
                      new TypePermissionEntity
                      {
                        IdTypePermission=(int)Enums.TypePermission.Permisos,
                        TypePermission="Permisos"

                      },
                      new TypePermissionEntity
                      {
                        IdTypePermission=(int)Enums.TypePermission.Autores,
                        TypePermission="Biblioteca"

                      },
                      new TypePermissionEntity
                      {
                        IdTypePermission=(int)Enums.TypePermission.Libros,
                        TypePermission="AutorS"

                      },
                       new TypePermissionEntity
                      {
                        IdTypePermission=(int)Enums.TypePermission.Estados,
                        TypePermission="AutorS"

                      },
                        new TypePermissionEntity
                      {
                        IdTypePermission=(int)Enums.TypePermission.Editoriales,
                        TypePermission="AutorS"

                      },
                });
                await _context.SaveChangesAsync();
            }
        }
        private async Task CheckPermissionAsync()
        {
            if (!_context.PermissionEntity.Any())
            {
                _context.PermissionEntity.AddRange(new List<PermissionEntity>
                {
                    //Usuarios
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.CrearUsuarios,
                        IdTypePermission=(int)Enums.TypePermission.Usuario,
                        Permission="Crear Usuarios",
                        Description="Crear Usuarios al Sistemas"
                    },

                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ActualizarUsuarios,
                        IdTypePermission=(int)Enums.TypePermission.Usuario,
                        Permission="Actualizar Usuarios",
                        Description="Actualizar datos de un usuarios en el sistema"
                    },

                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.EliminarUsuarios,
                        IdTypePermission=(int)Enums.TypePermission.Usuario,
                        Permission="Eliminar Usuarios",
                        Description="Eliminar un usuario del sistema"
                    },

                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ConsultarUsuarios,
                        IdTypePermission=(int)Enums.TypePermission.Usuario,
                        Permission="Consultar Usuarios",
                        Description="Consulta todos los usuarios"
                    },

                    //Roles
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ActualizarRoles,
                        IdTypePermission=(int)Enums.TypePermission.Roles,
                        Permission="Actualizar Roles",
                        Description="Actualizar datos de los roles en el sistema"
                    },

                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ConsultarRoles,
                        IdTypePermission=(int)Enums.TypePermission.Roles,
                        Permission="Consultar Roles",
                        Description="Consultar Roles del sistema"
                    },

                    //Permisos
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ActualizarPermisos,
                        IdTypePermission=(int)Enums.TypePermission.Permisos,
                        Permission="Actualizar Permisos",
                        Description="Actualizar datos de un permiso en el sistema"
                    },

                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ConsultarPermisos,
                        IdTypePermission=(int)Enums.TypePermission.Permisos,
                        Permission="Consultar Permisos",
                        Description="Consultar Permisos del sistema"
                    },

                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.DenegarPermisos,
                        IdTypePermission=(int)Enums.TypePermission.Permisos,
                        Permission="Denegar Permisos",
                        Description="Denegar Permisos a un rol del sistema"
                    },

                    //Estados
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ConsultarEstados,
                        IdTypePermission=(int)Enums.TypePermission.Estados,
                        Permission="Consultar Estado",
                        Description="Consultar los estados del sistema"
                    },

                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ActualizarEstados,
                        IdTypePermission=(int)Enums.TypePermission.Estados,
                        Permission="Actualizar Estado",
                        Description="Actualizar los estados del sistema"
                    },

                    //Libros
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.CrearLibros,
                        IdTypePermission=(int)Enums.TypePermission.Libros,
                        Permission="Consultar Libros",
                        Description="Crear los estados de los libros"
                    },

                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ActualizarLibros,
                        IdTypePermission=(int)Enums.TypePermission.Libros,
                        Permission="Actualizar Libros",
                        Description="Actualizar los estados de los libros"
                    },

                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.EliminarLibros,
                        IdTypePermission=(int)Enums.TypePermission.Libros,
                        Permission="Eliminar Libros",
                        Description="Eliminar los estados de los libros"
                    },

                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ConsultarLibros,
                        IdTypePermission=(int)Enums.TypePermission.Libros,
                        Permission="Consultar Libros",
                        Description="Consultar los estados de los libros"
                    },

                    //Editoriales
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.CrearEditoriales,
                        IdTypePermission=(int)Enums.TypePermission.Editoriales,
                        Permission="Crear Editoriales",
                        Description="Crear los estados de las editoriales"
                    },

                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ActualizarEditoriales,
                        IdTypePermission=(int)Enums.TypePermission.Editoriales,
                        Permission="Actualizar Editoriales",
                        Description="Actualizar los estados de las editoriales"
                    },

                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.EliminarEditoriales,
                        IdTypePermission=(int)Enums.TypePermission.Editoriales,
                        Permission="Eliminar Editoriales",
                        Description="Eliminar los estados de las editoriales"
                    },

                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ConsultarEditoriales,
                        IdTypePermission=(int)Enums.TypePermission.Editoriales,
                        Permission="Consultar Editoriales",
                        Description="Consultar los estados de las editoriales"
                    },

                    //Autores
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.CrearAutores,
                        IdTypePermission=(int)Enums.TypePermission.Autores,
                        Permission="Crear Autores",
                        Description="Crear los estados de los autores"
                    },

                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ActualizarAutores,
                        IdTypePermission=(int)Enums.TypePermission.Autores,
                        Permission="Actualizar Autores",
                        Description="Actualizar los estados de los autores"
                    },

                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.EliminarAutores,
                        IdTypePermission=(int)Enums.TypePermission.Autores,
                        Permission="Eliminar Autores",
                        Description="Eliminar los estados de los autores"
                    },

                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ConsultarAutores,
                        IdTypePermission=(int)Enums.TypePermission.Autores,
                        Permission="Consultar Autores",
                        Description="Consultar los estados de los autores"
                    }
                });
                await _context.SaveChangesAsync();
            }
        }
        private async Task CheckRolAsync()
        {
            if (!_context.RolEntity.Any())
            {
                _context.RolEntity.AddRange(new List<RolEntity>
                {
                    new RolEntity
                    {
                        IdRol=(int)Enums.RolUser.Administrador,
                        Rol="Administrador"
                    },
                     new RolEntity
                    {
                        IdRol=(int)Enums.RolUser.Estandar,
                        Rol="Estandar"
                    }
                });

                await _context.SaveChangesAsync();
            }
        }
        private async Task CheckRolPermissonAsync()
        {
            if (!_context.RolPermissionEntity.Where(x => x.IdRol == (int)Enums.RolUser.Administrador).Any())
            {
                var rolesPermisosAdmin = _context.PermissionEntity.Select(x => new RolPermissionEntity
                {
                    IdRol = (int)Enums.RolUser.Administrador,
                    IdPermission = x.IdPermission
                }).ToList();

                _context.RolPermissionEntity.AddRange(rolesPermisosAdmin);
                _context.RolPermissionEntity.AddRange(new List<RolPermissionEntity>
                    {

                        new RolPermissionEntity
                        {
                        IdRol = (int)Enums.RolUser.Estandar,
                        IdPermission = (int)Enums.Permission.ConsultarLibros
                        },

                        new RolPermissionEntity
                        {
                        IdRol = (int)Enums.RolUser.Estandar,
                        IdPermission = (int)Enums.Permission.ConsultarEditoriales
                        },

                        new RolPermissionEntity
                        {
                        IdRol = (int)Enums.RolUser.Estandar,
                        IdPermission = (int)Enums.Permission.ConsultarAutores
                        }

                    });

                await _context.SaveChangesAsync();

            }

        }
        private async Task CheckUsersAsync()
        {
            if (!_context.RolUserEntity.Any())
            {
                _context.RolUserEntity.AddRange(new List<RolUserEntity>
                    {
                    new RolUserEntity()
                    {
                            IdRol = (int)Enums.RolUser.Estandar,
                            UserEntity = new UserEntity()
                        {
                            Name = "Magnus",
                            LastName = "Lopez",
                            Email = "magnus@gmail.com",
                            Password = "123456"
                        }
                    },

                    new RolUserEntity()
                    {
                            IdRol = (int)Enums.RolUser.Administrador,
                            UserEntity = new UserEntity()
                            {
                                Name = "Camila",
                                LastName = "Rodriguez",
                                Email = "carepa@gmail.com",
                                Password = "123456"
                            }
                    },
                    });

                await _context.SaveChangesAsync();
            }
        }
    }
}
