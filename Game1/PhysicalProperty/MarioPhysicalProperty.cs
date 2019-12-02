using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Game1.Interfaces;
using Game1.States;
using Game1.Factories;
using Game1.Utility;

namespace Game1.PhysicalProperty
{
    public class MarioPhysicalProperty
    {
        private IPlayer mario;
        private bool isInitalJump;
        private bool isAirJump;
        private double jumpTime; 
        public Vector2 Velocity { get; set; }
        public Vector2 Accerlation { get; set; }
        public bool IsEndGame { get; set; }
        private bool isInitialRun;
        


        public MarioPhysicalProperty(IPlayer player) {
            Velocity = new Vector2(0f,128);
            Accerlation = new Vector2();
            mario = player;
            isInitalJump = true;
            isAirJump = false;
            jumpTime = 1f;
            isInitialRun = true;
            IsEndGame = false;
        }

        public void VerticalCalmDown() {
            Accerlation = new Vector2(Accerlation.X, 0f);
            Velocity = new Vector2(Velocity.X, 0f);
        }

      
        public void Idle() {
            Accerlation = new Vector2(Accerlation.X, 1000);
            Velocity = new Vector2(Velocity.X*0.95f , Velocity.Y);
            if (Velocity.Y < 0)
            {
                Velocity = new Vector2(Velocity.X, Velocity.Y * 0.8f);
            }

        }
      
        public void Jump() {
            if (!IsEndGame){
                if (isInitalJump) {
                    Velocity = new Vector2(Velocity.X, -350);
                    Accerlation = new Vector2(0f, 640);
                    isInitalJump = false;
                    isAirJump = true;
                    if(mario.CurrentPowerState is MarioSmallState)
                    {
                        SoundFactory.Instance.PlaySmallJumpSound();
                    }
                    else
                    {
                        SoundFactory.Instance.PlaySuperJumpSound();
                    }
                }
                if (isAirJump) {
                    Accerlation = new Vector2(0f, 640);
                }
            }
           
        }
        public void Run()
        {
            if (isInitialRun)
            {
                Velocity = new Vector2(mario.isFacingLeft ? -50 : 50, Velocity.Y);
                isInitialRun = false;
            }
            Accerlation = new Vector2(mario.isFacingLeft ? -100 : 100, 640);
        }
        public void ResetRun()
        {
            isInitialRun = true;
        }
        public void UpdateRunningAcceleration()
        {
            if(mario.CurrentAnimationState is MarioDeadState)
            {
                Velocity = new Vector2(0, Velocity.Y);
                Accerlation = new Vector2(0, Accerlation.Y);
                ResetRun();
            }
            if(mario.CurrentAnimationState is MarioLeftIdleState &&mario.PreviousAnimationState is MarioLeftRunState
                || mario.CurrentAnimationState is MarioLeftIdleState && mario.PreviousAnimationState is MarioLeftIdleState)
            {
                
                Accerlation = new Vector2(100, Accerlation.Y);
                if (Velocity.X >= 0)
                {
                    Velocity = new Vector2(0, Velocity.Y);
                    Accerlation = new Vector2(0, Accerlation.Y);
                    ResetRun();
                }
            }
            if (mario.CurrentAnimationState is MarioRightIdleState && mario.PreviousAnimationState is MarioRightRunState
                || mario.CurrentAnimationState is MarioRightIdleState && mario.PreviousAnimationState is MarioRightIdleState)
            {
                Accerlation = new Vector2(-100, Accerlation.Y);
                if (Velocity.X <= 0)
                {
                    Velocity = new Vector2(0, Velocity.Y);
                    Accerlation = new Vector2(0, Accerlation.Y);
                    ResetRun();
                }
            }
        }
        public void ResetJump() {
            isInitalJump = true;
            isAirJump = false;
            jumpTime = 1f;
        }

        public void DragFlag()
        {
            Velocity = Vector2.Zero;
            Accerlation = Vector2.Zero;
            Velocity = new Vector2(0, 200); //dragflagvelocity
            
        }

        public void Update(GameTime gametime) {
            float deltaTime = (float)gametime.ElapsedGameTime.TotalSeconds;
            UpdateRunningAcceleration();
            if (Velocity.Y > 256 || Math.Abs(Velocity.X)>30)
            {
                if (Velocity.Y > 256)
                {
                    Velocity = new Vector2(Velocity.X, 256);
                }
                if (Math.Abs(Velocity.X) > 30)
                {
                    Velocity = new Vector2((Velocity.X<0)?-30:30, Velocity.Y);
                }
                
            }
            else {
                Velocity += Accerlation * deltaTime;
              
            }
            if (!(mario.CurrentAnimationState is MarioDeadState))
            {
                mario.Location += Velocity * deltaTime;
            }
            if (IsEndGame)
            {
                mario.Location += new Vector2(Util.Instance.Turn_R_vec_x, Util.Instance.Vector_initial_j);
            }
            if (isAirJump) {
                jumpTime -= deltaTime;
                if (jumpTime < 0) {
                    isAirJump = false;
                }
            }
            }
        }

    }

