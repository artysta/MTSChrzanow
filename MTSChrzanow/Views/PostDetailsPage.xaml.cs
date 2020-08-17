﻿using MTSChrzanow.Models;
using MTSChrzanow.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MTSChrzanow.Views
{
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class PostDetailsPage : ContentPage
	{
		public PostDetailsPage(MTSPost post)
		{
			InitializeComponent();
			BindingContext = new PostDetailsViewModel(post);
			Title = post.Title.Rendered;
		}
	}
}