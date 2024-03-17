using AcessoADados_SQLServer_Dapper;
using Dapper;
using Microsoft.Data.SqlClient;
using AcessoADados_SQLServer_Dapper.Controllers;

const string connectionString =
    "Server=localhost,1433;Database=balta_cursoAcessoADados;User ID=sa;Password=MyPassword123#";
var category = new CategoryController();


using (var connection = new SqlConnection(connectionString))
{
    // category.UpdateCategory(connection);
    // category.DeleteCategory(connection, new Guid("25d510c8-3108-44c2-86c5-924d9832aa8c") );
    // category.ListCategories(connection);
    // category.CreateManyCateries(connection);
    // category.CreateCateries(connection);
    // category.ListCategories(connection);
    // category.ExecuteProcedure(connection);
    category.ExecuteReadProcedure(connection);
    
    
}