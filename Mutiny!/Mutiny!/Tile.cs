using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Mutiny_
{
    class Tile
    {
        Rectangle spreadSheetRectangle, screenRectangle;
        Texture2D overWorldMap;
        Vector2 pos;

        public Tile(Rectangle spreadSheetRectangle, Texture2D overWorldMap, Vector2 pos)
        {
            this.spreadSheetRectangle = spreadSheetRectangle;
            this.overWorldMap = overWorldMap;
            this.pos = pos;
            screenRectangle = new Rectangle((int)pos.X, (int)pos.Y, (int)pos.X + 64, (int)pos.Y + 64);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(overWorldMap, pos, spreadSheetRectangle, Color.White, 0, new Vector2(0,0), 0.5f, SpriteEffects.None, 0);
        }

    }
}
