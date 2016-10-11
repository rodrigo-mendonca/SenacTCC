﻿using Pathfinder.Abstraction;
using Pathfinder.Constants;
using Pathfinder.Finders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pathfinder.Factories
{
    public class FinderFactory
    {
        public static IFinder GetAStarImplementation(DiagonalMovement diag, IHeuristic heuristic )
        {
            return new AStarFinder(diag, heuristic);
        }

        public static IFinder GetBFSImplementation(DiagonalMovement diag, IHeuristic heuristic)
        {
            return new BestFirstSearchFinder(diag, heuristic);
        }

        public static IFinder GetDijkstraImplementation(DiagonalMovement diag, IHeuristic heuristic)
        {
            return new DijkstraFinder(diag, heuristic);
        }

        public static IFinder GetGAImplementation(DiagonalMovement diag)
        {
            return new GAFinder(diag);
        }
    }
}
