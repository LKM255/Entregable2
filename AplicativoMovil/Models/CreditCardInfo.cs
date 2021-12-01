using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AplicativoMovil.Models
{
    public class CreditCardInfo
    {
        public string MaskedNumber { get; set; }

        /// <summary>
        /// Master Card, Visa e etc...
        /// </summary>
        public CardType Type { get; set; }

        public string TypeAndMasked => "(" + Type + ") " + MaskedNumber;

        public string TypeString => Type.ToString();

        public Color PrimaryColor { get; set; }

        public Color PrimaryDarkColor { get; set; }

        public DateTime Valid => DateTime.Now.AddYears(4);

        public string ValidPresentation => Valid.ToString("MM/yy");

        public string IconFromType => Type.GetLogo();

    }

    public static class CreditCartInfoExtention
    {
        public static string GetLogo(this CardType cardType)
        {
            switch (cardType)
            {
                case CardType.MasterCard:
                    return "\uf1f1";
                case CardType.Visa:
                    return "\uf1f0";
                case CardType.AmericanExpress:
                    return "\uf1f3";
                case CardType.Discover:
                    return "\uf1f2";
                case CardType.JCB:
                    return "\uf24b";
            }

            return "";
        }
    }


    public enum CardType
    {
        Undefined, MasterCard, Visa, AmericanExpress, Discover, JCB
    };
}

