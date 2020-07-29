using MTSChrzanow.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MTSChrzanow.ViewModels
{
	public class DetailsViewModel : BaseViewModel
	{
		private MTSPost _mtsPost;
		public MTSPost MTSPost
		{
			get => _mtsPost;
			set
			{
				SetProperty(ref _mtsPost, value);
			}
		}

		public DetailsViewModel() { }

		public DetailsViewModel(MTSPost post)
		{
			MTSPost = post;
			Android.Util.Log.Debug("DETAILS_PAGE", post.Title.Rendered);
		}
	}
}
