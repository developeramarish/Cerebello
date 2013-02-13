﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Text.RegularExpressions;

namespace CerebelloWebRole.Code
{
    public static class StringHelper
    {
        public static string CapitalizeFirstLetters(string str, string[] excludeList)
        {
            if (excludeList == null)
                excludeList = new string[0];

            var processedStrings = new List<string>();
            foreach (string s in str.Split(' ').Where(s => !excludeList.Contains(s)))
            {
                if (s.Length > 1)
                    processedStrings.Add(char.ToUpper(s[0]).ToString() + s.Substring(1));
                else if (s.Length == 1)
                    processedStrings.Add(char.ToUpper(s[0]).ToString());
            }

            return string.Join(" ", processedStrings.ToArray());
        }

        public static string RemoveDiacritics(string original)
        {
            var stFormD = original.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();

            foreach (var t in from t in stFormD let uc = CharUnicodeInfo.GetUnicodeCategory(t) where uc != UnicodeCategory.NonSpacingMark select t)
                sb.Append(t);

            return (sb.ToString().Normalize(NormalizationForm.FormC));
        }

        public static bool ValidateCaptalizedWords(string title)
        {
            var vTitleWords = title.Split(' ');
            if (vTitleWords.Length > 1)
            {
                var lowerWordsCount = 0;

                for (var i = 1; i < vTitleWords.Length; i++)
                {
                    var vString = vTitleWords[i];
                    var hasCapitalLetter = false;
                    for (var j = 1; j < vString.Length; j++)
                    {
                        char vChar = vString[j];
                        if (char.IsUpper(vChar))
                        {
                            hasCapitalLetter = true;
                            break;
                        }
                    }
                    if (!hasCapitalLetter)
                        lowerWordsCount++;
                }

                return ((double)lowerWordsCount / (vTitleWords.Length - 1)) >= 0.50;
            }
            return true;
        }

        /// <summary>
        /// Cria um identificador para a discussão atual sem caracteres especiais
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public static string GenerateUrlIdentifier(string title)
        {
            if (title == null)
                return null;

            var normalizedString = title.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (char c in normalizedString)
            {
                switch (CharUnicodeInfo.GetUnicodeCategory(c))
                {
                    case UnicodeCategory.LowercaseLetter:
                    case UnicodeCategory.UppercaseLetter:
                    case UnicodeCategory.DecimalDigitNumber:
                        stringBuilder.Append(char.ToLowerInvariant(c));
                        break;
                    case UnicodeCategory.SpaceSeparator:
                    case UnicodeCategory.ConnectorPunctuation:
                    case UnicodeCategory.DashPunctuation:
                        //stringBuilder.Append('_');
                        break;
                }
            }

            string result = stringBuilder.ToString();
            //result = Regex.Replace(result, @"_+", "_"); // remove duplicate underscores
            return result;
        }

        /// <summary>
        /// Normalizes a UserName, to compare against other normalized user-names in the database.
        /// This is a security measure, the UserName must be typed exactly the same as the user entered the first time,
        /// but no other users may exist with the same normalized user-name.
        /// This leaves a gap, that makes it more difficult to guess what the UserName of a person may be.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static string NormalizeUserName(string userName)
        {
            var normalizedString = userName.ToLowerInvariant().Normalize(NormalizationForm.FormD);
            var result = Regex.Replace(normalizedString, @"[^\p{Ll}\p{Lu}\p{Lt}\p{Lo}\p{Nd}]+", "");
            return result;
        }

        /// <summary>
        /// Replaces string using a StringComparison
        /// </summary>
        static public string ReplaceString(string str, string oldValue, string newValue, StringComparison comparison)
        {
            var sb = new StringBuilder();

            var previousIndex = 0;
            var index = str.IndexOf(oldValue, comparison);
            while (index != -1)
            {
                sb.Append(str.Substring(previousIndex, index - previousIndex));
                sb.Append(newValue);
                index += oldValue.Length;

                previousIndex = index;
                index = str.IndexOf(oldValue, index, comparison);
            }
            sb.Append(str.Substring(previousIndex));

            return sb.ToString();
        }

        /// <summary>
        /// Replaces fields in the text with the corresponding value in the object.
        /// Fields are denoted by "&lt;%PropertyPath%&gt;".
        /// The PropertyPath can contain a property name or a property path using '.' operator.
        /// </summary>
        /// <param name="inputText"></param>
        /// <param name="rootObj"></param>
        /// <returns></returns>
        public static string ReflectionReplace(string inputText, object rootObj)
        {
            // supported: properties, indirections
            // unsupported: indexer, dynamic, methods, operators

            var result = Regex.Replace(
                inputText,
                @"<%(.*?)%>",
                m =>
                {
                    var propNames = new Queue<string>(m.Groups[1].Value.Split('.'));
                    object currentObj = rootObj;
                    while (propNames.Count > 0 && currentObj != null)
                    {
                        var propInfo = currentObj.GetType().GetProperty(propNames.Dequeue().Trim());
                        currentObj = propInfo == null ? null : propInfo.GetValue(currentObj, null);
                    }
                    var result2 = string.Format("{0}", currentObj);
                    return result2;
                });
            return result;
        }

        private static bool AllEmpty(this IEnumerable<string> strs)
        {
            return (strs ?? new string[0]).All(string.IsNullOrWhiteSpace);
        }

        public static bool AllFilled(this IEnumerable<string> strs)
        {
            return !AnyEmpty(strs);
        }

        private static bool AnyEmpty(this IEnumerable<string> strs)
        {
            return (strs ?? new string[0]).Any(string.IsNullOrWhiteSpace);
        }

        public static bool AnyFilled(this IEnumerable<string> strs)
        {
            return !AllEmpty(strs);
        }
    }
}
