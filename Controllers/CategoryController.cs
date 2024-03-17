using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace AcessoADados_SQLServer_Dapper.Controllers;

public class CategoryController
{
  public void ListCategories(SqlConnection connection)
  {
    var categories = connection.Query<Category>("Select [Id], [Title], [Summary] FROM [Category]");

    foreach (var item in categories)
    {
      System.Console.WriteLine($"{item.Title} - {item.Summary}");
    }
  }

  public void CreateCateries(SqlConnection connection)
  {
    var category = new Category();
    category.Id = Guid.NewGuid();
    category.Title = "Amazon AWS";
    category.Url = "amazon";
    category.Description = "Categoria destinada a servoços do AWS";
    category.Order = 8;
    category.Summary = "AWS Cloud";
    category.Featured = false;




    var insertSql = @"Insert into [Category]
          VALUES(
              @Id,
              @Title,
              @Url,
              @Summary,
              @Order,
              @Description,
              @Featured
            )";

    var rows = connection.Execute(insertSql, new
    {
      category.Id,
      category.Title,
      category.Url,
      category.Summary,
      category.Order,
      category.Description,
      category.Featured

    });

    System.Console.WriteLine($"{rows} - linha inseridas");
  }


  public void UpdateCategory(SqlConnection connection)
  {
    var updateQuery = "UPDATE [Category] SET [Title]=@Title WHERE [Id]=@Id";

    var rows = connection.Execute(updateQuery, new
    {
      Id = new Guid("af3407aa-11ae-4621-a2ef-2028b85507c4"),
      Title = "Front-End 2024"
    });
    System.Console.WriteLine($"{rows} - Linhas alteradas");
  }

  public void DeleteCategory(SqlConnection connection, Guid categoryId)
  {
    var deleteQuery = "DELETE FROM [Category] WHERE [Id] = @Id";

    var rowsAffected = connection.Execute(deleteQuery, new { Id = categoryId });

    System.Console.WriteLine($"{rowsAffected} linha(s) excluída(s)");
  }
  public void FindByIDCategory(SqlConnection connection) { }
  
  public void CreateManyCateries(SqlConnection connection)
  {
    var category = new Category();
    category.Id = Guid.NewGuid();
    category.Title = "Amazon AWS";
    category.Url = "amazon";
    category.Description = "Categoria destinada a servoços do AWS";
    category.Order = 8;
    category.Summary = "AWS Cloud";
    category.Featured = false;
    
    var category2 = new Category();
    category2.Id = Guid.NewGuid();
    category2.Title = "Categoria 2";
    category2.Url = "Categoria 2";
    category2.Description = "Categoria destinada a category Two !!!!!!";
    category2.Order = 9;
    category2.Summary = "Categoria";
    category2.Featured = true;




    var insertSql = @"Insert into [Category]
          VALUES(
              @Id,
              @Title,
              @Url,
              @Summary,
              @Order,
              @Description,
              @Featured
            )";

    var rows = connection.Execute(insertSql, new []
    {
      new
      {
        category.Id,
        category.Title,
        category.Url,
        category.Summary,
        category.Order,
        category.Description,
        category.Featured

      },
      new
      {
        category2.Id,
        category2.Title,
        category2.Url,
        category2.Summary,
        category2.Order,
        category2.Description,
        category2.Featured

      }
    });

    System.Console.WriteLine($"{rows} - linha inseridas");
  }

  public void ExecuteProcedure(SqlConnection connection)
  {
    var sql = "[spDeleteStudent]";
    
    var pars = new
    {
      StudentID = "facf0599-9cbc-4037-8500-234efd099c8b"
    };
    var affectedRows = connection.Execute(sql, pars, commandType: CommandType.StoredProcedure);

    System.Console.WriteLine($"{affectedRows} - linha afetadas");
    
  }
  
  
}
