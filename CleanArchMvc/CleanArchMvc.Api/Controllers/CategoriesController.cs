﻿using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> Get()
        {
            var categories = await _categoryService.GetCategoriesAsync();

            if (categories == null || !categories.Any())
            {
                return NotFound("Categories not found.");
            }

            return Ok(categories);
        }

        [HttpGet("{id:int}", Name = "GetCategory")]
        public async Task<ActionResult<CategoryDto>> Get(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);

            if (category == null)
            {
                return NotFound("Category not found.");
            }

            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoryDto category)
        {
            if (category == null)
            {
                return BadRequest("Invalid Data.");
            }

            await _categoryService.AddAsync(category);

            return new CreatedAtRouteResult("GetCategory", new { id = category.Id }, category);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] CategoryDto category)
        {
            if (category == null)
            {
                return BadRequest("Invalid Data.");
            }

            await _categoryService.UpdateAsync(category);

            return Ok(category);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);

            if (category == null)
            {
                return BadRequest("Category Not Found.");
            }
            else
            {
                await _categoryService.DeleteAsync(id);

                return Ok();
            }
        }
    }
}
