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
		public ICommand GoToSelectedSponsor => _goToSponsorCommand ?? (_goToSponsorCommand = new Command<Sponsor>(OnSponsorItemClicked));

		private ObservableCollection<Sponsor> _sponsors;
		public ObservableCollection<Sponsor> Sponsors
		{
			get => _sponsors;
			set => SetProperty(ref _sponsors, value);
		}

		public SponsorsViewModel(INavigation navigation)
		{
			_navigation = navigation;
			InitializeSponsors();
		}

		public void InitializeSponsors()
		{
			List<Sponsor> items = SponsorsData.GetSponsors();
			Sponsors = new ObservableCollection<Sponsor>(items);
		}
		
		private async void OnSponsorItemClicked(Sponsor sponsor)
		{
			if (sponsor != null)
			{
				await _navigation.PushAsync(new SponsorDetailsPage(sponsor));
			}
		}
	}
}
