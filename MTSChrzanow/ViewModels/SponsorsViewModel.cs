using Android.Content.Res;
using MTSChrzanow.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using MTSChrzanow.Models;

namespace MTSChrzanow.ViewModels
{
	public class SponsorsViewModel : BaseViewModel
	{
		private ObservableCollection<MTSSponsor> _mtsSponsors;
		private INavigation _navigation;
		private ICommand _goToSponsorCommand;
		
		public ICommand GoToSelectedSponsor => _goToSponsorCommand ?? (_goToSponsorCommand = new Command<MTSSponsor>(OnSponsorItemClicked));

		public ObservableCollection<MTSSponsor> MTSSponsors
		{
			get { return _mtsSponsors; }
			set
			{
				SetProperty(ref _mtsSponsors, value);
			}
		}

		public SponsorsViewModel() : this(null)	{ }

		public SponsorsViewModel(INavigation navigation)
		{
			_navigation = navigation;
			InitializeSponsors();
		}

		public void InitializeSponsors()
		{
			List<MTSSponsor> items = MTSSponsorsData.GetMTSSponsors();

			MTSSponsors = new ObservableCollection<MTSSponsor>(items);
		}
		
		private async void OnSponsorItemClicked(MTSSponsor sponsor)
		{
			if (sponsor == null)
				return;

			await _navigation.PushAsync(new SponsorDetailsPage(sponsor));
		}
	}
}
