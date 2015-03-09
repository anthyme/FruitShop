using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;

namespace FruitShop
{
    public class Checkout
    {
        private readonly Dictionary<Articles, int> _costs = new Dictionary<Articles, int>()
        {
            {Articles.Pommes, 100},
            {Articles.Cerises, 75},
            {Articles.Bananes, 150},
        };

        private readonly ICollection<Articles> _articles = new List<Articles>();

        public string Add(string parameter)
        {
            var article = (Articles)Enum.Parse(typeof(Articles), parameter);
            _articles.Add(article);
            return ApplyReductions(ComputeRawTotal()).ToString();
        }

        private int ComputeRawTotal()
        {
            return _articles.Select(a => _costs[a]).Sum();
        }

        private int ApplyReductions(int total)
        {
            return total - Compute2CerisesGot20CentsReduction(total);
        }

        private int Compute2CerisesGot20CentsReduction(int total)
        {
            return (_articles.Count(a => a == Articles.Cerises) / 2) * 20;
        }
    }

    enum Articles
    {
        Pommes,
        Cerises,
        Bananes,
    }
}
