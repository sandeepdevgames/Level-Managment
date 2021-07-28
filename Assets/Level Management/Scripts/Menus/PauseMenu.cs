using UnityEngine;

namespace LevelManagement
{
    public class PauseMenu : Menu<PauseMenu>
    {
        public void OnResumePressed ()
        {
            base.OnBackPressed();

            Time.timeScale = 1;
        }

        public void OnRestartPressed ()
        {
            Time.timeScale = 1;
            LevelLoader.Reload();

            base.OnBackPressed();
        }

        public void OnMainMenuPressed ()
        {
            Time.timeScale = 1;
            LevelLoader.LoadMainMenuLevel();

            MainMenu.Open();
        }

        public void OnQuitPressed ()
        {
            Application.Quit();
        }
    }
}
