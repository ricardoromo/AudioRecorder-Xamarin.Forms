using System;
using Xamarin.Forms;

namespace AudioRecorderSample.Pages
{
	public partial class AudioRecorderPage : ContentPage
	{
		public Button AudioRecorderButton {get; set;}
		public Button AudioPlayerButton {get; set;}
		public void Layout ()
		{
			AudioRecorderButton = new Button ();
			AudioRecorderButton.Text = "Start Recording";


			AudioPlayerButton = new Button ();
			AudioPlayerButton.Text = "Play Audio";

			var contentLayout = new StackLayout ();
			contentLayout.Children.Add (AudioRecorderButton);
			contentLayout.Children.Add (AudioPlayerButton);
			contentLayout.HorizontalOptions = LayoutOptions.CenterAndExpand;
			contentLayout.VerticalOptions = LayoutOptions.CenterAndExpand;

			Content = contentLayout;
		}

	}
}

