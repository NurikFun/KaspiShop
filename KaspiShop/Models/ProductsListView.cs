﻿using AW.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KaspiShop.Models
{
    public class ProductsListView
    {
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
        public string SubCategory { get; set; }
        public IEnumerable<ProductCatalog> ProductCatalog { get; set; }
       
    }
}