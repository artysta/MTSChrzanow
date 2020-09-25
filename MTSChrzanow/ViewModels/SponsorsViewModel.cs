using MTSChrzanow.Models;
using MTSChrzanow.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace MTSChrzanow.ViewModels
{
	public class SponsorsViewModel : BaseViewModel
	{
		private INavigation _navigation;

		private ICommand _goToSponsorCommand;
		public ICommand GoToSelectedSponsor => _goToSponsorCommand ?? (_goToSponsorCommand = new Command<MTSSponsor>(OnSponsorItemClicked));

		private ObservableCollection<MTSSponsor> _mtsSponsors;
		public ObservableCollection<MTSSponsor> MTSSponsors
		{
			get => _mtsSponsors;
			set => SetProperty(ref _mtsSponsors, value);
		}

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
			if (sponsor != null)
			{
				await _navigation.PushAsync(new SponsorDetailsPage(sponsor));
			}
		}
	}
}
