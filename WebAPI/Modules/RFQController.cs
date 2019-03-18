using FIM.API.Modules.MUser;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Modules
{
    [Route("api/RFQ")]
    public class RFQController : CommonController
    {
        private readonly IRFQService _service;
        public RFQController(IRFQService service)
        {
            _service = service;
        }

        [Route("GetAll"), HttpGet]
        public List<RequestForQuotation> GetAll()
        {
            return _service.GetAll();
        }

        [Route("GetItemById/{id}"), HttpGet("{id}")]
        public RequestForQuotation GetItemById([FromRoute] Guid id)
        {
            return _service.GetItemById(id);
        }
    }
}