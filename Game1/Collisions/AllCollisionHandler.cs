using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Interfaces;
using Game1.States;
using Game1.Blocks;
using Microsoft.Xna.Framework;
using Game1.GameTool;
using Game1.Utility;
using Game1.GameStates;
using Game1.Collisions;

namespace Game1.Collisions
{
    public enum Direction { Top, Bottom, Left, Right };

    public class AllCollisionHandler
    {
        public IWorld Level { get; set; }
        public GameStateManager gameState { get; set; }
        int BlockPixel = Util.Instance.BlockPixel;
        int ViewRange = Util.Instance.ViewRange;
        private IPlayer mario;
        private MarioBlockHandler MBHandler;
        private MarioEnemyHandler MEHandler;
        private MarioBossHandler MOHandler;
        private MarioFlagStuffHandler MFHandler;
        private MarioItemHandler MIHandler;
        private MarioCastleCollisionHandler MCHandler;
        private ItemBlockHandler IBHandler;
        private EnemyBlockHandler EBHandler;
        private BossBlockHandler BBHandler;
        private ShellEnemyHandler SEHandler;
        private ShellBossHandler SBHandler;
        private FireBallBlockHandler FBHandler;
        private FireBallEnemyHandler FEHandler;
        private FireBallBossHandler FOHandler;
        private FireShotBlockHandler FSBHandler;
        private FireShotMarioHandler FSMHandler;
        private FireHellMarioHandler FHMHandler;

        public AllCollisionHandler(GameStateManager gameState) {
            this.gameState = gameState;
            Level = gameState.world;
            mario = gameState.world.Mario;
            MBHandler = new MarioBlockHandler();
            MOHandler = new MarioBossHandler();
            MEHandler = new MarioEnemyHandler();
            MFHandler = new MarioFlagStuffHandler();
            MIHandler = new MarioItemHandler();
            MCHandler = new MarioCastleCollisionHandler();
            IBHandler = new ItemBlockHandler();
            EBHandler = new EnemyBlockHandler();
            BBHandler = new BossBlockHandler();
            SEHandler = new ShellEnemyHandler();
            SBHandler = new ShellBossHandler();
            FBHandler = new FireBallBlockHandler();
            FEHandler = new FireBallEnemyHandler();
            FOHandler = new FireBallBossHandler();
            FSBHandler = new FireShotBlockHandler();
            FSMHandler = new FireShotMarioHandler();
            FHMHandler = new FireHellMarioHandler();
        }

        public void CheckAllCollisions() {
            IPlayer mario = Level.Mario;
            Rectangle marioBox = mario.Rectangle;
            CheckMarioBlockCollision(mario);
            MEHandler.CheckMarioEnemyCollision(marioBox, Level);
            MFHandler.CheckMarioFlagCollision(marioBox, Level, gameState);
            MIHandler.CheckMarioItemCollision(marioBox, Level);
            MCHandler.CheckMarioCastleCollision(marioBox, Level, gameState);
            CheckItemBlockCollision();
            CheckEnemyBlockCollision();
            CheckBossBlockCollision();
            SEHandler.CheckShellEnemyCollision(Level, gameState);
            SBHandler.CheckShellBossCollision(Level, gameState);
            CheckFireBallCollision();
            CheckPlayerAndBossDistance(mario);
            if(! (mario.CurrentAnimationState is MarioDeadState))
            {
                MOHandler.CheckMarioBossCollision(marioBox, Level);

                CheckFireShotCollision();

                CheckFireHellCollision();

            }
        }



        public IList<IBlock> FindPotentialBlocksAround(IObjects animationObject) {
            IList<IBlock> BlocksAround = new List<IBlock>();
            int blockIndexX = (int)Math.Floor((float)animationObject.Location.X / BlockPixel);
            int blockIndexY = (int)Math.Floor((float)animationObject.Location.Y / BlockPixel);

            for (int blockIndexOffsetX = -ViewRange; blockIndexOffsetX <= ViewRange; blockIndexOffsetX++)
            {
                for (int blockIndexOffsetY = -ViewRange; blockIndexOffsetY <= ViewRange; blockIndexOffsetY++)
                {
                    int newBlockIndexX = blockIndexX + blockIndexOffsetX;
                    int newBlockIndexY = blockIndexY + blockIndexOffsetY;
                    if (BlockInWord(newBlockIndexX, newBlockIndexY))
                    {
                        IBlock block = Level.Blocks[newBlockIndexX].SingleLevel[newBlockIndexY];
                        BlocksAround.Add(block);
                    }
                }
            }
            return BlocksAround;
        }

