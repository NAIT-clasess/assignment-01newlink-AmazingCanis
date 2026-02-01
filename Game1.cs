using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SimpleAnimationNamespace;

namespace Assignment_01;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Texture2D _stillSprite;
    private Texture2D _background;

    private SpriteFont _ArialFont;

    private Texture2D _rect;

    private Vector2 _position;

    private float _speed;

    private SimpleAnimation _walkingSprite;

    private SimpleAnimation _explosionSprite;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _graphics.PreferredBackBufferWidth = 640;
        _graphics.PreferredBackBufferHeight = 320;
        _graphics.ApplyChanges();
        _position = new Vector2(10, 50);
        _speed = 120f;
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        _stillSprite = Content.Load<Texture2D>("sprite");
        _background = Content.Load<Texture2D>("background");
        _ArialFont = Content.Load<SpriteFont>("SystemArialFont");
        _walkingSprite = new SimpleAnimation(
            Content.Load<Texture2D>("WalkingSprite"), 128, 128, 4, 8);
        _explosionSprite = new SimpleAnimation(
            Content.Load<Texture2D>("ExplosionSpriteSheet"), 100, 100, 50, 60f);
        _rect = new Texture2D(GraphicsDevice, 1, 1);
        _rect.SetData(new[] { Color.White });

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        Move(gameTime);
        _walkingSprite.Update(gameTime);
        _explosionSprite.Update(gameTime);
        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();

        // TODO: Add your drawing code here
        Rectangle MovingRectangle = new Rectangle((int)_position.X, (int)_position.Y, 100, 100);
        
        _spriteBatch.Draw(_background, new Rectangle(0, 0, 640, 320), Color.White);

        _spriteBatch.Draw(_stillSprite, new Rectangle(0, 0, 200, 200), Color.White);
        
        _spriteBatch.Draw(_rect, MovingRectangle, Color.White);

        _spriteBatch.DrawString(_ArialFont, "Hello, MonoGame!", new Vector2(220, 10), Color.Black);

        _walkingSprite.Draw(_spriteBatch, new Vector2(100,200), SpriteEffects.None);
        _explosionSprite.Draw(_spriteBatch, new Vector2(300, 100), SpriteEffects.None);

        _spriteBatch.End();
        base.Draw(gameTime);
    }
        private void Move(GameTime gameTime)
    {
        float seconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
        _position.X += _speed * seconds;

        base.Update(gameTime);
    }
}
