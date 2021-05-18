using AW.Domain.Core;
using AW.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFShopService.Services
{
    public class SalesTerritoryService : ISalesTerritoryService
    {
        private IRepository<SalesTerritory> repository;
        public SalesTerritoryService(IRepository<SalesTerritory> repository)
        {
            this.repository = repository;
        }

        public List<string> GetList()
        {
            var result = repository.GetList().Select(x => x.CountryRegionCode).Distinct().ToList();
            return result;
        }
    }
}
