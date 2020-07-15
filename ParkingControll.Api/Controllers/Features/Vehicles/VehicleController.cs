using MediatR;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParkingControll.Application.Features.Vehicles.Handlers.Commands;
using ParkingControll.Application.Features.Vehicles.ViewModels;
using ParkingControll.Base;
using ParkingControll.Cfg.OData.Filters;
using ParkingControll.Domain.Features.Vehicles;
using System;
using System.Threading.Tasks;

namespace ParkingControll.Api.Controllers.Features.Vehicles
{
    [ApiController]
    [Route("vehicles")]
    public class VehicleController : ApiControllerBase
    {
        private IMediator _mediator;

        public VehicleController(IMediator mediator)
        {
            _mediator = mediator;
        }


        #region HTTP POST

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] VehicleCreateCommand priceCreate)
             => HandleCommand(await _mediator.Send(priceCreate));
        #endregion

        #region HTTP PATCH

        [HttpPatch("exit")]
        public async Task<IActionResult> PatchClient([FromBody]VehicleUpdateCommand command)
            => HandleCommand(await _mediator.Send(command));

        #endregion


        [HttpGet("with-values")]
        [ODataQueryOptionsValidate(AllowedQueryOptions.All)]
        public async Task<IActionResult> Amount([FromRoute] ODataQueryOptions<VehicleAmountViewModel> queryOptions)
            => await HandleQueryable<VehicleAmountViewModel, VehicleAmountViewModel>(await _mediator.Send(new VehicleAmountQuery()), queryOptions);


        [HttpGet("in-parking/today")]
        [ODataQueryOptionsValidate(AllowedQueryOptions.All)]
        public async Task<IActionResult> ReadAll([FromRoute] ODataQueryOptions<Vehicle> queryOptions)
            => await HandleQueryable<Vehicle, VehicleViewModel>(await _mediator.Send(new VehicleQueryAll(DateTime.Now)), queryOptions);
    }
}
