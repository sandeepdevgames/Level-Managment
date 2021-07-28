using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

namespace LevelManagement
{
    public class MenuManager : MonoBehaviour
    {        
        [Header("Menus")]
        [SerializeField] MainMenu mainMenuPrefab;
        [SerializeField] SettingMenu settingMenuPrefab;
        [SerializeField] CreditsScreen creditsMenuPrefab;
        [SerializeField] PauseMenu pauseMenuPrefab;
        [SerializeField] GameMenu gameMenuPrefab;
        [SerializeField] WinScreen winScreenPrefab;
        [SerializeField] LevelSelectionMenu levelSelectionMenuPrefab;
        [SerializeField] Transform menuParent;   // when menu are created

        [Header("Stack")]
        private Stack<Menu> menuStack = new Stack<Menu>();

        private static MenuManager instance;

        public static MenuManager Instance { get => instance; }

        private void Awake()
        {
            if (instance != null)
                Destroy(this.gameObject);
            else
            {
                instance = this;
                InitiazeMenus();

                Object.DontDestroyOnLoad(gameObject);
            }
        }

        private void OnDestroy()
        {
            if(instance == this)
                instance = null;
        }

        void InitiazeMenus()
        {
            // Transform
            if(menuParent == null)
            {
                GameObject menuParentObject = new GameObject("Menu");
                menuParent = menuParentObject.transform;
            }
            Object.DontDestroyOnLoad(menuParent.gameObject);

            FieldInfo[] fields = this.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);
            
            foreach(FieldInfo field in fields)
            {
                Menu prefab = field.GetValue(this) as Menu;

                if(prefab != null)
                {
                    Menu menuInstance = Instantiate(prefab, menuParent);

                    if (prefab != mainMenuPrefab)
                        menuInstance.gameObject.SetActive(false);
                    else
                    {
                        OpenMenu(menuInstance);
                    }
                }
            }
        }

        public void OpenMenu(Menu menuInstance)
        {
            if (menuInstance == null)
            {
                Debug.LogWarning("Load Level doesn't exits");
                return;
            }

            foreach (Menu menu in menuStack)
            {
                menu.gameObject.SetActive(false);
            }

            menuInstance.gameObject.SetActive(true);
            menuStack.Push(menuInstance);
        }

        public void CloseMenu ()
        {
            if (menuStack.Count == 0)
            {
                Debug.LogWarning("No more menu in the stack to close");
                return;
            }

            Menu topMenu = menuStack.Pop(); // to remove the item from the top of the stack
            topMenu.gameObject.SetActive(false);

            if(menuStack.Count > 0) // turn on next menu is the deep fores
            {
                Menu nextMenu = menuStack.Peek(); // next menu in the queue
                nextMenu.gameObject.SetActive(true);
            }
        }
    }
}

