using AcessoADados_SQLServer_Dapper;
using Dapper;
using Microsoft.Data.SqlClient;
using AcessoADados_SQLServer_Dapper.Controllers;

const string connectionString = "Server=localhost,1433;Database=balta_cursoAcessoADados;User ID=sa;Password=MyPassword123#";
var category = new CategoryController();


using (var connection = new SqlConnection(connectionString))
{
  category.UpdateCategory(connection);
  category.ListCategories(connection);

  // category.CreateCateries(connection);


}


