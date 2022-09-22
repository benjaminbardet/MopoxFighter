using System.Diagnostics;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MopoxFighter;


public class AnimatedSprite
{
    public Texture2D Texture { get; set; }
    public int Rows { get; set; }
    public int Columns { get; set; }
    private int currentFrame;
    private int totalFrames;
    private double timeToFrame;
    private double lastUpdate;
    
    public AnimatedSprite(Texture2D texture, int rows, int columns)
    {
        Texture = texture;
        Rows = rows;
        Columns = columns;
        currentFrame = 0;
        totalFrames = Rows * Columns;
        timeToFrame = 0.25;  
        lastUpdate = 0;
    }
    
    public void Update(double time)
    {
        if (timeToFrame < lastUpdate)
        {
            currentFrame++;
            if (currentFrame + 1 == Columns)
            {
                currentFrame = 0;
            }

            lastUpdate = 0;
        }
        lastUpdate += time;
        
    }
    
    public void Draw(SpriteBatch spriteBatch, Vector2 location)
    {
        int width = Texture.Width / Columns;
        int height = Texture.Height / Rows;
        int row = currentFrame / Columns;
        int column = currentFrame % Columns;
 
        Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
        Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);
 
        spriteBatch.Begin();
        spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
        spriteBatch.End();
    }
}