using MTSChrzanow.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace MTSChrzanow.Views
{
	[DesignTimeVisible(false)]
	public partial class MainPage : ContentPage
	{
		private MainViewModel _viewModel;

		public MainPage()
		{
			InitializeComponent();
			_viewModel = new MainViewModel(Navigation);
			BindingContext = _viewModel;
		}

		/*
		void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			viewModel.GoToSelectedPage.Execute(e.Item as MainMenuItem);
		}
		*/

		private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
		{
			Frame frame = (Frame)sender;
			await frame.FadeTo(0.85, 110);
			await frame.ScaleTo(0.95, 110);
			await frame.ScaleTo(1, 110);
			await frame.FadeTo(1, 110);
			_viewModel.GoToSelectedPage.Execute(frame.ClassId);
		}
	}
}
