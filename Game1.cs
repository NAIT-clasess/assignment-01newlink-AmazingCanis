using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Assignment_01;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Texture2D _stillSprite;
    private Texture2D _background;

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
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        _stillSprite = Content.Load<Texture2D>("sprite");
        _background = Content.Load<Texture2D>("background");

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();

        // TODO: Add your drawing code here
        
        _spriteBatch.Draw(_background, new Rectangle(0, 0, 640, 320), Color.White);

        _spriteBatch.Draw(_stillSprite, new Rectangle(0, 0, 200, 200), Color.White);

        _spriteBatch.End();
        base.Draw(gameTime);
    }
}
