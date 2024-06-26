﻿using Maxi.Application.ApplicationConstants;
using Maxi.Application.Common;
using Maxi.Application.DTO.Product;
using Maxi.Application.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Maxiweb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _productService;
        protected APIResponse _apiResponse;

        public ProductController(IProductService productService)
        {
            _productService = productService;
            _apiResponse = new APIResponse();

        }

        [HttpGet]
        public async Task<ActionResult<APIResponse>> Get()
        {
            try
            {
                var data = await _productService.GetAllAsync();

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


        [HttpGet]
        [Route("Filter")]
        public async Task<ActionResult<APIResponse>> GetFilter(int? categoryId, int? brandId)
        {
            try
            {
                var data = await _productService.GetAllByFilterAsync(categoryId, brandId);

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



        [HttpGet]
        [Route("details")]
        public async Task<ActionResult<APIResponse>> Get(int id)
        {
            try
            {
                var mydata = await _productService.GetByIdAsync(id);

                if (mydata == null)
                {
                    _apiResponse.StatusCode = HttpStatusCode.NotFound;
                    _apiResponse.DisplayMessage = CommonMessage.CreateOperationFailed;
                    return NotFound();
                }
                _apiResponse.StatusCode = HttpStatusCode.OK;
                _apiResponse.IsSuccess = true;
                _apiResponse.DisplayMessage = CommonMessage.CreateOperationSuccess;
                _apiResponse.Result = mydata;
            }
            catch (Exception)
            {
                _apiResponse.StatusCode = HttpStatusCode.InternalServerError;
                _apiResponse.DisplayMessage = CommonMessage.CreateOperationFailed;
                _apiResponse.AddError(CommonMessage.SystemErr);

            }

            return Ok(_apiResponse);
        }



        [HttpPost]
        public async Task<ActionResult<APIResponse>> Create([FromBody] CreateProductDto obj)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                    _apiResponse.AddError(ModelState.ToString());
                }

                var data = await _productService.CreateAsync(obj);
                _apiResponse.StatusCode = HttpStatusCode.Created;
                _apiResponse.DisplayMessage = CommonMessage.CreateOperationSuccess;
                _apiResponse.IsSuccess = true;
                _apiResponse.Result = data;
            }
            catch (Exception)
            {
                _apiResponse.StatusCode = HttpStatusCode.InternalServerError;
                _apiResponse.AddError(CommonMessage.SystemErr);

            }

            return Ok(_apiResponse);
        }

        [HttpPut]
        public async Task<ActionResult<APIResponse>> Update([FromBody] UpdateProductDto obj)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                    _apiResponse.DisplayMessage = CommonMessage.UpdateOperationFailed;
                    _apiResponse.AddError(ModelState.ToString());
                }
                await _productService.UpdateAsync(obj);
                _apiResponse.StatusCode = HttpStatusCode.NoContent;
                _apiResponse.IsSuccess = true;
                _apiResponse.DisplayMessage = CommonMessage.UpdateOperationSuccess;



            }
            catch (Exception)
            {
                _apiResponse.StatusCode = HttpStatusCode.InternalServerError;
                _apiResponse.DisplayMessage = CommonMessage.UpdateOperationFailed;
                _apiResponse.AddError(CommonMessage.SystemErr);

            }

            return Ok(_apiResponse);



        }


        [HttpDelete]
        public async Task<ActionResult<APIResponse>> Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                    _apiResponse.DisplayMessage = CommonMessage.DeleteOperationFailed;
                    _apiResponse.AddError(ModelState.ToString());
                }

                var record = await _productService.GetByIdAsync(id);
                if (record == null)
                {
                    _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                    _apiResponse.DisplayMessage = CommonMessage.DeleteOperationFailed;
                    _apiResponse.AddError(ModelState.ToString());
                }
                await _productService.DeleteAsync(id);
                _apiResponse.StatusCode = HttpStatusCode.NoContent;
                _apiResponse.IsSuccess = true;
                _apiResponse.DisplayMessage = CommonMessage.deleteOperationSuccess;
            }
            catch (Exception)
            {

                _apiResponse.StatusCode = HttpStatusCode.InternalServerError;
                _apiResponse.DisplayMessage = CommonMessage.DeleteOperationFailed;
                _apiResponse.AddError(CommonMessage.SystemErr);
            }
            return Ok(_apiResponse);

        }
    }


}
