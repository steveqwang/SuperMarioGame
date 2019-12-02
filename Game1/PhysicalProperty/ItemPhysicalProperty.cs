using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Game1.Interfaces;
using Game1.States;

namespace Game1.PhysicalProperty
{
    public class ItemPhysicalProperty
    {
        public Vector2 Velocity { get; set; }
        public Vector2 Accerlation { get; set; }
        public bool isFacingLeft { get; set; }
        public bool isOnBlock { get; set; }
        
        private IItem item;
        private bool canMove { get; set; }
        private float itemSpeed;
        private const float ItemInitialSpeedX = 18f;
        private const float GravityAccerlation = 1000f;
        private const float ItemInitialJumpSpeedY = -250f;

        public ItemPhysicalProperty(IItem item, bool movable)
        {
            this.item = item;
            canMove = movable;
            
            isFacingLeft = true;
            isOnBlock = true;
            if (movable)
            {
                itemSpeed = ItemInitialSpeedX;
                ItemMove();
            }
            else {
                ItemJump();
            }
            
        }

        public void VerticalCalmDown() {
            Accerlation = new Vector2(Accerlation.X, 0f);
            Velocity = new Vector2(Velocity.X, 0f);
        }

        public void ItemMove()
        {
            Accerlation = new Vector2(0,GravityAccerlation);
            SetSpeed();
            Velocity = new Vector2(itemSpeed, Velocity.Y);
        }
        public void changeDirection() {
            Velocity = new Vector2(-Velocity.X, Velocity.Y);
        }
        private void ItemJump() {
            Velocity = new Vector2(0, ItemInitialJumpSpeedY);
            Accerlation = new Vector2(0, GravityAccerlation);
        }

        private void SetSpeed()
        {
            if (isFacingLeft)
            {
                itemSpeed = -Math.Abs(itemSpeed);
            }
            else
            {
                itemSpeed = Math.Abs(itemSpeed);
            }
        }

        public void Update(GameTime gametime)
        {
            float deltaTime = (float)gametime.ElapsedGameTime.TotalSeconds;
            if (Velocity.Y > 256)
            {
                Velocity = new Vector2(Velocity.X, 256);
            }
            else
            {
                Velocity += Accerlation * deltaTime;
            }
            item.Location += Velocity * deltaTime;
        }
    }
}
