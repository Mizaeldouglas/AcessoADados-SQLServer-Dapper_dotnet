using Microsoft.Data.SqlClient;

const string connectionString = "Server=localhost,1433;Database=balta_cursoAcessoADados;User ID=sa;Password=MyPassword123#";

using (var connection = new SqlConnection(connectionString))
{
  System.Console.WriteLine("Conectado!");
  connection.Open();

  using (var command = new SqlCommand())
  {
    command.Connection = connection;
    command.CommandType = System.Data.CommandType.Text;
    command.CommandText = "SELECT [Id], [Title] FROM [Category]";

    var reader = command.ExecuteReader();

    while (reader.Read())
    {
      System.Console.WriteLine($"{reader.GetGuid(0)} - {reader.GetString(1)}");
    }
  }
  connection.Close();

}

