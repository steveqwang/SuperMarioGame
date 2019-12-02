using Game1.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.World;

namespace Game1.Score 
{
    public class ScoreObject
    {
        public bool IsRemoved { get; set; }
        private SpriteFont spriteFont;
        private string score;
        private Vector2 location;
        private Vector2 initialLocation;
        private bool fixLocation;
        public bool multipleKill;
        public float multipleKillExistTime;

        public ScoreObject(int score, Vector2 Location, bool fixLocation)
        {
            spriteFont = MenuFactory.Instance.CreateSpriteFont();
            this.score = score.ToString();
            location = Location;
            initialLocation = location;
            this.fixLocation = fixLocation;
            IsRemoved = false;
            multipleKill = true;
            multipleKillExistTime = 50f;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(spriteFont, score, location, Color.White);
        }

        public void Update(GameTime gametime)
        {
            --location.Y;
            if ((int)Math.Abs((location.Y) - (initialLocation.Y)) > 50)
            {
                IsRemoved = true;
            }
            if(multipleKillExistTime <= 0)
            {
                multipleKillExistTime = 10f;
                multipleKill = false;
            }
            else
            {
                multipleKillExistTime--;
            }

        }
    }
}
