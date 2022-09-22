using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MopoxFighter;

public class Game1 : Game
{
    private Vector2 ballPosition;
    private float ballSpeed;
    private AnimatedSprite animatedSprite;
    
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        Debug.WriteLine("test");
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        ballPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2, 
            _graphics.PreferredBackBufferHeight / 2);
        ballSpeed = 100f;
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        
        Texture2D texture = Content.Load<Texture2D>("phant");
        animatedSprite = new AnimatedSprite(texture, 1, 4);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        
        var kstate = Keyboard.GetState();
        if (kstate.IsKeyDown(Keys.Up))
        {
            ballPosition.Y -= ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
        if (kstate.IsKeyDown(Keys.Down))
        {
            ballPosition.Y += ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
        if (kstate.IsKeyDown(Keys.Left))
        {
            ballPosition.X -= ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
        if (kstate.IsKeyDown(Keys.Right))
        {
            ballPosition.X += ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
        animatedSprite.Update((double)gameTime.ElapsedGameTime.TotalSeconds);
        
        // TODO: Add your update logic here
        /*if(ballPosition.X > _graphics.PreferredBackBufferWidth - ballTexture.Width / 2)
        {
            ballPosition.X = _graphics.PreferredBackBufferWidth - ballTexture.Width / 2;
        }
        else if(ballPosition.X < ballTexture.Width / 2)
        {
            ballPosition.X = ballTexture.Width / 2;
        }

        if(ballPosition.Y > _graphics.PreferredBackBufferHeight - ballTexture.Height / 2)
        {
            ballPosition.Y = _graphics.PreferredBackBufferHeight - ballTexture.Height / 2;
        }
        else if(ballPosition.Y < ballTexture.Height / 2)
        {
            ballPosition.Y = ballTexture.Height / 2;
        }*/
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.White);
        
        animatedSprite.Draw(_spriteBatch, ballPosition);
        Debug.WriteLine("test");

        base.Draw(gameTime);
    }
}
