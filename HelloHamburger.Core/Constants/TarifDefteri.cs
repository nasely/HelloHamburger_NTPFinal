using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloHamburger.Core.Constants
{
    public class TarifDefteri
    {
        public static readonly Dictionary<string, List<string>> BurgerTarifleri = new Dictionary<string, List<string>>()
        {
            {
                "Klasik Köfte Hamburger", new List<string>()
                {
                    "marul",
                    "domates",
                    "turşu"
                }
            },
            {
                "Çıtır Tavuk Burger", new List<string>()
                {
                    "cheddar peyniri",
                    "turşu",
                    "burger sosu"
                }
            },
            {
                "Pastırmalı Burger", new List<string>()
                {
                    "cheddar peyniri",
                    "marul",
                    "domates",
                    "turşu",
                }
            },
            {
                "Vegan Burger", new List<string>()
                {
                    "marul",
                    "domates",
                    "turşu"
                }
            }
        };

    }
}
