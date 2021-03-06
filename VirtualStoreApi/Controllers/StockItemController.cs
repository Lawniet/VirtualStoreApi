
using VirtualStoreApi.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services;
using Application.Utils;
using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace VirtualStoreApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StockItemController : ApplicationBaseController<StockItemDTO>
    {
        private readonly IStockItemService _storeService;

        public StockItemController(IStockItemService storeService, IMapper mapper, ILogger<StockItemController> logger)
            : base(mapper, logger)
        {
            _storeService = storeService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetById(int id)
        {
            IApplicationResponse result = new ApplicationResponse();

            try
            {
                var product = _storeService.GetById(id);
                var dto = _mapper.Map<StockItemDTO>(product);
                var response = ReturnSuccessResponse(dto);
                return SetStatusCodeForSearch(response);
            }
            catch (Exception e)
            {
                AddUserFriendlyErrorMessage(result);
                _logger.LogError($"Ocorreu um erro interno: { e.Message } {e.StackTrace}");
                return StatusCode(StatusCodes.Status500InternalServerError, ReturnApiResponse(result));
            }
        }

        [HttpPost]
        [Authorize]
        public IActionResult Save(StockItemDTO stockItem)
        {
            IApplicationResponse result = new ApplicationResponse();

            if (stockItem.Id != 0)
            {
                result.IsValid = false;
                result.Messages = new List<string>() { "Não se pode adicionar um item de estoque especificando um Id." };

                return BadRequest(result);
            }

            try
            {
                result = _storeService.Save(stockItem.ToEntity());
                return SetStatusCode(result);
            }
            catch (Exception e)
            {
                AddUserFriendlyErrorMessage(result);
                LogError(e);
                return StatusCode(StatusCodes.Status500InternalServerError, ReturnApiResponse(result));
            }
        }

        [HttpPut]
        [Authorize]
        public IActionResult Update(StockOperation stockOperation)
        {
            IApplicationResponse result = new ApplicationResponse();

            try
            {
                result = _storeService.UpdateStock(stockOperation);
                return SetStatusCode(result);
            }
            catch (Exception e)
            {
                AddUserFriendlyErrorMessage(result);
                LogError(e);
                return StatusCode(StatusCodes.Status500InternalServerError, ReturnApiResponse(result));
            }
        }
    }
}
