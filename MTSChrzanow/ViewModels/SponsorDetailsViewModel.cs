using MTSChrzanow.Models;

namespace MTSChrzanow.ViewModels
{
	public class SponsorDetailsViewModel : BaseViewModel
	{
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
	}
}
