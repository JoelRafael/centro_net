using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace CentroNet.Helpers
{
    public class DateHelpers
    {
        public static DateTime Responsedate()
        {
            var date = DateTime.Today;
            string s2 = date.ToString("yyyy-MM-dd");
            DateTime dtnew = DateTime.Parse(s2);

            return dtnew;


        }
        public static DateTime ResponsedateMa()
        {
            return DateTime.Today;

        }
    }

}