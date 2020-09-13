using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace ArtShop.Entities.Model
{
    /// <summary>
    /// OrderDetail Metadata class
    /// </summary>
    [MetadataType(typeof(OrderDetailMetadata))]
    public partial class OrderDetail
    {
        public class OrderDetailMetadata
        {
            /// <summary>
            /// Id
            /// </summary>        
            [DisplayName("Id")]
            [Required(ErrorMessage = "Requerido")]
            public int
              Id
            {
                get;
                set;
            }

            /// <summary>
            /// Order Id
            /// </summary>        
            [DisplayName("Order Id")]
            [Required(ErrorMessage = "Requerido")]
            public int
              OrderId
            {
                get;
                set;
            }

            /// <summary>
            /// Product Id
            /// </summary>        
            [DisplayName("Product Id")]
            [Required(ErrorMessage = "Requerido")]
            public int
              ProductId
            {
                get;
                set;
            }

            /// <summary>
            /// Price
            /// </summary>        
            [DisplayName("Price")]
            [Required(ErrorMessage = "Requerido")]
            public double
              Price
            {
                get;
                set;
            }

            /// <summary>
            /// Quantity
            /// </summary>        
            [DisplayName("Quantity")]
            [Required(ErrorMessage = "Requerido")]
            public int
              Quantity
            {
                get;
                set;
            }



        }
    }
}