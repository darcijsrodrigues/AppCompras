using System;
using SQLite.Net.Attributes;

namespace AppCompras.Models
{
	public class Compra
	{
		public Compra()
		{
		}
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; } 

		public string descricao { get; set; }

		public string nomeLoja { get; set; }

		public double valor { get; set; }

		public DateTime dataCompra { get; set; }
	}
}
