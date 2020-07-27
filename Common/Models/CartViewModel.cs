using Common.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Common.Models
{
    public class CartViewModel
    {

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "cartItems")]
        public virtual ICollection<CartItemViewModel> CartItems { get; set; }
    }
}