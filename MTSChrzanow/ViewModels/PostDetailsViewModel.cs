using MTSChrzanow.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MTSChrzanow.ViewModels
{
	public class PostDetailsViewModel : BaseViewModel
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

		public PostDetailsViewModel() { }

		public PostDetailsViewModel(MTSPost post)
		{
			MTSPost = post;
			Android.Util.Log.Debug("DETAILS_PAGE", post.Title.Rendered);
		}
	}
}
