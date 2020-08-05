﻿using MTSChrzanow.Models;
using MTSChrzanow.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MTSChrzanow.Views
{
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class SponsorDetailsPage : ContentPage
	{
		public SponsorDetailsPage(MTSSponsor sponsor)
		{
			InitializeComponent();
			BindingContext = new SponsorDetailsViewModel(sponsor);
		}
	}
}