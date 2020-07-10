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
    //[Authorize(AuthenticationSchemes = (SecurityConstants.AuthenticationScheme))]
    [ApiController]
    public class ImageDeletionController : ControllerBase
    {
        public ImageDeletionController(ImageCommonService imageExtract)
        {
            _imageExtract = imageExtract;
        }

        //Services & Dependencies
        private readonly ImageCommonService _imageExtract;

        [HttpGet]
        [Route("/begin_deletion")]
        public ActionResult<string> DeleteAllData()
        {
            try
            {
                _imageExtract.ClearAllData();
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
