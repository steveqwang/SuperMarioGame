using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.Interfaces;
using Game1.States;
using Game1.PhysicalProperty;
using Game1.Commands;
using System.Collections.Generic;
using Game1.Utility;
using Game1.Score;
using Game1.Sound;

namespace Game1.Player
{
    public class MarioPlayer : IPlayer
    {
        public IMarioPowerState CurrentPowerState { get; set; }
        public IMarioActionState CurrentAnimationState { get; set; }
        public IMarioActionState PreviousAnimationState { get; set; }
        private bool isAlive;
        private bool isFlash;
        public IMarioAbilityState CurrentAbilityState { get; set; }
        public MarioPhysicalProperty MarioPhysics{ get; set; }
        public IList<FireballPhysicalProperty> fireballPhysicalProperties { get; set; }
        public Rectangle Rectangle { get; set; }
        public bool IsIdle { get; set; }
        public Vector2 Location { get ; set ; }
        public bool isFacingLeft { get; set; }
        public bool canKick { get; set; }
        public bool IsFire { get; set; }
        public bool canTakeDamage { get; set; }
        private int damageTimer;
        private int starTimer;
        private int deathTimer;
        public int Scores { get; set; }
        public int lifes { get; set; }
        private bool canFallDie;
        public bool resetWorld { get; set; }
        public IList<Fireball> fireballs { get; set; }
        public IList<ScoreObject> ScoreObjects { get; set; }
        public bool MarioLowered { get; set; }
        public int Coefficient { get; set; }
        public bool CanStandOnBlock { get; set; }
        public MarioPlayer()
        {
            PreviousAnimationState = null;
            CurrentPowerState = new MarioSmallState(this);
            CurrentAnimationState = new MarioRightIdleState(this);
            MarioPhysics = new MarioPhysicalProperty(this);
            Rectangle = new Rectangle((int)Location.X, (int)Location.Y, CurrentAnimationState.Width, CurrentAnimationState.Height);
            IsIdle = true;
            isAlive = true;
            isFlash = false;
            canKick = true;
            starTimer = Util.Instance.Zero;
            damageTimer = Util.Instance.Zero;
            deathTimer = Util.Instance.Zero;
            Scores = Util.Instance.Zero;
            lifes = Util.Instance.Int_3;
            fireballs = new List<Fireball>();
            fireballPhysicalProperties = new List<FireballPhysicalProperty>();
            ScoreObjects = new List<ScoreObject>();
            canTakeDamage = true;
            resetWorld = false;
            CanStandOnBlock = true;
            canFallDie = true;
            Coefficient = Util.Instance.Int_1;
        }

        public void TakeDamage()
        {
            if (canTakeDamage && !(CurrentPowerState is MarioSmallState))
            {
                CurrentPowerState = new MarioSmallState(this);
                CurrentAnimationState = new MarioRightIdleState(this);
                Location += new Vector2(Util.Instance.Zero,Util.Instance.Int_15);
                isAlive = true;
                isFlash = true;
                canTakeDamage = false;
            }
            if (canTakeDamage && CurrentPowerState is MarioSmallState)
            {
                lifes--;
                SoundManager.Instance.PlayPlayerDeadMusic();
                isAlive = false;
                canTakeDamage = false;
            }
        }

        public void CheckDeath() {
            if (Location.Y > Util.Instance.ThreeFifty && canFallDie) {
                lifes--;
                SoundManager.Instance.PlayPlayerDeadMusic();
                isAlive = false;
                canFallDie = false;
                CurrentAnimationState = new MarioDeadState();
            }
        }
        public void Up()
        {
             if (CurrentAnimationState is MarioDeadState) return;
             IsIdle = false;
            CurrentAnimationState.Up();
        }
  
        public void Down()
        {
            IsIdle = false;
            if (CurrentPowerState is MarioBigState || CurrentPowerState is MarioStarBigState || CurrentPowerState is MarioFireState)
            {
                Location += new Vector2(Util.Instance.Vector_initial_i, Util.Instance.Go_down_vec2_y);
            }
            CurrentAnimationState.Down();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (!isFlash)
            {
                CurrentAnimationState.Draw(spriteBatch, Location);
            }
            else if (damageTimer % 2 == Util.Instance.Zero)
            {
                CurrentAnimationState.Draw(spriteBatch, Location);
            }
            
            foreach (Fireball fireball in fireballs){
                fireball.Draw(spriteBatch);
            }
            foreach (ScoreObject score in ScoreObjects)
            {
                score.Draw(spriteBatch);
            }
        }

        public void Update(GameTime gametime)
        {
            if (damageTimer == Util.Instance.DamageTimer)
            {
                canTakeDamage = true;
                isFlash = false;
                damageTimer = Util.Instance.Zero;
            }
            if (!canTakeDamage)
            {
                damageTimer++;
            }
            
            if (CurrentPowerState is MarioStarBigState || CurrentPowerState is MarioStarSmallState)
            {
                if (starTimer == Util.Instance.FiveHundreds)
                {
                    if (CurrentPowerState is MarioStarBigState)
                    {
                        CurrentPowerState = new MarioBigState(this);
                    }
                    else
                    {
                        CurrentPowerState = new MarioSmallState(this);
                    }
                    starTimer = Util.Instance.Zero;
                }
                starTimer++;
            }
           
           foreach(Fireball fireball in fireballs)
            {
                fireball.Update(gametime);
            }
           foreach(ScoreObject score in ScoreObjects)
            {
                score.Update(gametime);      
            }
           
            Rectangle = new Rectangle((int)Location.X, (int)Location.Y, CurrentAnimationState.Width, CurrentAnimationState.Height);
            if (IsIdle)
            {
                PreviousAnimationState = CurrentAnimationState;
                CurrentAnimationState.Idle();
                MarioPhysics.Idle();
            }
            IsIdle = true;

            if (!isAlive) {
                CurrentAnimationState = new MarioDeadState();
            }

            CurrentAnimationState.Update(gametime);
            MarioPhysics.Update(gametime);
            CheckDeath();

            if (CurrentAnimationState is MarioDeadState)
            {
                deathTimer++;
            }
            if (deathTimer == Util.Instance.TwoHundreds)
            {
                deathTimer = Util.Instance.Zero;
                resetWorld = true;
            }
        }
    }
}