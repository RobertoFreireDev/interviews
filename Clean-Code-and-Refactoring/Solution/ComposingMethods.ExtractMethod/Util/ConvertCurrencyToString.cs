using ComposingMethods.ExtractMethod.Constants;
using ComposingMethods.ExtractMethod.Enums;
using System;

namespace ComposingMethods.ExtractMethod.Util
{
    public static class ConvertCurrencyToString
    {
        public static string Convert(CurrencyEnum currency)
        {
            if (currency == CurrencyEnum.Brazil) return CurrencyConstant.Brazil;
            else if (currency == CurrencyEnum.USA) return CurrencyConstant.USA;
            else {
                throw new ArgumentException();
            }
        }
    }
}
