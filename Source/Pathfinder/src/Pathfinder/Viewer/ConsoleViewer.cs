﻿using Pathfinder.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Pathfinder.Viewer
{
    public class ConsoleViewer : AbstractViewer
    {
        Settings settings;
        IList<Node> path;

        public ConsoleViewer(IFinder finder) : base(finder)
        {
            settings = new Settings();
        }

        public override void Start()
        {
            Console.Clear();
        }

        public override void Loop(FinderEventArgs e)
        {
            Console.Clear();
            var text = GetTextRepresentation(e.GridMap);
            Console.WriteLine(text);

            AbstractViewer.ShowStepLog(_finder, e);
            Thread.Sleep(_finder.SleepUITimeInMs);
        }

        public override void End(FinderEventArgs e)
        {
            Console.Clear();
            path = _finder.GetPath();
            var text = GetTextRepresentation(e.GridMap, false, true);
            Console.WriteLine(text);

            AbstractViewer.ShowEndLog(_finder, path, e);
        }

        private string GetTextRepresentation(IMap map, bool showOpenNodes = true, bool showPath=false)
        {
            var ret = string.Empty;

            for (int i = 0; i < map.Height; i++)
            {
                for (int j = 0; j < map.Width; j++)
                {
                    char c = ' ';
                    var node = map[i, j];

                    if (node == map.StartNode)
                        c = settings.Start;
                    else if (node == map.EndNode)
                        c = settings.End;
                    else if (showPath && path.Contains(node))
                        c = settings.Path;
                    else if (!node.Walkable)
                        c = settings.Wall;
                    else if (showOpenNodes && _finder.isClosed(node))
                        c = settings.Closed;
                    else if (showOpenNodes && _finder.isOpen(node))
                        c = settings.Opened;
                    else
                        c = settings.Empty;

                    ret += c.ToString();
                }
                ret += "\n";
            }

            return ret;
        }

        public override void Run(IMap map)
        {
            _finder.Find(map);
        }
    }
}