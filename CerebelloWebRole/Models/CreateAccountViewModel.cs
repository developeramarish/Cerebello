﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using CerebelloWebRole.Models;
using CerebelloWebRole.App_GlobalResources;

namespace CerebelloWebRole.Models
{
    public class CreateAccountViewModel
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Complete name of the person being registered in the software. Sample: "João Paulo da Cunha Santiago Neto".
        /// </summary>
        [Required(ErrorMessageResourceType = typeof(ModelStrings), ErrorMessageResourceName = "RequiredValidationMessage")]
        [Display(Name = "Nome Completo")]
        public String FullName { get; set; }

        [Required(ErrorMessageResourceType = typeof(ModelStrings), ErrorMessageResourceName = "RequiredValidationMessage")]
        [Display(Name = "Data de Nascimento")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessageResourceType = typeof(ModelStrings), ErrorMessageResourceName = "RequiredValidationMessage")]
        [EnumDataType(typeof(TypeGender))]
        [Display(Name = "Sexo")]
        public short Gender { get; set; }
        
        [Required(ErrorMessageResourceType = typeof(ModelStrings), ErrorMessageResourceName = "RequiredValidationMessage")]
        [Display(Name = "E-Mail")]
        [DataType(DataType.EmailAddress)]
        [Remote("EmailIsAvailable", "Membership")]
        public String EMail { get; set; }
        
        [Required(ErrorMessageResourceType = typeof(ModelStrings), ErrorMessageResourceName = "RequiredValidationMessage")]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public String Password { get; set; }

        [Display(Name = "Confirmação da Senha")]
        [Compare("Password", ErrorMessage = "Confirmação da senha não bate")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public string UserName { get; set; }
    }
}