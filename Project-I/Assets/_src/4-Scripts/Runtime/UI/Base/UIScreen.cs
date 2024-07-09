using UnityEngine;

namespace ProjectI.UI
{
    [RequireComponent(typeof(Canvas), (typeof(CanvasGroup)))]
    public abstract class UIScreen : MonoBehaviour
    {
        protected CanvasGroup canvasGroup;
        protected RouterArgs args;

        protected void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        public virtual void Show(RouterArgs args = null)
        {
            this.args = args;
            
            canvasGroup.interactable = true;
            canvasGroup.alpha = 1;
        }

        public virtual void Hide()
        {
            args = null;

            canvasGroup.interactable = false;
            canvasGroup.alpha = 0;
        }
    }
}