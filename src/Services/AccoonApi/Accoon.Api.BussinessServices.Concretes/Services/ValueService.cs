﻿using Accoon.Api.BussinessServices.Entities.EntityDTOs;
using Accoon.Api.BussinessServices.Interfaces.Services;
using Accoon.Api.DataServices.Entities;
using Accoon.Api.DataServices.Interfaces.Repositories;
using Accoon.BuildingBlocks.Common.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Accoon.Api.BussinessServices.Concretes.Services
{
    public class ValueService : IValueService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<AccoonDbContext> _unitOfWork;
        private readonly IValueRepository _valueRepository;

        public ValueService(IMapper mapper, IUnitOfWork<AccoonDbContext> unitOfWork, IValueRepository valueRepository)
        {
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
            this._valueRepository = valueRepository;
        }
        public Task<ValueDTO> TestValueServiceMethod()
        {
            var valueEntity = this._valueRepository.TestValueMethod();
            var dto = this._mapper.Map<ValueDTO>(valueEntity);
            return Task.FromResult<ValueDTO>( dto);
        }
    }
}
