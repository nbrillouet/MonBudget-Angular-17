using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Budget.SERVICE._Helpers
{
    public static class FileHelper
    {
        public static List<char> GetExcludedChars()
        {
            List<char> excludedChars = new List<char>();
            excludedChars.Add('\'');
            //excludedChars.Add('*');
            excludedChars.Add('-');
            excludedChars.Add('/');
            excludedChars.Add('\\');
            excludedChars.Add('\"');
            excludedChars.Add(':');
            excludedChars.Add('.');

            return excludedChars;
        }

        public static string ExcludeForbiddenChars(string label)
        {
            List<char> excludedChars = GetExcludedChars();

            foreach (var excludedChar in excludedChars)
            {
                label = label.Replace(excludedChar.ToString(), string.Empty);
            }

            return label;
        }

        public static string ExcludeNumbers(string label)
        {
            return Regex.Replace(label, @"[\d-]", string.Empty);
        }

        public static string GetOperationLabelFromOperationLabelWork(string operationLabel, string operationLabelWork)
        {

            int j =0;
            string label = string.Empty;
            bool beginWord = false;

            for (int i = 0; i < operationLabel.Length; i++)
            {
                char c = Convert.ToChar(operationLabel.Substring(i, 1));
                if (!GetExcludedChars().Contains(c))
                {
                    if (j > operationLabelWork.Length - 1)
                        break;

                    char cw = Convert.ToChar(operationLabelWork.Substring(j, 1));
                    if (beginWord && (Char.ToUpper(c).Equals(cw) || Equals(c, ' ')))
                    {
                        label = label + c;
                        if(!Equals(c, ' '))
                            j++;
                    }
                    else if (!beginWord && (Char.ToUpper(c).Equals(cw) || Equals(c, ' ')))
                    {
                        label = label + c;
                        beginWord = true;
                        if (!Equals(c, ' '))
                            j++;
                    }
                    else if (beginWord)
                    {
                        label = string.Empty;
                        beginWord = false;
                        j = 0;
                    }
                }
            }

            label = label.Trim().ToUpper();

            return label;
        }

        //Index du premier chiffre trouvé dans un label
        public static int IndexFirstNumeric(string label)
        {
            int index = -1;
            for (int i = 0; i < label.Length; i++)
            {
                char c = Convert.ToChar(label.Substring(i, 1));
                if (Char.IsNumber(c))
                {
                    label = label.Substring(0, i);
                    index = i;
                    break;
                }
            }

            return index;
        }

        public static string RemoveDiatrics(string label)
        {
            string textEncode = System.Web.HttpUtility.UrlEncode(label, Encoding.GetEncoding("iso-8859-7"));
            string textDecode = System.Web.HttpUtility.UrlDecode(textEncode);

            return textDecode;
        }
    }
}
