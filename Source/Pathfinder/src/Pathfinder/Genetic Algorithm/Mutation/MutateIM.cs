﻿using Pathfinder.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pathfinder.Mutation
{
    public class MutateIM : AbstractMutate
    {
        public override IGenome Calc(IGenome baby)
        {
            if (Settings.Random.NextDouble() > MutationRate || baby.ListNodes.Count < 3)
                return baby;

            int listcount = baby.ListNodes.Count;
            var randomPoint = Settings.Random.Next(1, listcount);
            var tempNumber = baby.ListNodes[randomPoint];

            baby.ListNodes.RemoveAt(randomPoint);
            var insertAt = Settings.Random.Next(1, listcount);
            baby.ListNodes.Insert(insertAt, tempNumber);

            return baby;
        }
    }
}
