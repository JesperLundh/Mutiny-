using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Mutiny_
{
    public class Game1 : Game
        //Grundläggande kod för att hantera Playerklassen skapad av Sara
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Player player;
        Point startPos;
        Texture2D playerTex;
        KeyboardState currentKeyboardState;
        KeyboardState oldKeyboardState;
        SpriteFont spriteFont;

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
            startPos = new Point(100, 100);
            playerTex = Content.Load<Texture2D>(@"PlayerSimpleSheet");
            spriteFont = Content.Load<SpriteFont>(@"spriteFont");
            player = new Player(playerTex, startPos, spriteFont);
            
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



            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            player.Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
