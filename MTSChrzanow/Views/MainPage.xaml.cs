using Android.Webkit;
using MTSChrzanow.Models;
using MTSChrzanow.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
			viewModel.GoToSelectedPage.Execute(frame.ClassId);
		}
	}
}
