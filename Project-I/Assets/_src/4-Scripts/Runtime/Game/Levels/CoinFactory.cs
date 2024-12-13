using System.Collections.Generic;
using ProjectI.Game.Collectables;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace ProjectI.Game.Levels
{
    public class CoinFactory : MonoBehaviour
    {
        [SerializeField] private CoinCollectable coinPrefab;

        private List<GameObject> coins = new();

        private IObjectResolver resolver;

        [Inject]
        internal void Inject(IObjectResolver resolver)
        {
            this.resolver = resolver;
        }

        public CoinCollectable SpawnCoin(CoinSpawnPoint point)
        {
            var coin = Instantiate(coinPrefab, point.transform.position, Quaternion.identity);

            resolver.InjectGameObject(coin.gameObject);

            return coin;
        }

        public void Clear()
        {
            for (var i = coins.Count - 1; i >= 0; i--)
            {
                var coin = coins[i];

                if (coin)
                {
                    Destroy(coin.gameObject);
                }
            }

            coins.Clear();
        }
    }
}