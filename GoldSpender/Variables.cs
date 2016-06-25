﻿namespace GoldSpender
{
    using System.Collections.Generic;

    using Ensage;

    using global::GoldSpender.Modules;

    internal class Variables
    {
        #region Static Fields

        public static Dictionary<string, uint> ItemsToBuy = new Dictionary<string, uint>
                                                                {
                                                                    { "item_smoke_of_deceit", 188 },
                                                                    { "item_ward_sentry", 43 },
                                                                    { "item_tome_of_knowledge", 257 },
                                                                    { "item_ward_observer", 42 }, { "attribute_bonus", 1 },
                                                                    { "item_tpscroll", 46 }
                                                                };

        public static List<GoldManager> Modules = new List<GoldManager> { new NearDeath() };

        #endregion

        #region Public Properties

        public static Hero Hero { get; set; }

        public static MenuManager MenuManager { get; set; }

        #endregion
    }
}