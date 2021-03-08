using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{ // public bu classa dıger katmanlarda ulaşabılsın demek
    //data access urunu ekler
    //busıness urunu kontrol
    //entities urunu göster
    //DTO Data Transformatıon Object
    //classın defoultu ınternal , sadece entities erısır demek
    public class Product : IEntitiy
    {
        public int ProductId { get; set; }
        public int CategoryID { get; set; }
        public string ProductName { get; set; }
        public short UnitsInStock { get; set; } //küçük int
        public decimal UnitPrice { get; set; }

    }
}
//abstract soyut (referans tutucu) concrete somut
//abstract ıle uygulamalar arası baglılıkları mın edıcez