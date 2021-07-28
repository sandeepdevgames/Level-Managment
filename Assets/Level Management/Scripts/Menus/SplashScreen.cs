using System.Collections;
using UnityEngine;

namespace LevelManagement
{
    public class SplashScreen : MonoBehaviour
    {
        [Header("Variables")]
        [SerializeField] float waitToFade = 2f;

        [Header("Components")]
        [SerializeField] SplashFader screenFader;

        private void Awake()
        {
            screenFader = GetComponent<SplashFader>();            
        }

        private void Start()
        {
            screenFader.FadeOn();
        }

        public void FadeAndLoad ()
        {
            StartCoroutine(FadeAndLoadRoutine());
        }

        private IEnumerator FadeAndLoadRoutine()
        {
            LevelLoader.LoadMainMenuLevel();

            yield return new WaitForSeconds(waitToFade);
            
            screenFader.FadeOff();

            // Waite to fade
            yield return new WaitForSeconds(screenFader.FadeDuration);

            // Remove Splash
            Object.Destroy(gameObject);
        }
    } 
}
