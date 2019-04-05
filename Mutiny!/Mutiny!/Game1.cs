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
    public class Game1 : Game
        //Grundläggande kod för att hantera Playerklassen skapad av Sara
        //Också för enemy of wheelcactus
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Player player;
        Point playerStartPos;
        Texture2D playerTex;
        Texture2D wheelCactusTex;
        KeyboardState currentKeyboardState;
        KeyboardState oldKeyboardState;
        SpriteFont spriteFont;
        List<Enemy> enemies;
        WheelCactus testWheelCactus;
        Texture2D hurtTex;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        
        protected override void Initialize()
        {
            base.Initialize();
            
            currentKeyboardState = Keyboard.GetState();
        }
        
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            playerStartPos = new Point(100, 100);
            playerTex = Content.Load<Texture2D>(@"PlayerSimpleSheet");
            spriteFont = Content.Load<SpriteFont>(@"spriteFont");
            hurtTex = Content.Load<Texture2D>(@"hurtboxgraphic");
            player = new Player(playerTex, playerStartPos, spriteFont, hurtTex);
            wheelCactusTex = Content.Load<Texture2D>(@"WheelCactus tex");
            testWheelCactus = new WheelCactus(wheelCactusTex, new Point (300, 300));
            enemies = new List<Enemy>();
            enemies.Add(testWheelCactus);
            
        }

        protected override void UnloadContent()
        {
           
        }
        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            oldKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();
            player.Update(currentKeyboardState, oldKeyboardState, gameTime);
            foreach (Enemy e in enemies)
            {
                e.Update();
            }
            player.EnemyCollisionCheck(enemies);
            EnemyHurtCheck();
            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            player.Draw(spriteBatch);
            foreach (Enemy e in enemies)
            {
                e.Draw(spriteBatch);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
        private void EnemyHurtCheck()
        {
            foreach (Enemy e in enemies)
            {
                if (player.hurtbox.Intersects(e.hitbox))
                {
                    e.GetHurt();
                }
            }
        }
    }
}
