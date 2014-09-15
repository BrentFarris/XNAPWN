using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeakSven
{
    class Buttons
    {
         enum RState
        {
            HOVER,
            UP,
            JUST_RELEASED,
            DOWN
        };

        const int NUMBER_OF_RECT = 4;
        Color background_color;
        Color[] rect_color = new Color[NUMBER_OF_RECT];
        RState[] rect_state = new RState[NUMBER_OF_RECT];
        double[] rect_timer = new double[NUMBER_OF_RECT];

        bool mpreseed, prev_mpressed = false;

        int mx, my;
        double frame_time;


    }
}

