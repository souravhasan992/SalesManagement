﻿using System.ComponentModel.DataAnnotations;

namespace Sales_Management.Common
{
    public class ExcludeCharacter : ValidationAttribute
    {
        private readonly string chars;
        public ExcludeCharacter(string nchar) : base("{0} contains invalid character")
        {
            chars = nchar;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                for (int i = 0; i < chars.Length; i++)
                {
                    var valueasString = value.ToString();
                    if (valueasString.Contains(chars[i]))
                    {
                        var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                        return new ValidationResult(errorMessage);
                    }
                }
            }
            return ValidationResult.Success;
        }
    }
}
