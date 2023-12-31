﻿using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BLL.Attributes
{
    class AllowedExtensionFileAttribute : ValidationAttribute
    {
        private string _extensions;
        public AllowedExtensionFileAttribute(string extensions)
        {
            _extensions = extensions;
        }


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            IFormFile file = value as IFormFile;
            if (file != null)
            {
                string[] extensionArray = _extensions.Split(',');
                bool validExtension = extensionArray.Any(x => file.FileName.ToLower().EndsWith(x.ToLower()));
                if (!validExtension)
                {
                    return new ValidationResult($"The Type of this {file.FileName} is not allowed!");
                }
            }
            return ValidationResult.Success;
        }
    }
}
