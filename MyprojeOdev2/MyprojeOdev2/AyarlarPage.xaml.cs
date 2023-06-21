namespace MyprojeOdev2;

public partial class AyarlarPage : ContentPage
{
	public AyarlarPage()
	{
		InitializeComponent();
	}
    private void Switch_Toggled(object sender, ToggledEventArgs e)
    {
        if (e.Value)
            Application.Current.UserAppTheme = AppTheme.Dark;
        else
            Application.Current.UserAppTheme = AppTheme.Light;

    }

}