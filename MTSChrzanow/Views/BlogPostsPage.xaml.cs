using MTSChrzanow.Models;
using MTSChrzanow.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace MTSChrzanow.Views
{
	[DesignTimeVisible(false)]
	public partial class PostsPage : ContentPage
	{
		private BlogPostsViewModel _viewModel;

		public PostsPage()
		{
			InitializeComponent();
			_viewModel = new BlogPostsViewModel(Navigation);
			BindingContext = _viewModel;
		}

		void ListView_ItemTapped(object sender, ItemTappedEventArgs e) =>
			_viewModel.GoToDetailsCommand.Execute(e.Item as BlogPost);

		void Picker_SelectedIndexChanged(object sender, EventArgs e)
		{
			Picker p = (Picker)sender;
			_viewModel.PickerSelectionChanged.Execute(p.SelectedIndex);
		}
	}
}
