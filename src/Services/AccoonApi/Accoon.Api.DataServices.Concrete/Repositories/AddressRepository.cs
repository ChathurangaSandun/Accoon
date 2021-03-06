﻿using Accoon.Api.DataServices.Entities;
using Accoon.Api.DataServices.Entities.CustomEntities;
using Accoon.Api.DataServices.Interfaces.Repositories;
using Accoon.BuildingBlocks.Common.Concretes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Accoon.Api.DataServices.Concrete.Repositories
{
    public class AddressRepository : RepositoryBase<AccoonDbContext, AddressEntity, int>, IAddressRepository
    {
        public AddressRepository(AccoonDbContext dbContext) : base(dbContext)
        {
        }
    }
}
