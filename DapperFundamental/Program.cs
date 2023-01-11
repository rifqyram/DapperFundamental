namespace DapperFundamental;

public class Program
{
    public static void Main(string[] args)
    {
        /*
         * LINQ -> Language-Integrated Query
         * LINQ ini mendukung banyak data source:
         * - In Memory Object (List, Array)
         * - ADO.NET (DataSet)
         * - Entity Framework
         * - SQL Server
         * - XML Document
         * - Data Source lain-lain
         *
         * Linq Providers
         * - LINQ to Objects
         * - LINQ to Entities
         * - LINQ to XML
         * - LINQ to SQL
         * - LINQ to DataSet
         * dll
         */

        /*
         * 3 hal untuk membuat query LINQ
         * - Data Source (SQL, In Memory Object, XML)
         * - Query (SELECT blablabla)
         * - Execution of the query
         *
         * Kombinasi Query yang kita perlu ketahui:
         * - Query Syntax
         * - Method Syntax
         * - Mixed Syntax
         */

        /*
         * Query Syntax
         * from object in datasource // inisialisasi
         * where condition // kondisi
         * select object // seleksi
         */

        // numbers -> datasource (in memory objects)
        var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        var filteredNumber =
            from number in numbers //inisialisasi
            where number > 5 // kondisi
            orderby number descending
            select number; // seleksi

        /*
         * Method Syntax
         * Datasource.ConditionMethod().SelectionMethod()
         * inisialisasi -- kondisi   --   seleksi
         */

        var evenNumbers = numbers.Where(number => number % 2 == 0).OrderByDescending(i => i);

        var products = new List<Product>
        {
            new() { Id = 1, ProductName = "Hoodie", ProductPrice = 100000, Stock = 10 },
            new() { Id = 2, ProductName = "Kemeja", ProductPrice = 150000, Stock = 10 },
            new() { Id = 3, ProductName = "Celana", ProductPrice = 100000, Stock = 10 },
            new() { Id = 4, ProductName = "Sepatu", ProductPrice = 300000, Stock = 10 },
        };

        var querySyntaxProducts =
            from product in products
            orderby product.ProductName
            select product.ProductName;

        var methodSyntaxProducts =
            products.Where(product => product.ProductPrice > 100000).Select(product => product.ProductName);

        // pagination menggunakan linq
        var page = 2;
        var size = 2;

        var productsPage = products.Page(page, size);

        // Console.WriteLine($"Page {page}");
        // foreach (var product in productsPage)
        // {
        //     Console.WriteLine(product);
        // }

        /*
         * Mixed Syntax
         */

        // var filteredProducts =
        //     (from product in products
        //         where product.ProductPrice is > 100000 and < 2500000
        //         select product).OrderByDescending(p => p.ProductName);
        //
        // foreach (var i in filteredProducts)
        // {
        //     Console.WriteLine(i);
        // }
        
    }
}

public static class MyExtensionMethod
{
    public static int Plus(this int value, int parameter)
    {
        return value + parameter;
    }

    public static IEnumerable<T> Page<T>(this IEnumerable<T> dataSource, int page, int size)
    {
        return dataSource.Skip((page - 1) * size).Take(size);
    } 



}













/*/*
         * Lambda Expression
         * Didefinisikan dalam bahasa pemrograman adalah anonymous function, yang artinya method/function tanpa nama
         *
         * 2 Tipe Lambda Expression yang digunakan di C#:
         * - Lambda Expression: dimana body nya sebaga expression
         * - Statement Lambda: dimana memiliki block code sebagai body nya.
         #1#

        // Anonymous function / Lambda Exression
        var square = (int x) => x * x;
        Console.WriteLine(square(10));

        var sayHello = (Action callback) =>
        {
            Console.WriteLine("Hello ini lambda");
            Console.WriteLine("Hello Dunia");
            callback();
        };
        
        var callback = () =>
        {
            Console.WriteLine("Halo ini adalah callback function");
        };
        
        // sayHello(callback);
        sayHello(() =>
        {
            Console.WriteLine("Halo ini adalah callback anonymous function");
        });*/