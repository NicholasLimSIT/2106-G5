using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
namespace ParkWhere.Models
{
    public class Carpark
    {
        public int id { get; set; }
        [Display(Name = "Carpark No")]
        public string carparkNo { get; set; }
        [Display(Name = "Address")]
        public string address { get; set; }
        public double x_coord { get; set; }
        public double y_coord { get; set; }
        [Display(Name = "Carpark Type")]
        public string carparkType { get; set; }
        [Display(Name = "Type of parking")]
        public string typeOfparking { get; set; }
        [Display(Name = "Short-term Parking")]
        public string shortTermparking { get; set; }
        [Display(Name = "Free Parking")]
        public string freeParking { get; set; }
        [Display(Name = "Night Parking")]
        public string nightParking { get; set; }
        [Display(Name = "Park And Scheme")]
        public string parkAndrideScheme { get; set; }
        [Display(Name = "Adhoc Parking")]
        public string adhocParking { get; set; }
    }
}