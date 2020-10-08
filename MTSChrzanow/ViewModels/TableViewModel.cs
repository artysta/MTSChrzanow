using MTSChrzanow.Helpers;
using MTSChrzanow.Models;
using MTSChrzanow.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MTSChrzanow.ViewModels
{
	class TableViewModel : BaseViewModel
	{
		private ObservableCollection<Team> _teams;
		public ObservableCollection<Team> Teams
		{
			get => _teams;
			set => SetProperty(ref _teams, value);
		}
		
		private bool _isBusy;
		public bool IsBusy
		{
			get => _isBusy;
			set => SetProperty(ref _isBusy, value);
		}

		public TableViewModel() => InitializeTable();
		
		public async void InitializeTable()
		{
			IsBusy = true;

			try
			{
				//FirebaseNetworkException
				App.ViewModel.LoggedUser.Token = await UserHelper.GetAccessTokenAsync();
			}
			catch (Exception)
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
			string query = QueryBuilder.CreateQuery
				(
					App.ApiFirebaseUrl,
					App.ApiFirebaseTableUrl,
					App.ApiFirebaseAuth,
					App.ViewModel.LoggedUser.Token
				);
			
			string json = await new WebClient().DownloadStringTaskAsync(query);
			var teams = JsonConvert.DeserializeObject<List<Team>>(json);
			
			Teams = new ObservableCollection<Team>(teams.OrderByDescending(o => o.Points).ToList());

			for (int i = 0; i < Teams.Count; i++)
			{
				Teams[i].Index = i + 1;
			}
		}
	}	
}
