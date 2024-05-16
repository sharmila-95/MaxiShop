using Maxi.Application.Common;
using Maxi.Application.DTO.Category;
using Maxi.Application.Services.Interface;
using Maxi.Domain;
using Maxi.Domain.Contracts;
using Maxi.Infrastructure.DbContexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Net;

namespace Maxiweb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        protected APIResponse _apiResponse;
        
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService=categoryService;
            _apiResponse = new APIResponse();
        
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<APIResponse>> Get()
        {
            try
            {
                var data = await _categoryService.GetAllAsync();

                _apiResponse.StatusCode = HttpStatusCode.OK;
                _apiResponse.Result = data;
            }
            catch (Exception ex)
            {
                _apiResponse.AddError(ex.Message.ToString());
                throw;
            }

           

            return (_apiResponse);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        [Route("details")]
        public async Task<IActionResult> Get(int id) 
        {

            var mydata = await _categoryService.GetByIdAsync(id);

            if(mydata==null)
            {
                return NotFound();
            }
            return Ok(mydata);
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody]CreateCategoryDto obj)
        {
            if(!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }
            await _categoryService.CreateAsync(obj);
            return Ok();

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        public async Task<ActionResult> Update([FromBody]UpdateCategoryDto obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
                await _categoryService.UpdateAsync(obj);
            return Ok();

        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            if (id==0)
            {
                return BadRequest("please enter id");
            }

            var record=await _categoryService.GetByIdAsync(id);
            if(record==null)
            {
                return NotFound("Record not in the list");
            }
           await _categoryService.DeleteAsync(id);
            return Ok();

        }



    }
}
