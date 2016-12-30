using System;
using System.Windows.Input;
using AppCompras.Models;
using Xamarin.Forms;

namespace AppCompras.ViewModels
{
	public class ViewModelCompra:BaseViewModel
	{		
		public Compra compra = new Compra();

		private string 	_descricao { get; set; }
		public string Descricao { 
			get { return compra.descricao; }
			set
			{
				if (value != _descricao)
				{
					_descricao = value;
					compra.descricao = value;
					NotifyPropertyChange("descricao");
				}
			}
		}

		private string _nomeLoja { get; set; }
		public string NomeLoja
		{
			get { return compra.nomeLoja; }
			set
			{
				if (value != _nomeLoja)
				{
					_nomeLoja = value;
					compra.nomeLoja = value;
					NotifyPropertyChange("nomeLoja");
				}
			}
		}

		private double _valor { get; set; }
		public double Valor
		{
			get { return compra.valor;}
			set
			{
				if (value != _valor)
				{
					_valor = value;
					compra.valor = value;
					NotifyPropertyChange("valor");
				}
			}
		}


		private DateTime _dataCompra { get; set; }
		public DateTime DataCompra
		{
			get { return compra.dataCompra; }
			set
			{
				if (value != _dataCompra)
				{
					_dataCompra = value;
					compra.dataCompra = value;
					NotifyPropertyChange("dataCompra");
				}
			}
		}

		public ICommand onSalvaCompra { get; set; }
		public ICommand onDeletaCompra { get; set; }


		public ViewModelCompra()
		{
			this.onSalvaCompra = new Command(() =>
			{
				MessagingCenter.Send<Compra>(this.compra, "NewCompra");
			});

			this.onDeletaCompra = new Command(() =>
			{
				MessagingCenter.Send<Compra>(this.compra, "DelCompra");
			});
		}
	}
}
