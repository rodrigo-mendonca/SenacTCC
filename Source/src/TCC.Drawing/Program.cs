﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenTK;
using TCC.Drawing;

namespace TCC
{
    static class Program
    {
        static MapWindow Window;
        static void Main(string[] args)
        {
            //Window = new MapWindow(new MapGenerate(20, 20, 0.2), 30);
            Window = new MapWindow(new MapGenerate("test.txt"), 30);
            Window.UpdateFrame += new EventHandler<FrameEventArgs>(UpdateMap);
            Window.Run();
        }

        public static void UpdateMap(object o, FrameEventArgs e)
        {
            //Window.SetMap(WallWithGap());
            tx++;
        }
        static int tx = 0, ty = 0;
        static List<Point2D> WallWithGap()
        {
            //  □ □ □ ■ □ □ □
            //  □ □ □ ■ □ □ □
            //  □ S □ ■ □ F □
            //  □ □ □ ■ ■ □ □
            //  □ □ □ □ □ □ □

            var map = new List<Point2D>();
            map.Add(new Point2D(3, 0, Color.Gray));
            map.Add(new Point2D(3, 1, Color.Gray));
            map.Add(new Point2D(3, 2, Color.Gray));
            map.Add(new Point2D(3, 3, Color.Gray));
            map.Add(new Point2D(4, 3, Color.Gray));

            map.Add(new Point2D(1, 2, Color.Red));
            map.Add(new Point2D(5, 2, Color.Blue));

            map.Add(new Point2D(tx, ty, Color.Green));

            return map;
        }
    }
}
