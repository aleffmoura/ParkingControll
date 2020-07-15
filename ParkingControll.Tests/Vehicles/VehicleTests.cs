using FluentAssertions;
using MediatR;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using ParkingControll.Api.Behavious;
using ParkingControll.Api.Controllers.Features.Vehicles;
using ParkingControll.Api.Extensions;
using ParkingControll.Application.Features.PriceAggregation.Services;
using ParkingControll.Application.Features.Vehicles.Handlers.Commands;
using ParkingControll.Application.Features.Vehicles.ViewModels;
using ParkingControll.Cfg.Mappers.Extensions;
using ParkingControll.Domain.Enums;
using ParkingControll.Domain.Exceptions;
using ParkingControll.Domain.Features.PriceAggregation;
using ParkingControll.Domain.Features.Vehicles;
using ParkingControll.Exceptions;
using ParkingControll.Infra.CrossCutting.Structs;
using ParkingControll.Tests.ObjectMothers;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unit = ParkingControll.Infra.CrossCutting.Structs.Unit;

namespace ParkingControll.Tests.Vehicles
{
    [TestFixture]
    public class VehicleTests
    {
        private List<Vehicle> _repositoryVehicle = new List<Vehicle>();
        private IMediator _mediator;
        private readonly Container _container = new Container();
        private ServiceProvider _serviceProvider;
        private Mock<IPriceRepository> _priceRepositoryMock;
        private Mock<IVehicleRepository> _vehicleRepositoryMock;


        public VehicleTests()
        {
            _priceRepositoryMock = new Mock<IPriceRepository>();

            _priceRepositoryMock.Setup(v => v.GetByDateAsync(It.IsAny<DateTime>()))
                                   .Returns(Task.Run<Option<Exception, Price>>(() => PriceMother.Price));


            _vehicleRepositoryMock = new Mock<IVehicleRepository>();

            _vehicleRepositoryMock.Setup(v => v.GetByPlateAsync(VehicleMother.CreateCommandDuplicatePlate.Plate))
                                   .Returns(Task.Run<Option<Exception, Vehicle>>(() => _repositoryVehicle.FirstOrDefault() ?? VehicleMother.ValidNoExited));

            _vehicleRepositoryMock.Setup(v => v.GetByPlateAsync(VehicleMother.CreateCommand.Plate))
                                   .Returns(Task.Run<Option<Exception, Vehicle>>(() => new Exception()));

            _vehicleRepositoryMock.Setup(v => v.CreateAsync(It.IsAny<Vehicle>()))
                                   .Returns(Task.Run<Option<Exception, Vehicle>>(() => VehicleMother.ValidNoExited))
                                   .Callback<Vehicle>(cbVehicle =>
                                   {
                                       _repositoryVehicle.Add(VehicleMother.ValidNoExited);
                                   });

            _vehicleRepositoryMock.Setup(v => v.UpdateAsync(It.IsAny<Vehicle>()))
                                   .Returns(Task.Run<Option<Exception, Unit>>(() => Unit.Successful))
                                   .Callback<Vehicle>(cbVehicle =>
                                   {
                                       _repositoryVehicle.Clear();
                                       _repositoryVehicle.Add(cbVehicle);
                                   });


            IServiceCollection services = new ServiceCollection();
            services.AddSimpleInjector(_container);
            services.AddOData();
            services.AddAutoMapper(typeof(Application.Module));



            _container.Register<IPriceRepository>(() => _priceRepositoryMock.Object);
            _container.Register<IVehicleRepository>(() => _vehicleRepositoryMock.Object);

            _container.Register(() => new PriceLogicService());

            services.AddMediator(_container);
            services.AddValidators(_container);
            services.AddMvcCore(options => options.Filters.Add(new ExceptionHandlerAttribute()));

            _serviceProvider = services.BuildServiceProvider();
            _mediator = _container.GetInstance<IMediator>();
        }

        [Test]
        [Order(0)]
        public void Vehicle_Add_WithoutPrice_SholdBe_Exception()
        {
            //arrange
            VehicleController vehicleController = new VehicleController(_mediator);

            //action
            ObjectResult result = (ObjectResult)vehicleController.Create(VehicleMother.CreateCommandDuplicatePlate).ConfigureAwait(false).GetAwaiter().GetResult();

            //verify
            result.StatusCode.Should().Be((int)ErrorCodes.AlreadyExists);
            result.Value.Should().BeOfType<ExceptionPayload>();
            _vehicleRepositoryMock.Verify(v => v.GetByPlateAsync(VehicleMother.CreateCommandDuplicatePlate.Plate));
            _vehicleRepositoryMock.VerifyNoOtherCalls();
        }

        [Test]
        [Order(1)]
        public void Vehicle_Add_ShouldBe_Ok()
        {
            //arrange
            VehicleController vehicleController = new VehicleController(_mediator);


            //action
            ObjectResult result = (ObjectResult)vehicleController.Create(VehicleMother.CreateCommand).ConfigureAwait(false).GetAwaiter().GetResult();

            //verify
            result.StatusCode.Should().Be(200);
            _repositoryVehicle.Count.Should().Be(expected: 1);
            result.Value.Should().Be(VehicleMother.ValidNoExited.Id);
            _vehicleRepositoryMock.Verify(v => v.GetByPlateAsync(VehicleMother.CreateCommand.Plate));
            _vehicleRepositoryMock.Verify(v => v.CreateAsync(It.IsAny<Vehicle>()));
            _vehicleRepositoryMock.VerifyNoOtherCalls();
        }

