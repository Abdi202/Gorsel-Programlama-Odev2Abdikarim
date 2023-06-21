using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyprojeOdev2
{
    public class YapilacakEkle
    {
        private string id = null;

        public string ID
        {
            get
            {
                if (id == null)
                    id = Guid.NewGuid().ToString();
                return id;
            }
            set { id = value; }
        }
        public string gorev { get; set; }
        public string Detay { get; set; }
        public DateTime Tarih { get; set; }
        public string Saat { get; set; }


    }
}