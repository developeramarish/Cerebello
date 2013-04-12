﻿using System.Collections.Generic;
using System.Web.Mvc;

namespace CerebelloWebRole.Code.Business
{
    public class DropDownListHelper
    {
        /// <summary>
        /// Returns the list of countries in the world
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<SelectListItem> GetCountriesLIst()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem() { Value="United States", Text="United States" }, 
                new SelectListItem() { Value="United Kingdom", Text="United Kingdom" }, 
                new SelectListItem() { Value="Afghanistan", Text="Afghanistan" }, 
                new SelectListItem() { Value="Albania", Text="Albania" }, 
                new SelectListItem() { Value="Algeria", Text="Algeria" }, 
                new SelectListItem() { Value="American Samoa", Text="American Samoa" }, 
                new SelectListItem() { Value="Andorra", Text="Andorra" }, 
                new SelectListItem() { Value="Angola", Text="Angola" }, 
                new SelectListItem() { Value="Anguilla", Text="Anguilla" }, 
                new SelectListItem() { Value="Antarctica", Text="Antarctica" }, 
                new SelectListItem() { Value="Antigua and Barbuda", Text="Antigua and Barbuda" }, 
                new SelectListItem() { Value="Argentina", Text="Argentina" }, 
                new SelectListItem() { Value="Armenia", Text="Armenia" }, 
                new SelectListItem() { Value="Aruba", Text="Aruba" }, 
                new SelectListItem() { Value="Australia", Text="Australia" }, 
                new SelectListItem() { Value="Austria", Text="Austria" }, 
                new SelectListItem() { Value="Azerbaijan", Text="Azerbaijan" }, 
                new SelectListItem() { Value="Bahamas", Text="Bahamas" }, 
                new SelectListItem() { Value="Bahrain", Text="Bahrain" }, 
                new SelectListItem() { Value="Bangladesh", Text="Bangladesh" }, 
                new SelectListItem() { Value="Barbados", Text="Barbados" }, 
                new SelectListItem() { Value="Belarus", Text="Belarus" }, 
                new SelectListItem() { Value="Belgium", Text="Belgium" }, 
                new SelectListItem() { Value="Belize", Text="Belize" }, 
                new SelectListItem() { Value="Benin", Text="Benin" }, 
                new SelectListItem() { Value="Bermuda", Text="Bermuda" }, 
                new SelectListItem() { Value="Bhutan", Text="Bhutan" }, 
                new SelectListItem() { Value="Bolivia", Text="Bolivia" }, 
                new SelectListItem() { Value="Bosnia and Herzegovina", Text="Bosnia and Herzegovina" }, 
                new SelectListItem() { Value="Botswana", Text="Botswana" }, 
                new SelectListItem() { Value="Bouvet Island", Text="Bouvet Island" }, 
                new SelectListItem() { Value="Brazil", Text="Brazil" }, 
                new SelectListItem() { Value="British Indian Ocean Territory", Text="British Indian Ocean Territory" }, 
                new SelectListItem() { Value="Brunei Darussalam", Text="Brunei Darussalam" }, 
                new SelectListItem() { Value="Bulgaria", Text="Bulgaria" }, 
                new SelectListItem() { Value="Burkina Faso", Text="Burkina Faso" }, 
                new SelectListItem() { Value="Burundi", Text="Burundi" }, 
                new SelectListItem() { Value="Cambodia", Text="Cambodia" }, 
                new SelectListItem() { Value="Cameroon", Text="Cameroon" }, 
                new SelectListItem() { Value="Canada", Text="Canada" }, 
                new SelectListItem() { Value="Cape Verde", Text="Cape Verde" }, 
                new SelectListItem() { Value="Cayman Islands", Text="Cayman Islands" }, 
                new SelectListItem() { Value="Central African Republic", Text="Central African Republic" }, 
                new SelectListItem() { Value="Chad", Text="Chad" }, 
                new SelectListItem() { Value="Chile", Text="Chile" }, 
                new SelectListItem() { Value="China", Text="China" }, 
                new SelectListItem() { Value="Christmas Island", Text="Christmas Island" }, 
                new SelectListItem() { Value="Cocos (Keeling) Islands", Text="Cocos (Keeling) Islands" }, 
                new SelectListItem() { Value="Colombia", Text="Colombia" }, 
                new SelectListItem() { Value="Comoros", Text="Comoros" }, 
                new SelectListItem() { Value="Congo", Text="Congo" }, 
                new SelectListItem() { Value="Congo, The Democratic Republic of The", Text="Congo, The Democratic Republic of The" }, 
                new SelectListItem() { Value="Cook Islands", Text="Cook Islands" }, 
                new SelectListItem() { Value="Costa Rica", Text="Costa Rica" }, 
                new SelectListItem() { Value="Cote D'ivoire", Text="Cote D'ivoire" }, 
                new SelectListItem() { Value="Croatia", Text="Croatia" }, 
                new SelectListItem() { Value="Cuba", Text="Cuba" }, 
                new SelectListItem() { Value="Cyprus", Text="Cyprus" }, 
                new SelectListItem() { Value="Czech Republic", Text="Czech Republic" }, 
                new SelectListItem() { Value="Denmark", Text="Denmark" }, 
                new SelectListItem() { Value="Djibouti", Text="Djibouti" }, 
                new SelectListItem() { Value="Dominica", Text="Dominica" }, 
                new SelectListItem() { Value="Dominican Republic", Text="Dominican Republic" }, 
                new SelectListItem() { Value="Ecuador", Text="Ecuador" }, 
                new SelectListItem() { Value="Egypt", Text="Egypt" }, 
                new SelectListItem() { Value="El Salvador", Text="El Salvador" }, 
                new SelectListItem() { Value="Equatorial Guinea", Text="Equatorial Guinea" }, 
                new SelectListItem() { Value="Eritrea", Text="Eritrea" }, 
                new SelectListItem() { Value="Estonia", Text="Estonia" }, 
                new SelectListItem() { Value="Ethiopia", Text="Ethiopia" }, 
                new SelectListItem() { Value="Falkland Islands (Malvinas)", Text="Falkland Islands (Malvinas)" }, 
                new SelectListItem() { Value="Faroe Islands", Text="Faroe Islands" }, 
                new SelectListItem() { Value="Fiji", Text="Fiji" }, 
                new SelectListItem() { Value="Finland", Text="Finland" }, 
                new SelectListItem() { Value="France", Text="France" }, 
                new SelectListItem() { Value="French Guiana", Text="French Guiana" }, 
                new SelectListItem() { Value="French Polynesia", Text="French Polynesia" }, 
                new SelectListItem() { Value="French Southern Territories", Text="French Southern Territories" }, 
                new SelectListItem() { Value="Gabon", Text="Gabon" }, 
                new SelectListItem() { Value="Gambia", Text="Gambia" }, 
                new SelectListItem() { Value="Georgia", Text="Georgia" }, 
                new SelectListItem() { Value="Germany", Text="Germany" }, 
                new SelectListItem() { Value="Ghana", Text="Ghana" }, 
                new SelectListItem() { Value="Gibraltar", Text="Gibraltar" }, 
                new SelectListItem() { Value="Greece", Text="Greece" }, 
                new SelectListItem() { Value="Greenland", Text="Greenland" }, 
                new SelectListItem() { Value="Grenada", Text="Grenada" }, 
                new SelectListItem() { Value="Guadeloupe", Text="Guadeloupe" }, 
                new SelectListItem() { Value="Guam", Text="Guam" }, 
                new SelectListItem() { Value="Guatemala", Text="Guatemala" }, 
                new SelectListItem() { Value="Guinea", Text="Guinea" }, 
                new SelectListItem() { Value="Guinea-bissau", Text="Guinea-bissau" }, 
                new SelectListItem() { Value="Guyana", Text="Guyana" }, 
                new SelectListItem() { Value="Haiti", Text="Haiti" }, 
                new SelectListItem() { Value="Heard Island and Mcdonald Islands", Text="Heard Island and Mcdonald Islands" }, 
                new SelectListItem() { Value="Holy See (Vatican City State)", Text="Holy See (Vatican City State)" }, 
                new SelectListItem() { Value="Honduras", Text="Honduras" }, 
                new SelectListItem() { Value="Hong Kong", Text="Hong Kong" }, 
                new SelectListItem() { Value="Hungary", Text="Hungary" }, 
                new SelectListItem() { Value="Iceland", Text="Iceland" }, 
                new SelectListItem() { Value="India", Text="India" }, 
                new SelectListItem() { Value="Indonesia", Text="Indonesia" }, 
                new SelectListItem() { Value="Iran, Islamic Republic of", Text="Iran, Islamic Republic of" }, 
                new SelectListItem() { Value="Iraq", Text="Iraq" }, 
                new SelectListItem() { Value="Ireland", Text="Ireland" }, 
                new SelectListItem() { Value="Israel", Text="Israel" }, 
                new SelectListItem() { Value="Italy", Text="Italy" }, 
                new SelectListItem() { Value="Jamaica", Text="Jamaica" }, 
                new SelectListItem() { Value="Japan", Text="Japan" }, 
                new SelectListItem() { Value="Jordan", Text="Jordan" }, 
                new SelectListItem() { Value="Kazakhstan", Text="Kazakhstan" }, 
                new SelectListItem() { Value="Kenya", Text="Kenya" }, 
                new SelectListItem() { Value="Kiribati", Text="Kiribati" }, 
                new SelectListItem() { Value="Korea, Democratic People's Republic of", Text="Korea, Democratic People's Republic of" }, 
                new SelectListItem() { Value="Korea, Republic of", Text="Korea, Republic of" }, 
                new SelectListItem() { Value="Kuwait", Text="Kuwait" }, 
                new SelectListItem() { Value="Kyrgyzstan", Text="Kyrgyzstan" }, 
                new SelectListItem() { Value="Lao People's Democratic Republic", Text="Lao People's Democratic Republic" }, 
                new SelectListItem() { Value="Latvia", Text="Latvia" }, 
                new SelectListItem() { Value="Lebanon", Text="Lebanon" }, 
                new SelectListItem() { Value="Lesotho", Text="Lesotho" }, 
                new SelectListItem() { Value="Liberia", Text="Liberia" }, 
                new SelectListItem() { Value="Libyan Arab Jamahiriya", Text="Libyan Arab Jamahiriya" }, 
                new SelectListItem() { Value="Liechtenstein", Text="Liechtenstein" }, 
                new SelectListItem() { Value="Lithuania", Text="Lithuania" }, 
                new SelectListItem() { Value="Luxembourg", Text="Luxembourg" }, 
                new SelectListItem() { Value="Macao", Text="Macao" }, 
                new SelectListItem() { Value="Macedonia, The Former Yugoslav Republic of", Text="Macedonia, The Former Yugoslav Republic of" }, 
                new SelectListItem() { Value="Madagascar", Text="Madagascar" }, 
                new SelectListItem() { Value="Malawi", Text="Malawi" }, 
                new SelectListItem() { Value="Malaysia", Text="Malaysia" }, 
                new SelectListItem() { Value="Maldives", Text="Maldives" }, 
                new SelectListItem() { Value="Mali", Text="Mali" }, 
                new SelectListItem() { Value="Malta", Text="Malta" }, 
                new SelectListItem() { Value="Marshall Islands", Text="Marshall Islands" }, 
                new SelectListItem() { Value="Martinique", Text="Martinique" }, 
                new SelectListItem() { Value="Mauritania", Text="Mauritania" }, 
                new SelectListItem() { Value="Mauritius", Text="Mauritius" }, 
                new SelectListItem() { Value="Mayotte", Text="Mayotte" }, 
                new SelectListItem() { Value="Mexico", Text="Mexico" }, 
                new SelectListItem() { Value="Micronesia, Federated States of", Text="Micronesia, Federated States of" }, 
                new SelectListItem() { Value="Moldova, Republic of", Text="Moldova, Republic of" }, 
                new SelectListItem() { Value="Monaco", Text="Monaco" }, 
                new SelectListItem() { Value="Mongolia", Text="Mongolia" }, 
                new SelectListItem() { Value="Montserrat", Text="Montserrat" }, 
                new SelectListItem() { Value="Morocco", Text="Morocco" }, 
                new SelectListItem() { Value="Mozambique", Text="Mozambique" }, 
                new SelectListItem() { Value="Myanmar", Text="Myanmar" }, 
                new SelectListItem() { Value="Namibia", Text="Namibia" }, 
                new SelectListItem() { Value="Nauru", Text="Nauru" }, 
                new SelectListItem() { Value="Nepal", Text="Nepal" }, 
                new SelectListItem() { Value="Netherlands", Text="Netherlands" }, 
                new SelectListItem() { Value="Netherlands Antilles", Text="Netherlands Antilles" }, 
                new SelectListItem() { Value="New Caledonia", Text="New Caledonia" }, 
                new SelectListItem() { Value="New Zealand", Text="New Zealand" }, 
                new SelectListItem() { Value="Nicaragua", Text="Nicaragua" }, 
                new SelectListItem() { Value="Niger", Text="Niger" }, 
                new SelectListItem() { Value="Nigeria", Text="Nigeria" }, 
                new SelectListItem() { Value="Niue", Text="Niue" }, 
                new SelectListItem() { Value="Norfolk Island", Text="Norfolk Island" }, 
                new SelectListItem() { Value="Northern Mariana Islands", Text="Northern Mariana Islands" }, 
                new SelectListItem() { Value="Norway", Text="Norway" }, 
                new SelectListItem() { Value="Oman", Text="Oman" }, 
                new SelectListItem() { Value="Pakistan", Text="Pakistan" }, 
                new SelectListItem() { Value="Palau", Text="Palau" }, 
                new SelectListItem() { Value="Palestinian Territory, Occupied", Text="Palestinian Territory, Occupied" }, 
                new SelectListItem() { Value="Panama", Text="Panama" }, 
                new SelectListItem() { Value="Papua New Guinea", Text="Papua New Guinea" }, 
                new SelectListItem() { Value="Paraguay", Text="Paraguay" }, 
                new SelectListItem() { Value="Peru", Text="Peru" }, 
                new SelectListItem() { Value="Philippines", Text="Philippines" }, 
                new SelectListItem() { Value="Pitcairn", Text="Pitcairn" }, 
                new SelectListItem() { Value="Poland", Text="Poland" }, 
                new SelectListItem() { Value="Portugal", Text="Portugal" }, 
                new SelectListItem() { Value="Puerto Rico", Text="Puerto Rico" }, 
                new SelectListItem() { Value="Qatar", Text="Qatar" }, 
                new SelectListItem() { Value="Reunion", Text="Reunion" }, 
                new SelectListItem() { Value="Romania", Text="Romania" }, 
                new SelectListItem() { Value="Russian Federation", Text="Russian Federation" }, 
                new SelectListItem() { Value="Rwanda", Text="Rwanda" }, 
                new SelectListItem() { Value="Saint Helena", Text="Saint Helena" }, 
                new SelectListItem() { Value="Saint Kitts and Nevis", Text="Saint Kitts and Nevis" }, 
                new SelectListItem() { Value="Saint Lucia", Text="Saint Lucia" }, 
                new SelectListItem() { Value="Saint Pierre and Miquelon", Text="Saint Pierre and Miquelon" }, 
                new SelectListItem() { Value="Saint Vincent and The Grenadines", Text="Saint Vincent and The Grenadines" }, 
                new SelectListItem() { Value="Samoa", Text="Samoa" }, 
                new SelectListItem() { Value="San Marino", Text="San Marino" }, 
                new SelectListItem() { Value="Sao Tome and Principe", Text="Sao Tome and Principe" }, 
                new SelectListItem() { Value="Saudi Arabia", Text="Saudi Arabia" }, 
                new SelectListItem() { Value="Senegal", Text="Senegal" }, 
                new SelectListItem() { Value="Serbia and Montenegro", Text="Serbia and Montenegro" }, 
                new SelectListItem() { Value="Seychelles", Text="Seychelles" }, 
                new SelectListItem() { Value="Sierra Leone", Text="Sierra Leone" }, 
                new SelectListItem() { Value="Singapore", Text="Singapore" }, 
                new SelectListItem() { Value="Slovakia", Text="Slovakia" }, 
                new SelectListItem() { Value="Slovenia", Text="Slovenia" }, 
                new SelectListItem() { Value="Solomon Islands", Text="Solomon Islands" }, 
                new SelectListItem() { Value="Somalia", Text="Somalia" }, 
                new SelectListItem() { Value="South Africa", Text="South Africa" }, 
                new SelectListItem() { Value="South Georgia and The South Sandwich Islands", Text="South Georgia and The South Sandwich Islands" }, 
                new SelectListItem() { Value="Spain", Text="Spain" }, 
                new SelectListItem() { Value="Sri Lanka", Text="Sri Lanka" }, 
                new SelectListItem() { Value="Sudan", Text="Sudan" }, 
                new SelectListItem() { Value="Suriname", Text="Suriname" }, 
                new SelectListItem() { Value="Svalbard and Jan Mayen", Text="Svalbard and Jan Mayen" }, 
                new SelectListItem() { Value="Swaziland", Text="Swaziland" }, 
                new SelectListItem() { Value="Sweden", Text="Sweden" }, 
                new SelectListItem() { Value="Switzerland", Text="Switzerland" }, 
                new SelectListItem() { Value="Syrian Arab Republic", Text="Syrian Arab Republic" }, 
                new SelectListItem() { Value="Taiwan, Province of China", Text="Taiwan, Province of China" }, 
                new SelectListItem() { Value="Tajikistan", Text="Tajikistan" }, 
                new SelectListItem() { Value="Tanzania, United Republic of", Text="Tanzania, United Republic of" }, 
                new SelectListItem() { Value="Thailand", Text="Thailand" }, 
                new SelectListItem() { Value="Timor-leste", Text="Timor-leste" }, 
                new SelectListItem() { Value="Togo", Text="Togo" }, 
                new SelectListItem() { Value="Tokelau", Text="Tokelau" }, 
                new SelectListItem() { Value="Tonga", Text="Tonga" }, 
                new SelectListItem() { Value="Trinidad and Tobago", Text="Trinidad and Tobago" }, 
                new SelectListItem() { Value="Tunisia", Text="Tunisia" }, 
                new SelectListItem() { Value="Turkey", Text="Turkey" }, 
                new SelectListItem() { Value="Turkmenistan", Text="Turkmenistan" }, 
                new SelectListItem() { Value="Turks and Caicos Islands", Text="Turks and Caicos Islands" }, 
                new SelectListItem() { Value="Tuvalu", Text="Tuvalu" }, 
                new SelectListItem() { Value="Uganda", Text="Uganda" }, 
                new SelectListItem() { Value="Ukraine", Text="Ukraine" }, 
                new SelectListItem() { Value="United Arab Emirates", Text="United Arab Emirates" }, 
                new SelectListItem() { Value="United Kingdom", Text="United Kingdom" }, 
                new SelectListItem() { Value="United States", Text="United States" }, 
                new SelectListItem() { Value="United States Minor Outlying Islands", Text="United States Minor Outlying Islands" }, 
                new SelectListItem() { Value="Uruguay", Text="Uruguay" }, 
                new SelectListItem() { Value="Uzbekistan", Text="Uzbekistan" }, 
                new SelectListItem() { Value="Vanuatu", Text="Vanuatu" }, 
                new SelectListItem() { Value="Venezuela", Text="Venezuela" }, 
                new SelectListItem() { Value="Viet Nam", Text="Viet Nam" }, 
                new SelectListItem() { Value="Virgin Islands, British", Text="Virgin Islands, British" }, 
                new SelectListItem() { Value="Virgin Islands, U.S.", Text="Virgin Islands, U.S." }, 
                new SelectListItem() { Value="Wallis and Futuna", Text="Wallis and Futuna" }, 
                new SelectListItem() { Value="Western Sahara", Text="Western Sahara" }, 
                new SelectListItem() { Value="Yemen", Text="Yemen" }, 
                new SelectListItem() { Value="Zambia", Text="Zambia" }, 
                new SelectListItem() { Value="Zimbabwe", Text="Zimbabwe" }
            };
        }

    }
}