using Infraestructure.Core.Data;
using Infraestructure.Core.Repository;
using Infraestructure.Core.Repository.Interface;
using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Models.Library;
using Infraestructure.Entity.Models.Master;
using Infraestructure.Entity.Models.Security;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Core.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Attributes

        private readonly DataContext _context;
        private bool disposed = false;

        #endregion Attributes

        #region builder
        public UnitOfWork(DataContext context)
        {
            this._context = context;
        }
        #endregion builder


        #region Properties
        private IRepository<UserEntity> userRepository;
        private IRepository<RolEntity> rolRepository;
        private IRepository<RolUserEntity> rolUserRepository;
        private IRepository<TypeStateEntity> typeStateRepository;
        private IRepository<PermissionEntity> permissionRepository;
        private IRepository<TypePermissionEntity> typePermissionRepository;
        private IRepository<RolPermissionEntity> rolPermissionRepository;

        private IRepository<BooksEntity> booksRepository;
        private IRepository<EditorialEntity> editorialRepository;
        private IRepository<AuthorsEntity> authorsRepository;
        private IRepository<AuthorbooksEntity> authorbooksRepository;

        #endregion


        #region Members
        public IRepository<UserEntity> UserRepository
        {
            get
            {
                if (this.userRepository == null)
                    this.userRepository = new Repository<UserEntity>(_context);

                return userRepository;
            }
        }

        public IRepository<RolEntity> RolRepository
        {
            get
            {
                if (this.rolRepository == null)
                    this.rolRepository = new Repository<RolEntity>(_context);

                return rolRepository;
            }
        }

        public IRepository<RolUserEntity> RolUserRepository
        {
            get
            {
                if (this.rolUserRepository == null)
                    this.rolUserRepository = new Repository<RolUserEntity>(_context);

                return rolUserRepository;
            }
        }

        public IRepository<TypeStateEntity> TypeStateRepository
        {
            get
            {
                if (this.typeStateRepository == null)
                    this.typeStateRepository = new Repository<TypeStateEntity>(_context);

                return typeStateRepository;
            }
        }

        public IRepository<PermissionEntity> PermissionRepository
        {
            get
            {
                if (this.permissionRepository == null)
                    this.permissionRepository = new Repository<PermissionEntity>(_context);

                return permissionRepository;
            }
        }

        public IRepository<TypePermissionEntity> TypePermissionRepository
        {
            get
            {
                if (this.typePermissionRepository == null)
                    this.typePermissionRepository = new Repository<TypePermissionEntity>(_context);

                return typePermissionRepository;
            }
        }

        public IRepository<RolPermissionEntity> RolesPermissionRepository
        {
            get
            {
                if (this.rolPermissionRepository == null)
                    this.rolPermissionRepository = new Repository<RolPermissionEntity>(_context);

                return rolPermissionRepository;
            }
        } 

       
        public IRepository<BooksEntity> BooksRepository
        {
            get
            {
                if (this.booksRepository == null)
                    this.booksRepository = new Repository<BooksEntity>(_context);

                return booksRepository;
            }
        }  
        public IRepository<EditorialEntity> EditorialRepository
        {
            get
            {
                if (this.editorialRepository == null)
                    this.editorialRepository = new Repository<EditorialEntity>(_context);

                return editorialRepository;
            }
        }

        public IRepository<AuthorsEntity> AuthorsRepository
        {
            get
            {
                if (this.authorsRepository == null)
                    this.authorsRepository = new Repository<AuthorsEntity>(_context);

                return authorsRepository;
            }
        }
        public IRepository<AuthorbooksEntity> AuthorbooksRepository
        {
            get
            {
                if (this.authorbooksRepository == null)
                    this.authorbooksRepository = new Repository<AuthorbooksEntity>(_context);

                return authorbooksRepository;
            }
        }
        #endregion

        protected virtual void Dispose(bool disposing)
        {

            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<int> Save() => await _context.SaveChangesAsync();
    }
}
