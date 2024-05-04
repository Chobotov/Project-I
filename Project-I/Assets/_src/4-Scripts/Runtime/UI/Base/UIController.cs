using UnityEngine;

namespace PorjectI.UI
{
    public class UIController : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}