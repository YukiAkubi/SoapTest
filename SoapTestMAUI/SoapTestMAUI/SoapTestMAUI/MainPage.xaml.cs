using ServiceReference;

namespace SoapTestMAUI;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnCounterClicked(object sender, EventArgs e)
	{
        var client = new WebServiceSoapClient(WebServiceSoapClient.EndpointConfiguration.WebServiceSoap);
		var response = await client.HelloWorldAsync();

        count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times" + response.Body.HelloWorldResult;

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

