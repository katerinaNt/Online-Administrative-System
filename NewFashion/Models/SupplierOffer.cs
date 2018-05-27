using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewFashion.Models
{
    public class SupplierOffer
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public decimal Cloth { get; set; }

        [Required]
        [Display(Name = "Price/Meter")]
        public decimal PricePerMeter { get; set; }

        [Required]
        public int Buttons { get; set; }

        [Required]
        [Display(Name = "Price/Button")]
        public decimal PricePerButton { get; set; }

        [Required]
        public int Stickers { get; set; }

        [Required]
        [Display(Name = "Price/Sticker")]
        public decimal PricePerSticker { get; set; }

        [Required]
        public decimal Thread { get; set; }

        [Required]
        [Display(Name = "Price/Thread")]
        public decimal PricePerThread { get; set; }

        [Required]
        public decimal Zipper { get; set; }

        [Required]
        [Display(Name = "Price/Zipper")]
        public decimal PricePerZipper { get; set; }

        [Required]
        public bool IsSelected { get; set; }

        [Required]
        public bool IsCalculated { get; set; }

        [Required]
        public string SupplierID { get; set; }

        public virtual ApplicationUser Supplier { get; set; }

        public void Created(List<ApplicationUser> usersToNotify)
        {
            var notification = Notification.OfferCreated(this);

            foreach (var admin in usersToNotify)
            {
                admin.Notify(notification);
            }
        }
    }
}