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
        Texture2D playerTex, wheelCactusTex, hurtTex;
        KeyboardState currentKeyboardState, oldKeyboardState;
        SpriteFont spriteFont;
        List<Enemy> enemies;
        WheelCactus testWheelCactus;
        MapManager mapManager;
        Tile[,] mapBackground, mapForeground;

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
            //dessa tre integers ändrar du på om du ändrat tilestorleken, eller mängden tiles
            int tileSize = 32;
            int screenWidth = 24;
            int screenHeight = 16;
            int tileAmountWidth = 5;
            int tileAmountHeight = 1;
            playerStartPos = new Point(100, 100);

            graphics.PreferredBackBufferHeight = screenHeight * tileSize;
            graphics.PreferredBackBufferWidth = screenWidth * tileSize;

            spriteBatch = new SpriteBatch(GraphicsDevice);
            playerTex = Content.Load<Texture2D>(@"playerSimpleSheet");
            spriteFont = Content.Load<SpriteFont>(@"spriteFont");
            hurtTex = Content.Load<Texture2D>(@"hurtboxgraphic");
            Texture2D IslandTiles = Content.Load<Texture2D>("mapSpriteSheet");
            wheelCactusTex = Content.Load<Texture2D>(@"WheelCactus tex");

            player = new Player(playerTex, playerStartPos, spriteFont, hurtTex);
            mapManager = new MapManager(IslandTiles, tileSize, tileAmountWidth, tileAmountHeight);
            mapBackground = mapManager.MapBackgroundBuilder();
            mapForeground = mapManager.MapForegroundBuilder();
            testWheelCactus = new WheelCactus(wheelCactusTex, new Point(300, 300));
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
            foreach (Enemy enemy in enemies)
            {
                enemy.Update();
            }
            player.EnemyCollisionCheck(enemies);
            EnemyHurtCheck();
            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            foreach (Tile tile in mapBackground)
            {
                tile.Draw(spriteBatch);
            }

            player.Draw(spriteBatch);

            foreach (Enemy enemy in enemies)
            {
                enemy.Draw(spriteBatch);
            }
            //kommenterat ut då mapForeground just nu inte har några värden i sig
            //foreach (Tile tile in mapForeground)
            //{
            //    tile.Draw(spriteBatch);
            //}
            spriteBatch.End();

            base.Draw(gameTime);
        }
        private void EnemyHurtCheck()
        {
            foreach (Enemy enemy in enemies)
            {
                if (player.hurtbox.Intersects(enemy.hitbox))
                {
                    enemy.GetHurt();
                }
            }
        }
    }
}
