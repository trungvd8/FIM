using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Models;
using WebAPI.Modules.Repository;
using WebAPI.Modules.Service;

namespace FIM.API.Modules.MUser
{
    public interface IRFQService
    {
        List<RequestForQuotation> GetAll();
        RequestForQuotation GetItemById(Guid id);
        RequestForQuotation Create(RequestForQuotation requestForQuotation);
        RequestForQuotation Update(RequestForQuotation requestForQuotation, Guid id);
        bool IsDelete(RequestForQuotation userEntity, Guid id);
    }
    public class RFQService : CommonService, IRFQService
    {
        private IRFQRepository _rFQRepository;

        public RFQService(IRFQRepository rFQRepository) : base()
        {
            _rFQRepository = rFQRepository;
        }

        //public int Count(SearchUserEntity SearchUserEntity)
        //{
        //    return this.UserRepository.Count(SearchUserEntity);
        //}

        public List<RequestForQuotation> GetAll()
        {
            List<RequestForQuotation> requestForQuotations = _rFQRepository.GetAll();
            //return Users.Select(P => new UserEntity(P)).ToList();
            return requestForQuotations;
        }
        public RequestForQuotation GetItemById(Guid id)
        {
            RequestForQuotation requestForQuotation = _rFQRepository.GetItemById(id);
            //if (User == null) return null;
            //UserEntity UserEntity = new UserEntity(User);
            //List<Role> Roles = new List<Role>();
            //UserEntity.RoleEntities = Roles.Select(r => new RoleEntity(r)).ToList();
            //return new UserEntity(User, Roles);
            return requestForQuotation;
        }
        public RequestForQuotation Create(RequestForQuotation requestForQuotation)
        {
            // return CreatedUserEntity;

            var a = new RequestForQuotation();
            return a;
        }
        public RequestForQuotation Update(RequestForQuotation requestForQuotation, Guid id)
        {
            // return UpdatedUserEntity;

            var a = new RequestForQuotation();
            return a;
        }
        public bool IsDelete(RequestForQuotation userEntity, Guid id)
        {
            // this.UserRepository.Delete(UserId);
            return true;
        }

    }
}
