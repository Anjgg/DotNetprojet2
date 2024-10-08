using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.ApplicationInsights.AspNetCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace P2FixAnAppDotNetCode.Models
{
    public class Order
    {
        [BindNever]
        public int OrderId { get; set; }

        [BindNever]
        public ICollection<CartLine> Lines { get; set; }

        [Required(ErrorMessageResourceName = "ErrorMissingName", ErrorMessageResourceType = (typeof(P2FixAnAppDotNetCode.Resources.Models.ViewModels.Order)))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceName = "ErrorMissingAddress", ErrorMessageResourceType = (typeof(P2FixAnAppDotNetCode.Resources.Models.ViewModels.Order)))]
        public string Address { get; set; }

        [Required(ErrorMessageResourceName = "ErrorMissingCity", ErrorMessageResourceType = (typeof(P2FixAnAppDotNetCode.Resources.Models.ViewModels.Order)))]
        public string City { get; set; }

        public string Zip { get; set; }

        [Required(ErrorMessageResourceName = "ErrorMissingCountry", ErrorMessageResourceType = (typeof(P2FixAnAppDotNetCode.Resources.Models.ViewModels.Order)))]
        public string Country { get; set; }

        [BindNever]
        public DateTime Date { get; set; }
    }
}
