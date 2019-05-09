using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReservBigBird.Models
{
    public class PenerimaOrder
    {
        public String JenisBus { get; set; }
        public String Pool { get; set; }
        public String tglawalpilih { get; set; }
        public String hariawalpilih { get; set; }
        public String jamawalpilih { get; set; }
        public String KelTujuan { get; set; }
        public String tglakhirpilih { get; set; }
        public String hariakhirpilih { get; set; }
        public String jamakhirpilih { get; set; }
        public int JumlahBus { get; set; }
        public String Pemesan { get; set; }
    }
}