using MTSChrzanow.Models;
using MTSChrzanow.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MTSChrzanow.Views
{
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class MainPage : ContentPage
	{
		MainViewModel viewModel;
		public MainPage()
		{
			InitializeComponent();
			viewModel = new MainViewModel(Navigation);
			BindingContext = viewModel;
		}

		void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			viewModel.GoToDetailsCommand.Execute(e.Item as MTSPost);
		}

		void Picker_SelectedIndexChanged(object sender, EventArgs e)
		{
			Picker p = (Picker)sender;
			viewModel.PickerSelectionChanged.Execute(p.SelectedIndex);
		}
	}
}
