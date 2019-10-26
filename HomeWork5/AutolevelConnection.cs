using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace HomeWork5
{
    public class AutolevelConnection
    {
        private DataTable Orders { get; set; }
        private DataTable Employees { get; set; }
        private DataTable Customers { get; set; }
        private DataTable OrderDetails { get; set; }
        private DataTable Products { get; set; }
        private readonly DbProviderFactory providerFactory;
        private DbConnection connection;

        public AutolevelConnection(string connectionString, string providerInvariantName)
        {
            providerFactory = DbProviderFactories.GetFactory(providerInvariantName);
            connection = providerFactory.CreateConnection();
            connection.ConnectionString = connectionString;
        }

        public void Action()
        {
            var dataSet = new DataSet("ShopDb"); // Название БД

            OrdersTable();
            CustomersTable();
            EmployeesTable();
            OrderDetailsTable();
            ProductsTable();

            dataSet.Tables.AddRange(new DataTable[] { Orders, Customers, Employees, OrderDetails, Products });

            dataSet.Relations.Add("Employees_Orders", Employees.Columns["Id"], Orders.Columns["EmployeeId"]);
            dataSet.Relations.Add("Cutomers_Orders", Customers.Columns["Id"], Orders.Columns["CustomerId"]);
            dataSet.Relations.Add("Orders_OrderDetails", Orders.Columns["Id"], OrderDetails.Columns["OrderId"]);
            dataSet.Relations.Add("Products_OrderDetails", Products.Columns["Id"], OrderDetails.Columns["ProductId"]);
            dataSet.AcceptChanges();
        }

        private void OrdersTable()
        {
            Orders = new DataTable("Orders");
            Orders.Columns.Add(new DataColumn
            {
                ColumnName = "Id",
                AutoIncrement = true,
                AutoIncrementSeed = 1,
                AutoIncrementStep = 1,
                Unique = true,
                DataType = typeof(int),
            });
            Orders.PrimaryKey = new DataColumn[] { Orders.Columns["Id"] };

            Orders.Columns.Add(new DataColumn
            {
                ColumnName = "CustomerId",
                Unique = false,
                AllowDBNull = false,
                DataType = typeof(int)
            });
            Orders.Columns.Add(new DataColumn
            {
                ColumnName = "EmployeeId",
                Unique = false,
                AllowDBNull = false,
                DataType = typeof(int)
            });
            Orders.Columns.Add(new DataColumn
            {
                ColumnName = "OrderDate",
                Unique = false,
                AllowDBNull = false,
                DataType = typeof(DateTime)
            });
        }

        private void EmployeesTable()
        {
            Employees = new DataTable("Employees");
            Employees.Columns.Add(new DataColumn
            {
                ColumnName = "Id",
                AutoIncrement = true,
                AutoIncrementSeed = 1,
                AutoIncrementStep = 1,
                Unique = true,
                DataType = typeof(int),
            });
            Employees.PrimaryKey = new DataColumn[] { Employees.Columns["Id"] };

            Employees.Columns.Add(new DataColumn
            {
                ColumnName = "FirstName",
                Unique = false,
                AllowDBNull = false,
                DataType = typeof(string)
            });
            Employees.Columns.Add(new DataColumn
            {
                ColumnName = "LastName",
                Unique = false,
                AllowDBNull = false,
                DataType = typeof(string)
            });
        }

        private void CustomersTable()
        {
            Customers = new DataTable("Customers");
            Customers.Columns.Add(new DataColumn
            {
                ColumnName = "Id",
                AutoIncrement = true,
                AutoIncrementSeed = 1,
                AutoIncrementStep = 1,
                Unique = true,
                DataType = typeof(int),
            });
            Customers.PrimaryKey = new DataColumn[] { Customers.Columns["Id"] };

            Customers.Columns.Add(new DataColumn
            {
                ColumnName = "FirstName",
                Unique = false,
                AllowDBNull = false,
                DataType = typeof(string)
            });
            Customers.Columns.Add(new DataColumn
            {
                ColumnName = "LastName",
                Unique = false,
                AllowDBNull = false,
                DataType = typeof(string)
            });
        }

        private void ProductsTable()
        {
            Products = new DataTable("Products");
            Products.Columns.Add(new DataColumn
            {
                ColumnName = "Id",
                AutoIncrement = true,
                AutoIncrementSeed = 1,
                AutoIncrementStep = 1,
                Unique = true,
                DataType = typeof(int),
            });
            Products.PrimaryKey = new DataColumn[] { Products.Columns["Id"] };

            Products.Columns.Add(new DataColumn
            {
                ColumnName = "ProductName",
                Unique = false,
                AllowDBNull = false,
                DataType = typeof(string)
            });
        }

        private void OrderDetailsTable()
        {
            OrderDetails = new DataTable("OrderDetails");
            OrderDetails.Columns.Add(new DataColumn
            {
                ColumnName = "OrderId",
                AutoIncrement = true,
                AutoIncrementSeed = 1,
                AutoIncrementStep = 1,
                Unique = true,
                DataType = typeof(int),
            });
            OrderDetails.PrimaryKey = new DataColumn[] { OrderDetails.Columns["OrderId"] };

            OrderDetails.Columns.Add(new DataColumn
            {
                ColumnName = "ProductId",
                Unique = false,
                AllowDBNull = false,
                DataType = typeof(int)
            });
            OrderDetails.Columns.Add(new DataColumn
            {
                ColumnName = "Price",
                Unique = false,
                AllowDBNull = false,
                DataType = typeof(int)
            });
        }
    }
}
