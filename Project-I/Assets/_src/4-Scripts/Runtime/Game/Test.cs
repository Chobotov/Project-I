using PorjectI.Services;
using UnityEngine;
using VContainer;

namespace PorjectI.Game
{
    public class Test : MonoBehaviour
    {
        private IRouterService routerService;

        [Inject]
        public void Inject(IRouterService routerService)
        {
            this.routerService = routerService;
        }

        private void Start()
        {
            routerService.Notify();
        }
    }
}