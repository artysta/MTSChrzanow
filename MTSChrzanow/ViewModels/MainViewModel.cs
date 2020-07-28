using MTSChrzanow.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MTSChrzanow.ViewModels
{
	class MainViewModel : BaseViewModel
	{
        ObservableCollection<MTSPost> _mtsPosts;
        public ObservableCollection<MTSPost> MTSPosts
        {
            get { return _mtsPosts; }
            set
            {
                _mtsPosts = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            MTSPosts = new ObservableCollection<MTSPost>();
        }

        public void GetPosts()
		{

		}
    }
}
