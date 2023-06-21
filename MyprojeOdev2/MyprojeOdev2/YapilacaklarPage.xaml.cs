using MyprojeOdev2;
namespace MyprojeOdev2;
public partial class YapilacaklarPage : ContentPage
{
    public YapilacaklarPage()
    {
        InitializeComponent();
        YapilacakYukle();
        listYapilacklar.ItemsSource = BL.yapilacaklar;
    }


    string error;
    private void YapilacakYukle()
    {
        bool res = BL.YapilacakYukle(out error);
        if (!res)
        {
            DisplayAlert("Hata oluþtu", error, "OK");
        }
    }

    void AddYapilacak(YapilacakEkle k)
    {
        var res = BL.YapilacakEkle(k, out error);

        if (!res)
        {
            DisplayAlert("Hata oluþtu", error, "OK");
        }
    }

    private void YapilacEkleClicked(object sender, EventArgs e)
    {
        YapilacakEditPage page = new YapilacakEditPage() { AddMetod = AddYapilacak };
        Navigation.PushModalAsync(page);
    }

    private void YapilacakYukleClicked(object sender, EventArgs e)
    {
        YapilacakYukle();
    }

    private void YapilacakDuzenleClicked(object sender, EventArgs e)
    {
        var b = sender as ImageButton;
        if (b != null)
        {
            var kisi = BL.yapilacaklar.First(o => o.ID == b.CommandParameter.ToString());
            YapilacakEditPage page = new(kisi) { EditMetod = EditYapilacak };
            Navigation.PushModalAsync(page);
        }
    }

    private void EditYapilacak(YapilacakEkle k)
    {
        BL.YapilacakDuzenle(k, out error);
    }

    private async void YapilacakSilClicked(object sender, EventArgs e)
    {
        var b = sender as ImageButton;
        if (b != null)
        {
            var y = await DisplayAlert("Silinsin mi?", "Silmeyi onayla", "OK", "CANCEL");
            if (y)
            {
                var kisi = BL.yapilacaklar.First(o => o.ID == b.CommandParameter.ToString());
                var res = BL.YapilacakSil(kisi, out error);
                if (!res)
                    await DisplayAlert("Hata oluþtu", error, "OK");
            }
        }
    }
}