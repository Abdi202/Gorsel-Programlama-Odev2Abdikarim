namespace MyprojeOdev2;
using MyprojeOdev2;

using MyprojeOdev2;
public partial class YapilacakEditPage : ContentPage
{
    YapilacakEkle kisi;
    public YapilacakEditPage(YapilacakEkle k = null)
    {
        InitializeComponent();
        if (k != null)
        {
            txtGorev.Text = k.gorev;
            txtDetay.Text = k.Detay;
            DateTarih.Date = k.Tarih;
            txtSaat.Text = k.Saat;

        }

        kisi = k;
    }

    public Action<YapilacakEkle> AddMetod { get; internal set; }
    public Action<YapilacakEkle> EditMetod { get; internal set; }

    private void OkClicked(object sender, EventArgs e)
    {
        if (kisi == null)
        {
            kisi = new YapilacakEkle()
            {
                gorev = txtGorev.Text,
                Detay = txtDetay.Text,
                Tarih = DateTarih.Date,
                Saat = txtSaat.Text,

            };



            if (AddMetod != null)
                AddMetod(kisi);
        }
        else
        {
            kisi.gorev = txtGorev.Text;
            kisi.Detay = txtDetay.Text;
            kisi.Tarih = DateTarih.Date;
            kisi.Saat = txtSaat.Text;


            EditMetod(kisi);
        }
        Navigation.PopModalAsync();
    }

    private void CancelClicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }
}