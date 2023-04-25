﻿namespace ProjAPICustomer.Config
{
    public interface IProjCustomerSettings
    {
        string CustomerCollectionName { get; set; }
        string AddressCollectionName { get; set; }
        string CityCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
