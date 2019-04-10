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
    abstract class Enemy
    {
        //Skapad och grundlagt av Sara
        protected Texture2D tex;
        public Rectangle hitbox = new Rectangle(0, 0, 0, 0);
        public Rectangle hurtbox = new Rectangle(0, 0, 0, 0);
        public Enemy()
        {

        }
        public abstract void Update();
        public abstract void Draw(SpriteBatch spriteBatch);
        public abstract void GetHurt();
    }
}
