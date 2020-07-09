using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExtractImages.Controllers
{
    [Produces("text/plain")]
    [Route("api/[controller]")]
    //   [Authorize(AuthenticationSchemes = (SecurityConstants.AuthenticationScheme))]
    [ApiController]
    public class ImageSavingController : ControllerBase
    {
    }
}
