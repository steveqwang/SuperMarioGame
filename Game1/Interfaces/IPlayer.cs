using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Game1.PhysicalProperty;
using Game1.Score;

namespace Game1.Interfaces
{
    public interface IPlayer: IObjects
    {
        IMarioPowerState CurrentPowerState { get; set; }
        IMarioActionState CurrentAnimationState { get; set; }
        IMarioActionState PreviousAnimationState { get; set; }
        MarioPhysicalProperty MarioPhysics { get; set; }
        IList<Fireball> fireballs { get; set; }
        IList<ScoreObject> ScoreObjects { get; set; }
        int Scores { get; set; }
        int lifes { get; set; }
        IList<FireballPhysicalProperty> fireballPhysicalProperties { get; set; }
        int Coefficient { get; set; }
        bool IsIdle { get; set; }
        void TakeDamage();
        bool canKick { get; set; }
        bool isFacingLeft { get; set; }
        bool canTakeDamage { get; set; }
        bool resetWorld { get; set; }
        void Up();
        void Down();
        bool CanStandOnBlock { get; set; }
    }
}
