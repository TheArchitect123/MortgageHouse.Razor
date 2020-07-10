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
using Newtonsoft.Json;

namespace ExtractImages.Controllers
{
    [Produces("text/plain")]
    // [Authorize(AuthenticationSchemes = (SecurityConstants.AuthenticationScheme))]
    [ApiController]
    public class ImageExtractionController : ControllerBase
    {
        public ImageExtractionController(ImageCommonService imageExtract)
        {
            _imageExtract = imageExtract;
        }

        //Services & Dependencies
        private readonly ImageCommonService _imageExtract;

        [HttpGet]
        [Route("/begin_extraction")]
        public ActionResult<string> ExtractAllData()
        {
            try
            {
                return JsonConvert.SerializeObject(_imageExtract.ExtractImages());
            }
            catch (Exception ex)
            {
                ex.LogException();
                return "Could not find any addresses for this query";
            }
        }
    }
}
