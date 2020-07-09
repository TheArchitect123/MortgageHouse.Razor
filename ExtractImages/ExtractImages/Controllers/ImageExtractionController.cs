using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ExtractImages.Constants;
using ExtractImages.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExtractImages.Extensions;

namespace ExtractImages.Controllers
{
    [Produces("text/plain")]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = (SecurityConstants.AuthenticationScheme))]
    [ApiController]
    public class ImageExtractionController : ControllerBase
    {
        public ImageExtractionController(IMapper mapper, ImageCommonService imageExtract)
        {
            _imageExtract = imageExtract;
            _mapper = mapper;
        }

        //Services & Dependencies
        private readonly IMapper _mapper;
        private readonly ImageCommonService _imageExtract;

        [HttpGet]
        [Route("/begin_extraction")]
        public ActionResult<string> ExtractAllData()
        {
            try
            {

                return Ok("Successful extraction of data");
            }
            catch (Exception ex)
            {
                ex.LogException();
                return "Could not find any addresses for this query";
            }
        }
    }
}
