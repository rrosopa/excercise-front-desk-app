using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace frontedesk.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected ISender _sender;
        public BaseController(ISender sender)
        {
            _sender = sender;
        }
    }
}
