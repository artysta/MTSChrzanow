using MTSChrzanow.Models;
using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MTSChrzanow.ViewModels
{
	public class SponsorDetailsViewModel : BaseViewModel
	{
		private ICommand _goToDetailsCommand;
		public ICommand GoToDetailsCommand => _goToDetailsCommand ?? (_goToDetailsCommand = new Command<MTSSponsor>(OnGoToSponsorWebsite));

		private MTSSponsor _mtsSponsor;
		public MTSSponsor MTSSponsor
		{
			get => _mtsSponsor;
			set
			{
				SetProperty(ref _mtsSponsor, value);
			}
		}

		public SponsorDetailsViewModel() { }

		public SponsorDetailsViewModel(MTSSponsor sponsor)
		{
			MTSSponsor = sponsor;
		}

		private async void OnGoToSponsorWebsite(MTSSponsor sponsor)
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
