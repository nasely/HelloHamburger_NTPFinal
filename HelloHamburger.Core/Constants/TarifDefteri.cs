using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloHamburger.Core.Constants
{
    public class TarifDefteri
    {
        public static readonly Dictionary<string, List<string>> Tarifler = new Dictionary<string, List<string>>()
        {
            {
                "Klasik Köfte Hamburger", new List<string>()
                {
                    "Marul",
                    "Domates",
                    "Turşu"
                }
            },
            {
                "Çıtır Tavuk Burger", new List<string>()
                {
                    "Cheddar peyniri",
                    "Turşu",
                    "Burger sosu"
                }
            },
            {
                "Pastırmalı Burger", new List<string>()
                {
                    "Cheddar peyniri",
                    "Marul",
                    "Domates",
                    "Turşu",
                }
            },
            {
                "Vegan Burger", new List<string>()
                {
                    "Marul",
                    "Domates",
                    "Turşu"
                }
            }
        };

    }
}
