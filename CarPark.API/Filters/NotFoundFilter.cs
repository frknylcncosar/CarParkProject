using CarPark.API.DTOs;
using CarPark.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPark.API.Filters {

    public class NotFoundFilter : ActionFilterAttribute{
        private readonly ICarService _carService;
        public NotFoundFilter(ICarService carService) {
            _carService = carService;
        }
        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next) {
            int id = (int)context.ActionArguments.Values.FirstOrDefault();

            var car = await _carService.GetByIdAsync(id);
            if (car != null) {
                await next();//requesti bir sonraki adıma al devam et diyoruz yani
            }
            else {
                ErrorDto errorDto = new ErrorDto();
                errorDto.Status = 404;
                errorDto.Errors.Add($"{id} id'li araba otoparkta bulunamadı!");
                context.Result = new NotFoundObjectResult(errorDto);
            }
        }
    }
}
