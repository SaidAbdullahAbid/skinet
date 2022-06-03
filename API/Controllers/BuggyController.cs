using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.data;
using API.Errors;
using Infrastructure.data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseAPIController
    {
        private readonly StoreContext _context;

        public BuggyController(StoreContext context)
        {
            _context = context;
        }
        [HttpGet("notFound")]
        public ActionResult GetNotOFund()
        {
            var result = _context.Products.Find(33);
            if (result is null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok();
        }
        [HttpGet("serverError")]
        public ActionResult GetServerSideError()
        {
            var result = 30;
            result = result / 0;
            return Ok();

        }
        [HttpGet("badRequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }
        [HttpGet("badRequest/{id:int}")]
        public ActionResult GetBadRequest([FromRoute] int id)
        {
            var result = _context.Products.Find(id);
            if (result is null)
            {
                return BadRequest();
            }
            return Ok();
        }

    }
}