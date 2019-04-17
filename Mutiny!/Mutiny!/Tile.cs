﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Mutiny_
{
    //Jesper Lundhs arbete
    class Tile
    {
        Rectangle spreadSheetRectangle, screenRectangle;
        Texture2D overWorldMap;
        Vector2 drawPos;
        bool wall;

        public Tile(Rectangle spreadSheetRectangle, Texture2D mapSpritesheet, Vector2 drawPos, int tileSize, bool wall)
        {
            this.spreadSheetRectangle = spreadSheetRectangle;
            this.overWorldMap = mapSpritesheet;
            this.drawPos = drawPos;
            this.wall = wall;
            screenRectangle = new Rectangle((int)drawPos.X, (int)drawPos.Y, tileSize, tileSize);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(overWorldMap, screenRectangle, spreadSheetRectangle, Color.White);
        }

    }
}
