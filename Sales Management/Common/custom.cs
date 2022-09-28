using System.ComponentModel.DataAnnotations;
using System;

namespace Sales_Management.Common
{
    public class custom : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime = Convert.ToDateTime(value);
            return dateTime <= DateTime.Now;
        }

    }
}
