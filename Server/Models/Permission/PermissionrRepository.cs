using Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Server.Models.Permission;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Models
{
    public class PermissionRepository : IPermission
    {
        private DataContext _context;

        private IConfiguration configuration;

        public PermissionRepository(DataContext context, IConfiguration iConfig)
        {
            _context = context;
            configuration = iConfig;
        }

        public List<PermissionEntity> GetAll()
        {
            return _context.permission.ToList();
        }

        public PermissionEntity GetById(Guid id)
        {
            return _context.permission.Find(id);
        }

        public PermissionEntity Create(PermissionEntity model)
        {
            _context.permission.Add(model);
            _context.SaveChanges();

            return model;  
        } 
        
        public PermissionEntity Update(Guid id, PermissionEntity modelUpdate)
        {
            var data = _context.permission.Find(id);

            data.permission_type = modelUpdate.permission_type;
            data.updated_at = DateTime.Now;

            _context.SaveChanges();

            return data;
        }

        public PermissionEntity Delete(Guid permission_id)
        {
            var permission = new PermissionEntity()
            {
                permission_id = permission_id
            };

            var data = _context.permission.Remove(permission);

            _context.SaveChanges();

            return permission;
        }  
    }
}
