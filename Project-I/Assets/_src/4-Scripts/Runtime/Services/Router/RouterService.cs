using ProjectI.UI;

namespace ProjectI.Services
{
    public class RouterService : IRouterService
    {
        private readonly UIController uiController;

        public RouterService(UIController uiController)
        {
            this.uiController = uiController;
        }

        public void Show()
        {
        }
    }
}