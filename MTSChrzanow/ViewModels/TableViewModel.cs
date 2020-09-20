using MTSChrzanow.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using MTSChrzanow.Helpers;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using MTSChrzanow.Views;

namespace MTSChrzanow.ViewModels
{
	class TableViewModel : BaseViewModel
	{
		private INavigation _navigation;
		private ObservableCollection<Team> _teams;
		public ObservableCollection<Team> Teams
		{
			get { return _teams; }
			set
			{
				SetProperty(ref _teams, value);
			}
		}

		private bool _isBusy;
		public bool IsBusy
		{
			get { return _isBusy; }
			set
			{
				SetProperty(ref _isBusy, value);
			}
		}

		public TableViewModel(INavigation navigation)
		{
			_navigation = navigation;
			InitializeTable();
		}

		public async void InitializeTable()
		{
			IsBusy = true;
			try
			{
				//FirebaseNetworkException
				App.ViewModel.LoggedUser.Token = await UserHelper.GetAccessTokenAsync();
			}
			catch (Exception e)
			{
				await Application.Current.MainPage.DisplayAlert("Uwaga!", "Coś poszło nie tak! Sprawdź połączenie internetowe! :(", "Ok");
				(Application.Current).MainPage = new NavigationPage(new MainPage());
				return;
			}

			await GetAllTeams();
			IsBusy = false;
		}

		private async Task GetAllTeams()
		{
			string query = QueryBuilder.CreateQuery(App.MTSChrzanowFirebaseUrl,
													App.MTSChrzanowFirebaseTableUrl,
													App.MTSChrzanowFirebaseAuth,
													App.ViewModel.LoggedUser.Token);

			string json = await new WebClient().DownloadStringTaskAsync(query);
			var teams = JsonConvert.DeserializeObject<List<Team>>(json);

			Teams = new ObservableCollection<Team>(teams);
		}
	}	
}
