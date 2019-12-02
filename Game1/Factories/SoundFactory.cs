using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Factories
{
    public class SoundFactory
    {
        private Song worldSong;
        private Song worldAccelerateSong;
        private Song playerDieSong;
        private Song gameOverSong;
        private Song powerSong;
        private Song menuModeSong;

        private SoundEffect breakBlock;
        private SoundEffect collectCoin;
        private SoundEffect fireball;
        private SoundEffect smallJump;
        private SoundEffect superJump;
        private SoundEffect reachFlagStuff;
        private SoundEffect kickEnemy;
        private SoundEffect bumpBlock;
        private SoundEffect enterPipe;
        private SoundEffect spawnPowerUp;
        private SoundEffect getPowerUp;
        private SoundEffect pauseMode;
        private SoundEffect stompEnemy;

        private static readonly SoundFactory instance = new SoundFactory();
        public static SoundFactory Instance { get => instance; }

        private SoundFactory()
        {

        }

        public void LoadAllTextures (ContentManager content)
        {
            worldSong = content.Load<Song>("Song/mainSong");
            worldAccelerateSong = content.Load<Song>("Song/hurrySong");
            playerDieSong = content.Load<Song>("Song/deadSong");
            gameOverSong = content.Load<Song>("Song/gameOverSong");
            powerSong = content.Load<Song>("Song/starModeSong");
            menuModeSong = content.Load<Song>("SOng/menuSong");


            breakBlock = content.Load<SoundEffect>("Sound/breakBlock");
            collectCoin = content.Load<SoundEffect>("Sound/coin");
            fireball = content.Load<SoundEffect>("Sound/fireball");
            smallJump = content.Load<SoundEffect>("Sound/smallJump");
            superJump = content.Load<SoundEffect>("Sound/superJump");
            reachFlagStuff = content.Load<SoundEffect>("Sound/flagStuff");
            kickEnemy = content.Load<SoundEffect>("Sound/kick");
            bumpBlock = content.Load<SoundEffect>("Sound/bump");
            enterPipe = content.Load<SoundEffect>("Sound/pipe");
            spawnPowerUp = content.Load<SoundEffect>("Sound/powerupAppear");
            getPowerUp = content.Load<SoundEffect>("Sound/powerup");
            pauseMode = content.Load<SoundEffect>("Sound/pause");
            stompEnemy = content.Load<SoundEffect>("Sound/stomp");
        }

        public void PlayBreakBlockSound()
        {
            breakBlock.Play();
        }

        public void PlayCollectionSound()
        {
            collectCoin.Play();
        }

        public void PlayFireballSound()
        {
            fireball.Play();
        }

        public void PlaySmallJumpSound()
        {
            smallJump.Play();
        }
        public void PlaySuperJumpSound()
        {
            superJump.Play();
        }

        public void PlayReachFlagStuffSound()
        {
            reachFlagStuff.Play();
        }

        public void PlayKickEnemySound()
        {
            kickEnemy.Play();
        }

        public void PlayBumpBlockSound()
        {
            bumpBlock.Play();
        }

        public void PlayEnterPipeSound()
        {
            enterPipe.Play();
        }

        public void PlaySpawnPowerUpSound()
        {
            spawnPowerUp.Play();
        }

        public void PlayGetPowerSound()
        {
            getPowerUp.Play();
        }

        public void PlayPauseModeSound()
        {
            pauseMode.Play();
        }

        public void PlayStompEnemySound()
        {
            stompEnemy.Play();
        }

        public Song PlayMainSong { get => worldSong; }
        public Song PlayMenuSong { get => menuModeSong; }

        public Song PlayGameOverSong { get => gameOverSong; }
        public Song PlayDeadSong { get => playerDieSong; }
        

    }
}
