using Game1.Factories;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;

namespace Game1.Sound
{
    public class SoundManager
    {
        private Song currentSong;

        private static readonly SoundManager instance = new SoundManager();
        public static SoundManager Instance { get => instance; }

        private SoundManager()
        {

        }

        public void PlayMainSong()
        {
            currentSong = SoundFactory.Instance.PlayMainSong;
            MediaPlayer.Play(currentSong);
            MediaPlayer.IsRepeating = true;
        }

        public void PlayMenuSong()
        {
            currentSong = SoundFactory.Instance.PlayMenuSong;
            MediaPlayer.Play(currentSong);
            MediaPlayer.IsRepeating = true;
        }

        public void PlayGameOverSong()
        {
            currentSong = SoundFactory.Instance.PlayGameOverSong;
            MediaPlayer.Play(currentSong);
            MediaPlayer.IsRepeating = false;
        }

        public void PlayPlayerDeadMusic()
        {
            currentSong = SoundFactory.Instance.PlayDeadSong;
            MediaPlayer.Play(currentSong);
            MediaPlayer.IsRepeating = false;
        }
    }
}