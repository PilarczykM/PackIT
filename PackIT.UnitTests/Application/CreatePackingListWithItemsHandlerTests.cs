using NSubstitute;
using PackIT.Application.Commands;
using PackIT.Application.Commands.Handlers;
using PackIT.Application.DTO.External;
using PackIT.Application.Exceptions;
using PackIT.Application.Services;
using PackIT.Domain.Consts;
using PackIT.Domain.Entity;
using PackIT.Domain.Factories;
using PackIT.Domain.Repositories;
using PackIT.Domain.ValueObjects;
using PackIT.Shared.Abstractions.Commands;

namespace PackIT.UnitTests.Application
{
    public class CreatePackingListWithItemsHandlerTests
    {
        Task Act(CreatePackingListWIthItems command)
            => _commandHandler.HandleAsync(command);

        #region ARRANGE
        private readonly ICommandHandler<CreatePackingListWIthItems> _commandHandler;
        private readonly IPackingListRepository _repository;
        private readonly IWeatherService _weatherService;
        private readonly IPackingListReadService _readService;
        private readonly IPackingListFactory _factory;

        public CreatePackingListWithItemsHandlerTests()
        {
            _repository = Substitute.For<IPackingListRepository>();
            _weatherService = Substitute.For<IWeatherService>();
            _readService = Substitute.For<IPackingListReadService>();
            _factory = Substitute.For<IPackingListFactory>();

            _commandHandler = new CreatePackingListWIthItemsHandler(_factory, _repository, _readService, _weatherService);
        }
        #endregion

        [Fact]
        public async Task HandleAsync_Throws_PackingListAlreadyExistsException_When_List_With_Same_Name_Already_Exists()
        {
            //ARRANGE
            var command = new CreatePackingListWIthItems(Guid.NewGuid(), "Item 1", 10, Gender.Male, default);
            _readService.ExistsByNameAsync(command.Name).Returns(true);

            //ACT
            var exception = await Record.ExceptionAsync(() => Act(command));

            //ASSERTION
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<PackingListAlreadyExistsException>();
        }

        [Fact]
        public async Task HandleAsync_Throws_MissingLocalizationWeatherException_When_Weather_Is_Not_returned_From_Service()
        {
            //ARRANGE
            var command = new CreatePackingListWIthItems(Guid.NewGuid(), "Item 1", 10, Gender.Male,
                new LocalizationWriteModel("Gdansk", "Poland"));
            _readService.ExistsByNameAsync(command.Name).Returns(false);
            _weatherService.GetWeatherAsync(Arg.Any<Localization>()).Returns(default(WeatherDto));

            //ACT
            var exception = await Record.ExceptionAsync(() => Act(command));

            //ASSERT
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<MissingLocalizationWeatherException>();
        }

        [Fact]
        public async Task HandleAsync_Calls_Repository_On_Success()
        {
            //ARRANGE
            var command = new CreatePackingListWIthItems(Guid.NewGuid(), "Item 1", 10, Gender.Female,
                new LocalizationWriteModel("Gdansk", "Poland"));

            _readService.ExistsByNameAsync(command.Name).Returns(false);
            _weatherService.GetWeatherAsync(Arg.Any<Localization>()).Returns(new WeatherDto(25));
            _factory.CreateWithDefaultItems(command.Id, command.Name, command.Days, command.Gender,
                Arg.Any<Temperature>(), Arg.Any<Localization>()).Returns(default(PackingList));

            //ACT
            var exception = await Record.ExceptionAsync(() => Act(command));

            //ASSERT
            exception.ShouldBeNull();
            await _repository.Received(1).AddAsync(Arg.Any<PackingList>());
        }
    }
}

