using MTSChrzanow.Models;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MTSChrzanow.ViewModels
{
	public class SponsorDetailsViewModel : BaseViewModel
	{
		private ICommand _goToDetailsCommand;
		public ICommand GoToDetailsCommand => _goToDetailsCommand ?? (_goToDetailsCommand = new Command<Sponsor>(OnGoToSponsorWebsite));
		
		private Sponsor _sponsor;
		public Sponsor Sponsor
		{
			get => _sponsor;
			set => SetProperty(ref _sponsor, value);
		}

		public SponsorDetailsViewModel(Sponsor sponsor)
		{
			if (sponsor != null)
			{
				Sponsor = sponsor;
			}
		}

		private async void OnGoToSponsorWebsite(Sponsor sponsor)
		{
			if (string.IsNullOrWhiteSpace(sponsor.WebSite))
			{
				await Application.Current.MainPage.DisplayAlert("Uwaga!", "Nie udało się otworzyć strony sponsora!", "Ok");
			}
			else
			{
				await Launcher.OpenAsync(sponsor.WebSite);
			}
		}
	}
}
