﻿namespace Evader.EvadableAbilities.Heroes
{
    using Base;

    using Ensage;

    using static Core.Abilities;

    internal class RealityRift : LinearTarget
    {
        #region Constructors and Destructors

        public RealityRift(Ability ability)
            : base(ability)
        {
            CounterAbilities.Add(PhaseShift);
            CounterAbilities.Add(BallLightning);
            CounterAbilities.Add(SleightOfFist);
            CounterAbilities.Add(Manta);
            CounterAbilities.Add(Eul);
            CounterAbilities.AddRange(VsDamage);
            CounterAbilities.AddRange(VsPhys);
            CounterAbilities.AddRange(Invis);
            CounterAbilities.Add(SnowBall);
            CounterAbilities.Add(Lotus);
        }

        #endregion
    }
}