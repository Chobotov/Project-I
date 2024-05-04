using PorjectI.UI;

namespace PorjectI.Services
{
    public class RouterService : IRouterService
    {
        private readonly UIController uiController;

        public RouterService(UIController uiController)
        {
            this.uiController = uiController;
        }

        public void Notify()
        {
            uiController.Notify();
        }
    }
}