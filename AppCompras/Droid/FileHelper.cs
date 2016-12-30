using System.IO;
using Xamarin.Forms;
using AppCompras.Droid;
using SQLite.Net;

[assembly: Dependency(typeof(FileHelper))]
namespace AppCompras.Droid
{
	public class FileHelper : IFileHelper
	{
		public SQLiteConnection GetConnection()
		{
			//Nome do arquivo que será gravado no celular
			string SQLiteFileName = "dbAppCompras.db3";

			//Diretório pessoal onde o arquivo será gravado
			string docPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

			//Concatena o caminho do Diretório com o nome do arquivo
			var path = Path.Combine(docPath, SQLiteFileName);

			//Instancia a plataforma de acordo com o tipo do projeto
			var platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();

			//Cria a conexão com o Banco de Dados local
			var connection = new SQLiteConnection(platform, path);

			//Retorna a conexão
			return connection;
		}
	}
}
