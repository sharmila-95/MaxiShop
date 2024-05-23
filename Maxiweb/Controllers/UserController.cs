using Maxi.Application.ApplicationConstants;
using Maxi.Application.Common;
using Maxi.Application.InputModel;
using Maxi.Application.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Maxiweb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAuthService _authService;
        protected APIResponse _apiResponse;


        public UserController(IAuthService authService)
        {
            _authService = authService;
            _apiResponse = new APIResponse();
        }

        [HttpPost]
        public async Task<ActionResult<APIResponse>> Register(Register register)
        {
            try
            {
                var data = await _authService.Register(register);

                _apiResponse.StatusCode = HttpStatusCode.OK;
                _apiResponse.IsSuccess = true;
                _apiResponse.DisplayMessage = CommonMessage.CreateOperationSuccess;
                _apiResponse.Result = data;
            }
            catch (Exception)
            {
                _apiResponse.StatusCode = HttpStatusCode.InternalServerError;
                _apiResponse.AddError(CommonMessage.SystemErr);

            }

            return Ok(_apiResponse);
        }

    }
}
