using System.Collections.ObjectModel;
using Firebase.Database;
using Firebase.Database.Query;
namespace MyprojeOdev2
{
    public static class BL
    {
        public static ObservableCollection<YapilacakEkle> yapilacaklar = new ObservableCollection<YapilacakEkle>();


        static FirebaseClient client = new FirebaseClient("https://yapilacak-7eec0-default-rtdb.firebaseio.com/");
        public static bool YapilacakEkle(YapilacakEkle Y, out string error)
        {
            var res = client.Child(" yapilacaklar").PostAsync(Y, true);
            error = "";
            return true;


        }

        public static bool YapilacakDuzenle(YapilacakEkle Y, out string error)
        {

            client.Child(" yapilacaklar/" + Y.ID).PutAsync(Y);

            error = "";
            return true;
        }

        public static bool YapilacakSil(YapilacakEkle Y, out string error)
        {


            var res = client.Child(" yapilacaklar/" + Y.ID).DeleteAsync();

            error = "";
            return true;
        }


        public static bool YapilacakYukle(out string error)
        {


            yapilacaklar.Clear();
            var res = client.Child(" yapilacaklar").AsObservable<YapilacakEkle>().Subscribe(Y =>
            {
                if (Y.Object != null)
                {
                    var Yapilacak = Y.Object;
                    Yapilacak.ID = Y.Key;
                    yapilacaklar.Add(Yapilacak);


                }

            });

            error = "";
            return true;
        }
    }
}