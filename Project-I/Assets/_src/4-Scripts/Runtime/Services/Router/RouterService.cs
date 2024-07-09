using ProjectI.UI;

namespace ProjectI.Services
{
    public class RouterService : IRouterService
    {
        private readonly RouterController routerController;

        public RouterService(RouterController routerController)
        {
            this.routerController = routerController;
        }

        public void Show()
        {
        }
    }
}