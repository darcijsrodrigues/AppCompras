using System;
using System.IO;
using AppCompras.iOS;
using SQLite.Net;

[assembly: Xamarin.Forms.Dependency(typeof(FileHelper))]
namespace AppCompras.iOS
{
	public class FileHelper : IFileHelper
	{
		public SQLiteConnection GetConnection()
		{
			//Nome do arquivo que será gravado no celular
			string SQLiteFileName = "dbAppCompras.db3";

			//Diretório pessoal onde o arquivo será gravado
			string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

			//Library do iOS
			string libPath = Path.Combine(docPath, "..", "Library");

			//Concatena o caminho do Diretório com o nome do arquivo
			var path = Path.Combine(libPath, SQLiteFileName);

			//Instancia a plataforma de acordo com o tipo do projeto
			var platform = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();

			//Cria a conexão com o Banco de Dados local
			var connection = new SQLiteConnection(platform, path);

			//Retorna a conexão
			return connection;
		}
	}
}
