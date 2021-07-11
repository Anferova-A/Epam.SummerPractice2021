using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Shops.Entities.Enums
{
    public enum Gender
    {
        NotSpecified,
        Male,
        Female
    }

    public static class GenderExtension
    {
        public static string ToStringRus(this Gender gender)
        {
            switch (gender)
            {
                case Gender.NotSpecified:
                    return "Не указан";
                case Gender.Male:
                    return "Мужской";
                case Gender.Female:
                    return "Женский";
                default:
                    return "))00)))";
            }
        }
    }
}
