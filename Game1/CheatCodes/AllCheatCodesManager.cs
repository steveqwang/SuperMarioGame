using System;
using System.Collections.Generic;
using Game1.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Game1.Utility;
using Game1.GameStates;
using Game1.States;
using Game1.Factories;

namespace Game1.CheatCodes
{
    class AllCheatCodesManager : ICheatCode
    {
        public Queue<string> inputString { get; set; }
        public bool CheatcodeSwitch { get; set; }

        private readonly Dictionary<string, Action> MappingDictionary;
        private float CDTime { get; set; } 
        private bool KeyPressed { get; set; }
        private int maxLength;
        private GameStateManager state;
        private IPlayer player;

     

        public AllCheatCodesManager(GameStateManager State)
        {
            state = State;
            player = State.world.Mario;
            CDTime = Util.Instance.Zero;
            CheatcodeSwitch = false; // we can not turn on cheat code at first
            KeyPressed = false;
            inputString = new Queue<string>();
            maxLength = Util.Instance.Five;
            MappingDictionary = new Dictionary<string, Action>
            {
                { Util.Instance.String_GOBIG, () => ExecuteGOBig()},
                { Util.Instance.String_XFIRE, () => ExecuteXFIRE()},
                { Util.Instance.String_SMALL, () => ExecuteSMALL()},
            };

            }

        private void GetInputs() {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();
       
           
            if (pressedKeys.Length > 0)
            {
                
                EnqueueInput(pressedKeys[0]); // we only allow one input key at one time
            }
            else {
                ReleaseKey();
            }
            CheckInputs();
            
        }

        private void CheckInputs()
        {
            string input = GetInputString();
            if (MappingDictionary.ContainsKey(input)) {
                MappingDictionary[input].Invoke();
                ResetInput();
            }


        }

        private string GetInputString() {
            string input = string.Empty;
            foreach (string key in inputString) {
                input = input + key;
            }
            return input;
        }
        private void EnqueueInput(Keys pressedKey)
        {
            if (!KeyPressed) {
                KeyPressed = true;
                inputString.Enqueue(pressedKey.ToString());
               
               
                if (inputString.Count >maxLength) {
                    inputString.Dequeue();
                }
            }
        }
        private void ReleaseKey() {
           if(KeyPressed) KeyPressed = false;
        }

        private void ResetCooldown()
        {
           CheatcodeSwitch = true;
            CDTime = Util.Instance.One;
        }

        private void UpdateCooldown(GameTime gameTime)
        {
           CDTime -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (CDTime <= 0)
            {
                CDTime = Util.Instance.Zero;
                CheatcodeSwitch = false;

            }
        }

        private void ResetInput()
        {
            inputString.Clear();
            ResetCooldown();
        }

        private void ExecuteGOBig() {
            player.CurrentPowerState = new MarioBigState(player);
            player.CurrentAnimationState = new MarioRightIdleState(player);
            SoundFactory.Instance.PlayGetPowerSound();
        }

        private void ExecuteSMALL()
        {
            player.CurrentPowerState = new MarioSmallState(player);
            player.CurrentAnimationState = new MarioRightIdleState(player);
            SoundFactory.Instance.PlayGetPowerSound();
        }

        private void ExecuteXFIRE() {
            player.CurrentPowerState = new MarioFireState(player);
            player.CurrentAnimationState = new MarioRightIdleState(player);
            SoundFactory.Instance.PlayGetPowerSound();
        }

        public void Update(GameTime gameTime)
        {
           UpdateCooldown(gameTime);
           if(!CheatcodeSwitch) GetInputs();
        }
    }
}
