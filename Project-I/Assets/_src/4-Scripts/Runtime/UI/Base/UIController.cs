using UnityEngine;

namespace ProjectI.UI
{
    public class UIController : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}