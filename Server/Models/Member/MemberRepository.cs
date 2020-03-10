using Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Server.Models.Member;
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
    public class MemberRepository : IMember
    {
        private DataContext _context;

        private IConfiguration configuration;

        public MemberRepository(DataContext context, IConfiguration iConfig)
        {
            _context = context;
            configuration = iConfig;
        }

        public List<MemberEntity> GetAll()
        {
            return _context.member.ToList();
        }

        public MemberEntity GetById(Guid id)
        {
            return _context.member.Find(id);
        }

        public MemberReturnViewModel GetByIdViaJWT(string authHeader)
        {
            var handler = new JwtSecurityTokenHandler();
            string[] auth = authHeader.Split(" ");

            var exp = handler.ReadJwtToken(auth[1]).Payload.Exp;

            DateTime now = DateTime.Now;
            var date = now;

            var lifeTime = new JwtSecurityTokenHandler().ReadToken(auth[1]).ValidTo.ToLocalTime();

            var id = handler.ReadJwtToken(auth[1]).Payload.Jti;
            var member = _context.member.Find(Guid.Parse(id));
            var data = new MemberReturnViewModel();
            data.member_id = member.member_id;
            data.firstname = member.firstname;
            data.lastname = member.lastname;
            data.birthday = member.birthday;
            data.sex = member.sex;
            data.email = member.email;

            return data;
        }

        public MemberEntity Create(MemberEntity model)
        {

            var member = _context.member.Where(x => x.email == model.email).FirstOrDefault();

            if(member == null)
            {
                //model.member_id = Guid.NewGuid();
                model.password = StringToMD5(model.password);
                _context.member.Add(model);

                //add permission 
                var permission = new PermissionEntity();

                permission.permission_id = Guid.NewGuid();
                permission.member_id = model.member_id;
                permission.permission_type = "member";
                permission.created_at = DateTime.Now;

                _context.permission.Add(permission);

                _context.SaveChanges();

                model.password = null;
                return model;
            }
            else
            {
                if (member.email == model.email)
                {
                    throw new Exception("Email already exists");
                }
                else
                {
                    throw new Exception("Error");
                }
                
            } 
        }

        public object Login(MemberLoginViewModel model)
        {
            var checkPassword = StringToMD5(model.password);
            var member = _context.member.Where(x => x.email == model.email && x.password == checkPassword).FirstOrDefault();
            var permission = _context.permission.Where(x => x.member_id == member.member_id).FirstOrDefault();
            if (member == null)
            {
                throw new Exception();
            }
            else
            {
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, member.member_id.ToString()),
                    new Claim("permission", permission.permission_type)
                    //new Claim(JwtRegisteredClaimNames.GivenName, member.firstname),
                    //new Claim(JwtRegisteredClaimNames.FamilyName, member.lastname),
                    //new Claim(JwtRegisteredClaimNames.Email, member.email)
                };
                string key = configuration.GetSection("JWT").GetSection("SecurityKey").Value;
                var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

                var token = new JwtSecurityToken(
                    expires: DateTime.Now.AddSeconds(2000),
                    claims: claims,
                    signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
                    );

                var return_token = new {
                    jwt_token = new JwtSecurityTokenHandler().WriteToken(token),
                };

                return return_token;
            }   
        }

        static string StringToMD5(string value)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = md5.ComputeHash(utf8.GetBytes(value));
                return Convert.ToBase64String(data);
            }
        }

        public MemberEntity Update(Guid id, MemberEntity modelUpdate)
        {
            var data = _context.member.Find(id);

            data.firstname = modelUpdate.firstname;
            data.lastname = modelUpdate.lastname;
            //data.created_by = modelUpdate.created_by;
            //data.created_at = modelUpdate.created_at;
            data.updated_at = DateTime.Now;

            _context.SaveChanges();

            return data;
        }

        public MemberEntity Delete(Guid member_id)
        {
            var member = new MemberEntity()
            {
                member_id = member_id
            };

            var data = _context.member.Remove(member);

            _context.SaveChanges();

            return member;
        }  
    }
}
