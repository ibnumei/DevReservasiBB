using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReservBigBird.Models
{
    public class ModelListIsi
    {
        private List<ModelList> isi = new List<ModelList>();

        public ModelListIsi()
        {
            isi.Add(new ModelList { Pool = "acc1", Angka = new int[] { 10, 2, 3 } });
            isi.Add(new ModelList { Pool = "acc2", Angka = new int[] { 5, 7, 1 } });
        }
    }
}