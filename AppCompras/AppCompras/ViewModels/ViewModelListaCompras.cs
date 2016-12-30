using System.Collections.ObjectModel;
using AppCompras.Models;
using Xamarin.Forms;

namespace AppCompras.ViewModels
{
	public class ViewModelListaCompras : BaseViewModel
	{
		private ObservableCollection<Compra> _listaCompras = new ObservableCollection<Compra>();
		public ObservableCollection<Compra> ListaCompra{
			get { return _listaCompras; }
			set
			{
				_listaCompras = value;
				NotifyPropertyChange("ListaCompra");
			}
		}

		public Compra OnItemSelected
		{
			set
			{
				if (value != null)
					MessagingCenter.Send<Compra>(value, "DetailCompra");
			}
		}

		public ViewModelListaCompras()
		{
			CarregarLista();

			// Adiciona compra na lista
			MessagingCenter.Subscribe<Compra>("", "NewCompra", (sender) =>
			{
				App.DbCompra.InsertOrUpdate(sender);
				CarregarLista();
			});

			// Deletar compra da lista
			MessagingCenter.Subscribe<Compra>("", "DelCompra", (sender) =>
			{
				App.DbCompra.Delete(sender.ID);
				CarregarLista();
			});
			
		}

		private void CarregarLista() {
			_listaCompras.Clear();

			var all = App.DbCompra.GetAll();

			foreach (Compra t in all)
			{
				_listaCompras.Add(t);
			}
		}
	}
}
