
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{ // Çıplak class kalmasın CCK
    //varlıkları ısretleme -gruplama eyılımındeyız
    //concretedekı bır tabloya karsılık gelır
    public class Category: IEntitiy
        //görmedıgınde ampulden yukarıya tanımlarız, locatıon belırler bu ısaretlemedır
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

    }
}
