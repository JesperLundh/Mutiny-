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
        #region Declaration of variables
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Player player;
        Point playerStartPos;
        Texture2D playerTex, wheelCactusTex, hurtTex, jungleTileSheet;
        KeyboardState currentKeyboardState, oldKeyboardState;
        SpriteFont spriteFont;
        List<Enemy> enemies;
        WheelCactus testWheelCactus;
        MapManager mapManager;
        Tile[,] mapBackground, mapForeground;
        int tileSize, screenWidth, screenHeight, tileAmountWidth, tileAmountHeight;
        #endregion

        #region Constructor
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        #endregion

        #region Methods
        protected override void Initialize()
        {
            base.Initialize();
            
            currentKeyboardState = Keyboard.GetState();
        }


        protected override void LoadContent()
        {
            VariableLoader(); 

            graphics.PreferredBackBufferHeight = screenHeight * tileSize;
            graphics.PreferredBackBufferWidth = screenWidth * tileSize;

            TextureLoader();
            GameObjectCreator();
        }

        protected override void UnloadContent()
        {
           
        }

        protected override void Update(GameTime gameTime)
        {
            oldKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();
            player.Update(currentKeyboardState, oldKeyboardState, gameTime);
            foreach (Enemy enemy in enemies)
            {
                enemy.Update();
            }
            player.EnemyCollisionCheck(enemies);
            testWheelCactus.EnemyHurtCheck(enemies, player);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            DrawEverything();
            spriteBatch.End();
            base.Draw(gameTime);
        }

        private void VariableLoader()
        {
            //dessa fem integers ändrar du på om du ändrat tilestorleken, eller mängden tiles
            tileSize = 32;
            screenWidth = 7;
            screenHeight = 4;
            tileAmountWidth = 7;
            tileAmountHeight = 4;
            playerStartPos = new Point(100, 100);
        }

        private void TextureLoader()
        {
            playerTex = Content.Load<Texture2D>(@"PlayerSimpleSheet");
            spriteFont = Content.Load<SpriteFont>(@"SpriteFont");
            hurtTex = Content.Load<Texture2D>(@"HurtBoxGraphic");
            jungleTileSheet = Content.Load<Texture2D>("JungleTileSheet");
            wheelCactusTex = Content.Load<Texture2D>(@"WheelCactusTex");
        }

        private void GameObjectCreator()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            player = new Player(playerTex, playerStartPos, spriteFont, hurtTex);
            mapManager = new MapManager(jungleTileSheet, tileSize, tileAmountWidth, tileAmountHeight);
            mapBackground = mapManager.MapBackgroundBuilder();
            mapForeground = mapManager.MapForegroundBuilder();
            testWheelCactus = new WheelCactus(wheelCactusTex, new Point(300, 300));
            enemies = new List<Enemy>();
            enemies.Add(testWheelCactus);
        }

        private void DrawEverything()
        {
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
        }
        #endregion
    }
}
