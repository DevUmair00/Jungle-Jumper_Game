using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using GameFrameWork.Entities;
using GameFrameWork.Component;
using GameFrameWork.Core;
using GameFrameWork.Extentions;
using GameFrameWork.Interfaces;
using GameFrameWork.Movements;
using GameFrameWork.System;

namespace GameFrameWork.Core
{
    public class GameTime
    {
        public GameTime(float deltaTime)
        {
            DeltaTime = deltaTime;
        }

        // Time elapsed since the last update
        public float DeltaTime { get; set; } = 1f;
    }
}