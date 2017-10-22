using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using TaskNo1;

namespace PingPong
{
    public class Game1 : Game
    {
        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;

        public Paddle PaddleBottom { get; private set; }
        public Paddle PaddleTop { get; private set; }
        public Ball Ball { get; private set; }
        public Background Background { get; private set; }
        public SoundEffect HitSound { get; private set; }
        public Song Music { get; private set; }
        private IGenericList <Sprite > SpritesForDrawList = new GenericList <Sprite >();


        
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferHeight = 900,
                PreferredBackBufferWidth = 500
            };
            Content.RootDirectory = "Content";

        }

        protected override void Initialize()
        {
            var screenBounds = GraphicsDevice.Viewport.Bounds; 
            PaddleBottom = new Paddle(GameConstants.PaddleDefaultWidth ,
                GameConstants.PaddleDefaulHeight , GameConstants.PaddleDefaulSpeed);
            PaddleBottom.X = screenBounds.Width / 2f - PaddleBottom.Width / 2f; 
            PaddleBottom.Y = screenBounds.Bottom - PaddleBottom.Height;
            PaddleTop = new Paddle(0, 0, 0); PaddleTop.X = 0;
            PaddleTop.Y = 0;
            Ball = new Ball(0, 0, 0) {
                X = 0,
                Y=0 };
            Background = new Background(screenBounds.Width, screenBounds.Height);
            // Add our game objects to the sprites that should be drawn collection.
            SpritesForDrawList.Add(Background); SpritesForDrawList.Add(PaddleBottom); 
            SpritesForDrawList.Add(PaddleTop); SpritesForDrawList.Add(Ball);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Initialize new SpriteBatch object which will be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            // Set textures
            Texture2D paddleTexture = Content.Load<Texture2D>("paddle"); 
            PaddleBottom.Texture = paddleTexture;
            PaddleTop.Texture = paddleTexture;
            Ball.Texture = Content.Load<Texture2D>("ball"); 
            Background.Texture = Content.Load<Texture2D>("background");
            // Load sounds
            // Start background music
            HitSound = Content.Load<SoundEffect>("hit");
            Music = Content.Load<Song>("music");
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(Music);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == 
                ButtonState.Pressed || Keyboard.GetState().IsKeyDown(
                    Keys.Escape))
                Exit();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // Start drawing.
            spriteBatch.Begin();
            for (int i = 0; i < SpritesForDrawList.Count; i++) {
                SpritesForDrawList.GetElement(i).DrawSpriteOnScreen(spriteBatch); }
            // End drawing.
            // Send all gathered details to the graphic card in one batch.
            
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}