        private bool BlockInWord(int blockIndexX, int blockIndexY)
        {

            bool isBlockInWordHorizontal = (blockIndexX >= Util.Instance.BlockIndex_ref) && (blockIndexX < Level.Width);
            bool isBlockInWordVertical = (blockIndexY >= Util.Instance.BlockIndex_ref) && (blockIndexY < Level.Height);

            return isBlockInWordHorizontal && isBlockInWordVertical;
        }


        private void CheckItemBlockCollision()
        {

            foreach (IItem item in Level.Items)
            {
                IList<IBlock> BlocksAround = FindPotentialBlocksAround(item);
                Rectangle itemBox = item.Rectangle;

                IBHandler.CheckItemBlockCollisionLoop(BlocksAround, itemBox, item);
            }
        }

        private void CheckMarioBlockCollision(IPlayer mario)
        {
            IList<IBlock> BlocksAround = FindPotentialBlocksAround(mario);

            MBHandler.CheckMarioBlockCollisionLoop(mario, BlocksAround, Level, gameState);

        }

        private void CheckEnemyBlockCollision()
        {
            foreach (IEnemy enemy in Level.Enemies)
            {
                Rectangle enemyBox = enemy.Rectangle;
                IList<IBlock> BlocksAround = FindPotentialBlocksAround(enemy);
                EBHandler.CheckEnemyBlockCollisionLoop(BlocksAround, enemy);
            }
        }

        private void CheckBossBlockCollision()
        {
            foreach (IBoss boss in Level.Bosses)
            {
                Rectangle bossBox = boss.Rectangle;
                IList<IBlock> BlocksAround = FindPotentialBlocksAround(boss);
                BBHandler.CheckBossBlockCollisionLoop(BlocksAround, boss);
            }
        }

        private void CheckFireBallCollision()
        {
            //check block collision
            foreach (Fireball fireball in Level.Mario.fireballs)
            {
                Rectangle fireballBox = fireball.Rectangle;
                IList<IBlock> BlocksAround = FindPotentialBlocksAround(fireball);
                FBHandler.FireBallHandleLoop(BlocksAround, fireball);
                FEHandler.FireBallHandleLoop(BlocksAround, fireball, fireballBox, Level, mario);
                FOHandler.FireBallHandleLoop(BlocksAround, fireball, fireballBox, Level, mario);
            }

        }

        private void CheckFireShotCollision()
        {
            foreach (IBoss boss in Level.Bosses)
            {
                foreach(FireShot fireshot in boss.fireShots)
                {
                    Rectangle fireshotBox = fireshot.Rectangle;
                    IList<IBlock> BlockAround = FindPotentialBlocksAround(fireshot);
                    FSBHandler.FireShotHandleLoop(BlockAround, fireshot);
                    FSMHandler.FireShotHandleLoop(mario, fireshot);
                }
            }
        }

        private void CheckFireHellCollision()
        {
            foreach(FireHell fireHell in Level.FireHells)
            {
                Rectangle fireHellBox = fireHell.Rectangle;
                IList<IBlock> BlockAround = FindPotentialBlocksAround(fireHell);
                FHMHandler.FireHellHandleLoop(mario, fireHell);
            }
        }



        public static Direction GetCollisionDirection(Rectangle intersectionBox, Rectangle marioBox, Rectangle gameObjectBox) {
            if (intersectionBox.Width >= intersectionBox.Height)
            {
                return marioBox.Top <= gameObjectBox.Top ? Direction.Top : Direction.Bottom;
            }
            else {
                return marioBox.Left <= gameObjectBox.Left ? Direction.Left : Direction.Right;
            }

        }

        public void CheckPlayerAndBossDistance(IPlayer mario)
        {
            foreach (IBoss boss in Level.Bosses)
            {
                if(Math.Abs(boss.Location.X - mario.Location.X) < 100)
                {
                    boss.IsActivate = true;
                }
                else if(mario.Location.Y < boss.Location.Y)
                {
                    boss.IsActivate = true;
                }
                else
                {
                    boss.IsActivate = false;
                }

            }
        }

    }
}
