using System.Collections;
using System.Data.SqlClient;
using Dapper;
using DapperFundamental;

public class Program
{
    public static void Main(string[] args)
    {
        /*
         * Dapper adalah ORM (micro ORM) yang memungkinkan kita untuk mengakses data lebih cepat dan
         * memapping object
         *
         * Keunggulan Dapper
         * - Dapper ringan dan cepat
         * - Dapper ini mudah digunakan dan object mapping yang powerful
         * - Dapper mendukung yang namanya parameterized queries yang membantu kita untuk menghindari yang namanya
         *  SQL Injection
         *
         * Tujuan utama Dapper me-mapping query ke object
         *
         * Dapper RDBMS (Provider): SQL Server, Oracle, PostgreSQL, MySQL
         *
         *
         * Extensions Method: Membuat function/method didalam suatu class tanpa merubah isi dari class tersebut
         */

        /*
         * 4 Method exetension IDBConnection:
         * - Query (DQL)
         * - Execute (DDL, DML)
         * - ExecuteScalar (DML, DQL) - Mengembalikan satu record dan satu column
         * - ExecuteReader (DQL)
         */

        // Implementasi dari IDBConnection
        using var connection =
            new SqlConnection("server=localhost,1433;user=sa;password=Password123;database=enigma_shop");
        DefaultTypeMap.MatchNamesWithUnderscores = true;

        // Using Dapper

        // var sql = @"
        //     CREATE TABLE m_product
        //     (
        //        id int identity primary key,
        //        product_name varchar(100),
        //        product_price bigint,
        //        stock int,
        //     )";
        // var sql = "INSERT INTO m_product (product_name, product_price, stock) VALUES ('Sepatu', 250000, 10)";
        // connection.Execute(sql);

        /*Native ADO.NET*/
        // connection.Open();
        // var command = new SqlCommand(sql, connection);
        // command.ExecuteNonQuery();

        // var sql = "SELECT * FROM m_product";
        // IEnumerable -> LINQ (Bahasa Query tapi di pakai di C#)
        /*
        var products = connection.Query<Product>(sql).ToList();
        foreach (var product in products)
        {
            Console.WriteLine(product);
        }
        */

        /*
         * Menampilkan Single Data
         * - QuerySingle - Dynamic              = Mengembalikan satu data berupa dynamic - Exception saat query kosong atau data bisa lebih dari satu
         * - QuerySingle<T>
         * - QuerySingleOrDefault - Dynamic     = Mengembalikan satu data berupa dynamic - Exception saat query lebih dari satu data, kalau query kosong akan return null
         * - QuerySingleOrDefault<T>
         * - QueryFirst - Dynamic               = Mengembalikan satu data berupa dynamic - Exception saat query itu kosong
         * - QueryFirst<T>
         * - QueryFirstOrDefault - Dynamic      = Mengembalikan satu data berupa dynamic - tidak mengembalikan exception apapun, kalau query kosong akan return null
         * - QueryFirstOrDefault<T>
         * 
        var sql = "SELECT * FROM m_product WHERE id = 1";
        var product = connection.QueryFirstOrDefault<Product>(sql);
        Console.WriteLine(product);
         */

        /* Execute Scalar
         var sql = "SELECT product_name FROM m_product";
        var count = connection.ExecuteScalar<string>(sql);
        Console.WriteLine(count);*/

        /*
         * Execute Reader
          var sql = "SELECT * FROM m_product";
        var reader = connection.ExecuteReader(sql);

        while (reader.Read())
        {
         Console.WriteLine(new Product
         {
          Id = Convert.ToInt32(reader["id"]),
          ProductName = reader["product_name"].ToString(),
          ProductPrice = Convert.ToInt64(reader["product_price"]),
          Stock = Convert.ToInt32(reader["stock"])
         });
        }
         */

        /*
         * Parameterize Dapper - Sql Server itu menggunakan @
         * - Anonymous Parameters
         * - Dynamic Parameters
         * var product = new Product
        {
         ProductName = "Tas",
         ProductPrice = 100000,
         Stock = 15
        };

        // Anonymous Parameter with Anonymous Object
        var productParams = new
        {
         productName = product.ProductName,
         productPrice = product.ProductPrice,
         stock = product.Stock
        };

        // Dynamic Parameters
        var dynamicParameters = new DynamicParameters(product);

        var sql = "INSERT INTO m_product (product_name, product_price, stock) VALUES (@productName, @productPrice, @stock)";
        connection.Execute(sql, product);
         */

        var sql = "SELECT * FROM m_product WHERE product_price > @productPrice";
        var products = connection.Query<Product>(sql, new
        {
            productPrice = 100000
        }).ToList();
        
        products.ForEach(Console.WriteLine);
        
    }
}