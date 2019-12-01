using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MODEL.Entities
{
    public class Product:BaseEntity
    {
        [Required(ErrorMessage = "Ürün Adı Girmeniz Gerekiyor!")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Fiyat Girmeniz Gerekiyor!")]
        [Range(5, 50, ErrorMessage = "Ürün Fiyatı Minimum: 5, Maximum:50 olmalı.")]
        public decimal UnitPrice { get; set; }

        [Required(ErrorMessage = "Kategori Seçmeniz Gerekiyor!")]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Stok Girmeniz Gerekiyor!")]
        [Range(5, 50, ErrorMessage = "Ürün Stok Minimum: 5, Maximum:50 olmalı.")]
        public int UnitsInStock { get; set; }

        //Relational Properties
        public virtual Category Category { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}
