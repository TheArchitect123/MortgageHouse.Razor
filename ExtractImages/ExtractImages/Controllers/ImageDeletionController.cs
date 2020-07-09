using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ExtractImages.Constants;
using ExtractImages.Extensions;
using ExtractImages.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExtractImages.Controllers
{
    [Produces("text/plain")]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = (SecurityConstants.AuthenticationScheme))]
    [ApiController]
    public class ImageDeletionController : ControllerBase
    {
        public ImageDeletionController(IMapper mapper, ImageCommonService imageExtract)
        {
            _imageExtract = imageExtract;
            _mapper = mapper;
        }

        //Services & Dependencies
        private readonly IMapper _mapper;
        private readonly ImageCommonService _imageExtract;

        [HttpGet]
        [Route("/begin_deletion")]
        public ActionResult<string> DeleteAllData()
        {
            try
            {

                //Delete all the items, then force the angular client to render a empty table
                return Ok("Successful Deletion of data");
            }
            catch (Exception ex)
            {
                ex.LogException();
                return "Could not find any addresses for this query";
            }
        }
    }
}
