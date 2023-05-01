﻿using System;
using PackIT.Domain.Consts;
using System.Xml.Linq;
using PackIT.Domain.Factories;
using PackIT.Domain.Repositories;
using PackIT.Domain.ValueObjects;
using PackIT.Shared.Abstractions.Commands;
using PackIT.Application.Exceptions;
using PackIT.Application.Services;

namespace PackIT.Application.Commands.Handlers
{
    internal sealed class CreatePackingListWIthItemsHandler : ICommandHandler<CreatePackingListWIthItems>
    {
        private readonly IPackingListFactory _packingListFactory;
        private readonly IPackingListRepository _packingListRepository;
        private readonly IPackingListReadService _packingListReadService;
        private readonly IWeatherService _weatherService;

        public CreatePackingListWIthItemsHandler(IPackingListFactory packingListFactory, IPackingListRepository packingListRepository, IPackingListReadService packingListReadService, IWeatherService weatherService)
        {
            _packingListFactory = packingListFactory;
            _packingListRepository = packingListRepository;
            _packingListReadService = packingListReadService;
            _weatherService = weatherService;
        }

        public async Task HandleAsync(CreatePackingListWIthItems command)
        {
            var (id, name, days, gender, localizationWriteModel) = command;

            var exists = await _packingListReadService.ExistsByNameAsync(name);

            if (exists)
            {
                throw new PackingListAlreadyExistsException(name);
            }

            var localization = new Localization(localizationWriteModel.City, localizationWriteModel.Country);
            var weather = await _weatherService.GetWeatherAsync(localization);

            if (weather is null)
            {
                throw new MissingLocalizationWeatherException(localization);
            }

            var packingList = _packingListFactory
                .CreateWithDefaultItems(id, name, days, gender, weather.Temperature, localization);

            await _packingListRepository.AddAsync(packingList);
        }
    }
}