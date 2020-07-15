using MediatR;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParkingControll.Application.Features.PriceAggregation.Handlers.Commands;
using ParkingControll.Application.Features.PriceAggregation.ViewModels;
using ParkingControll.Base;
using ParkingControll.Cfg.OData.Filters;
using ParkingControll.Domain.Features.PriceAggregation;
using System;
using System.Threading.Tasks;

namespace ParkingControll.Controllers.Features
{
    [ApiController]
    [Route("prices")]
    public class PriceController : ApiControllerBase
    {
        private IMediator _mediator;

        public PriceController(IMediator mediator)
        {
            _mediator = mediator;
        }


        #region HTTP POST

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PriceCreateCommand priceCreate)
             => HandleCommand(await _mediator.Send(priceCreate));
        #endregion


        [HttpGet]
        [ODataQueryOptionsValidate(AllowedQueryOptions.All)]
        public async Task<IActionResult> ReadAll([FromRoute] DateTime period,[FromRoute] ODataQueryOptions<Price> queryOptions)
            => await HandleQueryable<Price, PriceViewModel>(await _mediator.Send(new PriceQueryAll(period)), queryOptions);
    }
}
