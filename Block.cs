using OpenTK;
using OpenTK.Graphics;
using StorybrewCommon.Mapset;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewCommon.Storyboarding.Util;
using StorybrewCommon.Subtitles;
using StorybrewCommon.Util;
using System;
using System.Collections.Generic;
using System.Linq;



namespace StorybrewScripts
{
    public class Block : StoryboardObjectGenerator
    {
        [Configurable]
        public int EndTime = 0;

        [Configurable]
        public int StartTime= 0;

        [Configurable]
        public double Opacity= 0.9;

        [Configurable]
        public OsbEasing Easing = OsbEasing.None;

        [Configurable]
        public Vector2 Position = new Vector2(0, 400);
        
        [Configurable]
        public int startX = 1;
        
        [Configurable]
        public int startY = 1;
        
        [Configurable]
        public int endX = 1;

        [Configurable]
        public int endY = 1;

        [Configurable]
        public double startRed = 1;

        [Configurable]
        public double startGreen = 1;

        [Configurable]
        public double startBlue = 1;

        public override void Generate()
        {
            var bg = GetLayer("block").CreateSprite("SB/block.png", OsbOrigin.Centre, new Vector2(Position.X, Position.Y));
            var endRed = startRed;
            var endGreen = startGreen;
            var endBlue = startBlue;

            bg.Fade(StartTime - 100, StartTime, 0, Opacity);
            bg.Fade(EndTime - 200, EndTime, Opacity, 0);
            bg.ScaleVec(Easing, StartTime, EndTime, startX, startY, endX, endY);
            bg.Color(StartTime, EndTime, startRed, startGreen, startBlue, endRed, endGreen, endBlue);
        }
    }
}
