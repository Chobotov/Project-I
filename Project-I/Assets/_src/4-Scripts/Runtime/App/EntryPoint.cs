using UnityEngine;
using UnityEngine.SceneManagement;

namespace PorjectI.App
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private GameLifetimeScope gameScope;

        private void Awake()
        {
            Debug.Log($"System : Start Init");

            gameScope.Build();

            Debug.Log($"System : End Init");

            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            Debug.Log($"Scene Manager : Load Game Scene");

            SceneManager.LoadScene("Game");
        }
    }
}