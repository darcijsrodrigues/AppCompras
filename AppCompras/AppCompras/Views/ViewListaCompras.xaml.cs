using System;
using AppCompras.ViewModels;
using Xamarin.Forms;
using AppCompras.Models;

namespace AppCompras.Views
{
	public partial class ViewListaCompras : ContentPage
	{
		public ViewListaCompras()
		{
			InitializeComponent();



			OnItemAdded.Clicked += (object sender, EventArgs e) =>
			{								
				Navigation.PushAsync(new ViewCompra { BindingContext = new ViewModelCompra() });
			};

			MessagingCenter.Subscribe<Compra>(this, "DetailCompra", (sender) =>
			{
				var vm = new ViewModelCompra { compra = sender };
				Navigation.PushAsync(new ViewCompra
				{
					BindingContext = vm
				});
			});
		}
	}
}