        [Test]
        [Order(2)]
        public void Vehicle_Exit_LessThan30Min_ShouldBe_Ok()
        {
            //arrange
            VehicleController vehicleController = new VehicleController(_mediator);


            //action
            ObjectResult result = (ObjectResult)vehicleController.PatchClient(VehicleMother.UpdateCommand).ConfigureAwait(false).GetAwaiter().GetResult();

            //verify
            result.StatusCode.Should().Be(200);
            _repositoryVehicle.Count.Should().Be(expected: 1);
            result.Value.Should().Be(Unit.Successful);
            _vehicleRepositoryMock.Verify(v => v.GetByPlateAsync(VehicleMother.ValidNoExited.Plate));
            _vehicleRepositoryMock.Verify(v => v.UpdateAsync(It.IsAny<Vehicle>()));
            _vehicleRepositoryMock.VerifyNoOtherCalls();
            _repositoryVehicle.FirstOrDefault().Price.Should().Be(expected: PriceMother.Price.Value);
            _repositoryVehicle.FirstOrDefault().TotalTimePaid.Should().Be(expected: "30 min");
            _repositoryVehicle.FirstOrDefault().AmountPaid.Should().Be(expected: $"R$ {PriceMother.Price.Value / 2}");
        }
        [Test]
        [Order(3)]
        public void Vehicle_Exit_GreatherThan30Min_ShouldBe_Ok()
        {
            //arrange
            _repositoryVehicle.Clear();
            VehicleController vehicleController = new VehicleController(_mediator);
            vehicleController.Create(VehicleMother.CreateCommand).ConfigureAwait(false).GetAwaiter().GetResult();
            _repositoryVehicle.FirstOrDefault().AmountPaid = null;
            _repositoryVehicle.FirstOrDefault().TotalTimeInParking = null;
            _repositoryVehicle.FirstOrDefault().TotalTimePaid = null;
            _repositoryVehicle.FirstOrDefault().Price = 0;
            _repositoryVehicle.FirstOrDefault().CameIn = _repositoryVehicle.FirstOrDefault().CameIn.AddMinutes(-35);

            //action
            ObjectResult result = (ObjectResult)vehicleController.PatchClient(VehicleMother.UpdateCommand).ConfigureAwait(false).GetAwaiter().GetResult();

            //verify
            result.StatusCode.Should().Be(200);
            _repositoryVehicle.Count.Should().Be(expected: 1);
            result.Value.Should().Be(Unit.Successful);
            _vehicleRepositoryMock.Verify(v => v.CreateAsync(It.IsAny<Vehicle>()));
            _vehicleRepositoryMock.Verify(v => v.GetByPlateAsync(VehicleMother.ValidNoExited.Plate));
            _vehicleRepositoryMock.Verify(v => v.GetByPlateAsync(VehicleMother.CreateCommand.Plate));
            _vehicleRepositoryMock.Verify(v => v.UpdateAsync(It.IsAny<Vehicle>()));
            _vehicleRepositoryMock.VerifyNoOtherCalls();
            _repositoryVehicle.FirstOrDefault().Price.Should().Be(expected: PriceMother.Price.Value);
            _repositoryVehicle.FirstOrDefault().TotalTimePaid.Should().Be(expected: "1 hrs");
            _repositoryVehicle.FirstOrDefault().AmountPaid.Should().Be(expected: $"R$ {PriceMother.Price.Value}");
        }

        [Test]
        [Order(4)]
        public void Vehicle_Exit_OneHourAnd15_ShouldBe_Ok()
        {
            //arrange
            _repositoryVehicle.Clear();
            VehicleController vehicleController = new VehicleController(_mediator);
            vehicleController.Create(VehicleMother.CreateCommand).ConfigureAwait(false).GetAwaiter().GetResult();
            _repositoryVehicle.FirstOrDefault().AmountPaid = null;
            _repositoryVehicle.FirstOrDefault().TotalTimeInParking = null;
            _repositoryVehicle.FirstOrDefault().TotalTimePaid = null;
            _repositoryVehicle.FirstOrDefault().Price = 0;
            _repositoryVehicle.FirstOrDefault().CameIn = _repositoryVehicle.FirstOrDefault().CameIn.AddMinutes(-75);

            //action
            ObjectResult result = (ObjectResult)vehicleController.PatchClient(VehicleMother.UpdateCommand).ConfigureAwait(false).GetAwaiter().GetResult();

            //verify
            result.StatusCode.Should().Be(200);
            _repositoryVehicle.Count.Should().Be(expected: 1);
            result.Value.Should().Be(Unit.Successful);
            _vehicleRepositoryMock.Verify(v => v.CreateAsync(It.IsAny<Vehicle>()));
            _vehicleRepositoryMock.Verify(v => v.GetByPlateAsync(VehicleMother.ValidNoExited.Plate));
            _vehicleRepositoryMock.Verify(v => v.GetByPlateAsync(VehicleMother.CreateCommand.Plate));
            _vehicleRepositoryMock.Verify(v => v.UpdateAsync(It.IsAny<Vehicle>()));
            _vehicleRepositoryMock.VerifyNoOtherCalls();
            _repositoryVehicle.FirstOrDefault().Price.Should().Be(expected: PriceMother.Price.Value);
            _repositoryVehicle.FirstOrDefault().TotalTimePaid.Should().Be(expected: $"2 hrs");
            _repositoryVehicle.FirstOrDefault().AmountPaid.Should().Be(expected: $"R$ {PriceMother.Price.Value + PriceMother.Price.Additional}");
        }
    }
}
