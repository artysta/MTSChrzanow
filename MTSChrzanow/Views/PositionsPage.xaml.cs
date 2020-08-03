using Android.Webkit;
using MTSChrzanow.Models;
using MTSChrzanow.ViewModels;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace MTSChrzanow.Views
{
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class PositionsPage : ContentPage
	{
		private PositionsViewModel viewModel;

		public PositionsPage()
		{
			InitializeComponent();
			viewModel = new PositionsViewModel(Navigation);
			BindingContext = viewModel;
		}

		void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			viewModel.GoToSelectedPage.Execute(e.Item as PositionsMenuItem);
		}
	}
}
