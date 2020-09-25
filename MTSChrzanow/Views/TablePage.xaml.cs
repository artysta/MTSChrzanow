using MTSChrzanow.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MTSChrzanow.Views
{
	[DesignTimeVisible(false)]
	public partial class TablePage : ContentPage
	{
		public TablePage()
		{
			InitializeComponent();
			BindingContext = new TableViewModel(); ;
		}
	}
}
