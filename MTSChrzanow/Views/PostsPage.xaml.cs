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
		private PostsViewModel _viewModel;

		public PostsPage()
		{
			InitializeComponent();
			_viewModel = new PostsViewModel(Navigation);
			BindingContext = _viewModel;
		}

		void ListView_ItemTapped(object sender, ItemTappedEventArgs e) =>
			_viewModel.GoToDetailsCommand.Execute(e.Item as MTSPost);

		void Picker_SelectedIndexChanged(object sender, EventArgs e)
		{
			Picker p = (Picker)sender;
			_viewModel.PickerSelectionChanged.Execute(p.SelectedIndex);
		}
	}
}
