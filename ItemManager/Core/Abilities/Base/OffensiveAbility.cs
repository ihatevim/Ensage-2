﻿namespace ItemManager.Core.Abilities.Base
{
    using Attributes;

    using Ensage;
    using Ensage.Common.Extensions;
    using Ensage.Common.Objects;
    using Ensage.SDK.Extensions;

    using Interfaces;

    using Menus.Modules.OffensiveAbilities.AbilitySettings;

    using Utils;

    using EntityExtensions = Ensage.SDK.Extensions.EntityExtensions;
    using UnitExtensions = Ensage.SDK.Extensions.UnitExtensions;

    [Ability(AbilityId.item_orchid)]
    [Ability(AbilityId.item_sheepstick)]
    [Ability(AbilityId.item_bloodthorn)]
    [Ability(AbilityId.item_medallion_of_courage)]
    [Ability(AbilityId.item_solar_crest)]
    [Ability(AbilityId.item_cyclone)]
    [Ability(AbilityId.item_heavens_halberd)]
    [Ability(AbilityId.item_rod_of_atos)]
    [Ability(AbilityId.item_ethereal_blade)]
    [Ability(AbilityId.item_abyssal_blade)]
    internal class OffensiveAbility : UsableAbility, IOffensiveAbility
    {
        public OffensiveAbility(Ability ability, Manager manager)
            : base(ability, manager)
        {
        }

        public OffensiveAbilitySettings Menu { get; set; }

        public virtual bool CanBeCasted(Unit target)
        {
            if (target == null || !target.IsValid || !Menu.IsEnabled(target.StoredName()))
            {
                return false;
            }

            if (!target.IsAlive || !target.IsVisible || UnitExtensions.IsMagicImmune(target)
                || EntityExtensions.Distance2D(target, Manager.MyHero.Position) > GetCastRange() || target.IsInvul()
                || target.IsReflectingAbilities())
            {
                return false;
            }

            if (!Menu.BreakLinkens && UnitExtensions.IsLinkensProtected(target))
            {
                return false;
            }

            if (!Menu.HexStack && target.IsReallyHexed())
            {
                return false;
            }

            if (!Menu.SilenceStack && UnitExtensions.IsSilenced(target) && !target.IsReallyHexed())
            {
                return false;
            }

            if (!Menu.RootStack && UnitExtensions.IsRooted(target))
            {
                return false;
            }

            if (!Menu.StunStack && UnitExtensions.IsStunned(target))
            {
                return false;
            }

            if (!Menu.DisarmStack && UnitExtensions.IsDisarmed(target) && !target.IsReallyHexed())
            {
                return false;
            }

            return true;
        }

        public override void Use(Unit target = null, bool queue = false)
        {
            if (target == null)
            {
                return;
            }

            SetSleep(CastPoint + 200);
            Ability.UseAbility(target, queue);
        }
    }
}