using System.Xml;
using Microsoft.Xna.Framework;
using Game1.Interfaces;
using Game1.States;
using Game1.Blocks;
using Game1.Items;
using Game1.Scenery;
using Game1.Enemies;
using Game1.GameTool;
using Game1.Utility;

namespace Game1.Factories
{
    public static class WorldFactory
    {
        private const int blockPixel = 16;

        //public static IWorld CreateWorldDeveloper()
        //{
        //    return Load("Design.xml", 100, 100);
        //}

        public static IWorld CreateWorldDeveloper()
        {
            return Load(Util.Instance.Load_rec1, Util.Instance.Load_rec2, Util.Instance.Load_rec3);
        }
        public static IWorld CreateUndergroundWorld()
        {
            return Load("../Level/1-1 hidden.xml",Util.Instance.Load_rec2,Util.Instance.Load_rec3);
        }
        public static IWorld CreateBowserWorld()
        {
            return Load("../Level/Bowser World.xml", Util.Instance.Load_rec2, Util.Instance.Load_rec3);
        }

        private static IWorld Load(string level, int width, int height)
        {
            IWorld world = new World.World(width, height);
            XmlReader reader = XmlReader.Create(Util.Instance.Create_rec1 + level);
            reader.ReadToFollowing(Util.Instance.ReadToFollowing_rec1);
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    string name = reader.Name;
                    string type = reader.GetAttribute(Util.Instance.Type_string);
                    float xPosition = float.Parse(reader.GetAttribute(Util.Instance.String_X));
                    float yPosition = float.Parse(reader.GetAttribute(Util.Instance.String_Y));
                    CreateObjects(world, name, type, xPosition, yPosition);
                }
            }
            return world;
        }

        private static void CreateObjects(IWorld world, string name, string type, float xPosition, float yPosition)
        {
            switch (name)
            {
                case "Player":
                    CreatePlayer(world, type, xPosition, yPosition);
                    break;
                case "Block":
                    CreateBlock(world, type, xPosition, yPosition);
                    break;
                case "Enemy":
                    CreateEnemy(world, type, xPosition, yPosition);
                    break;
                case "Item":
                    CreateItem(world, type, xPosition, yPosition);
                    break;
                case "Scenery":
                    CreateScenery(world, type, xPosition, yPosition);
                    break;
                case "GameObject":
                    CreateGameObject(world, type, xPosition, yPosition);
                    break;
                default:
                    break;
            }
        }

        private static void CreatePlayer(IWorld world, string type, float xPosition, float yPosition)
        {
            switch (type)
            {
                case "Mario":
                    world.Mario.Location = new Vector2(xPosition, yPosition);
                    break;
                default:
                    break;
            }
        }

        private static void CreateBlock(IWorld world, string type, float xPosition, float yPosition)
        {
            switch (type)
            {
                case "BeveledBlock":

                    world.Blocks[(int)xPosition / blockPixel].SingleLevel[(int)yPosition / blockPixel] = new BeveledBlock(new Vector2(xPosition, yPosition));
                    break;
                case "BrickBlock":
                    world.Blocks[(int)xPosition / blockPixel].SingleLevel[(int)yPosition / blockPixel] = new BrickBlock(new Vector2(xPosition, yPosition));
                    break;
                case "GroundBlock":
                    world.Blocks[(int)xPosition / blockPixel].SingleLevel[(int)yPosition / blockPixel] = new GroundBlock(new Vector2(xPosition, yPosition));
                    break;
                case "HiddenBlock":
                    world.Blocks[(int)xPosition / blockPixel].SingleLevel[(int)yPosition / blockPixel] = new HiddenBlock(new Vector2(xPosition, yPosition));
                    break;
                case "Pipe":
                    world.Blocks[(int)xPosition / blockPixel].SingleLevel[(int)yPosition / blockPixel] = new Pipe(new Vector2(xPosition, yPosition), false);
                    break;
                case "EntrancePipe":
                    world.Blocks[(int)xPosition / blockPixel].SingleLevel[(int)yPosition / blockPixel] = new Pipe(new Vector2(xPosition, yPosition), true);
                    break;
                case "QuestionBlock":
                    world.Blocks[(int)xPosition / blockPixel].SingleLevel[(int)yPosition / blockPixel] = new QuestionBlock(new Vector2(xPosition, yPosition));
                    break;
                case "UsedBlock":
                    world.Blocks[(int)xPosition / blockPixel].SingleLevel[(int)yPosition / blockPixel] = new UsedBlock(new Vector2(xPosition, yPosition));
                    break;
                default:
                    break;
            }
        }

        private static void CreateEnemy(IWorld world, string type, float xPosition, float yPosition)
        {
            switch (type)
            {
                case "Goomba":
                    world.Enemies.Add(new Goomba(new Vector2(xPosition, yPosition)));
                    break;
                case "Koopa":
                    world.Enemies.Add(new Koopa(new Vector2(xPosition, yPosition)));
                    break;
                case "Bowser":
                    world.Bosses.Add(new Bowser(new Vector2(xPosition, yPosition)));
                    break;
                default:
                    break;
            }
        }

        private static void CreateItem(IWorld world, string type, float xPosition, float yPosition)
        {
            switch (type)
            {
                case "Flower":
                    world.Items.Add(new Flower(new Vector2(xPosition, yPosition)));
                    break;
                case "Gold":
                    world.Items.Add(new Gold(new Vector2(xPosition, yPosition), false));
                    break;
                case "StaticGold":
                    world.Items.Add(new Gold(new Vector2(xPosition, yPosition), true));
                    break;
                case "GreenMushroom":
                    world.Items.Add(new GreenMushroom(new Vector2(xPosition, yPosition)));
                    break;
                case "RedMushroom":
                    world.Items.Add(new RedMushroom(new Vector2(xPosition, yPosition)));
                    break;
                case "Star":
                    world.Items.Add(new Star(new Vector2(xPosition, yPosition)));
                    break;
                case "EnemyPortal":
                    CreateEnemyPortal(world, type, xPosition, yPosition);
                    break;
                default:
                    break;
            }
        }
        public static void CreateEnemyPortal(IWorld world, string type, float xPosition, float yPosition) => world.EnemyPortals.Add(new EnemyPortal(new Vector2(xPosition, yPosition)));

        private static void CreateScenery(IWorld world, string type, float xPosition, float yPosition)
        {
            switch (type)
            {
                case "BigBush":
                    world.Sceneries.Add(new BigBush(new Vector2(xPosition, yPosition)));
                    break;
                case "SmallBush":
                    world.Sceneries.Add(new SmallBush(new Vector2(xPosition, yPosition)));
                    break;
                case "BigCloud":
                    world.Sceneries.Add(new BigCloud(new Vector2(xPosition, yPosition)));
                    break;
                case "SmallCloud":
                    world.Sceneries.Add(new SmallCloud(new Vector2(xPosition, yPosition)));
                    break;
                case "BigHill":
                    world.Sceneries.Add(new BigHill(new Vector2(xPosition, yPosition)));
                    break;
                case "SmallHill":
                    world.Sceneries.Add(new SmallHill(new Vector2(xPosition, yPosition)));
                    break;
                default:
                    break;
            }
        }


        private static void CreateGameObject(IWorld world, string type, float xPosition, float yPosition)
        {
            switch (type)
            {
                case "Castle":
                    world.Castles.Add(new Castle(new Vector2(xPosition, yPosition)));
                    break;
                case "FlagStuff":
                    world.FlagStuffs.Add(new FlagStuff(new Vector2(xPosition, yPosition)));
                    break;
                case "FireHell":
                    world.FireHells.Add(new FireHell(new Vector2(xPosition, yPosition)));
                    break;
            }
        }
        
    }
}
