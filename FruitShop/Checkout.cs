using System;
using System.Collections.Generic;
using System.Linq;

namespace FruitShop
{
    public class Checkout
    {
        private readonly Dictionary<Articles, int>  _costs = new Dictionary<Articles, int>()
        {
            {Articles.Pommes, 100},
            {Articles.Cerises, 75},
            {Articles.Bananes, 150},
        };

        private readonly ICollection<Articles> _articles = new List<Articles>();

        public string Add(string parameter)
        {
            var article = (Articles)Enum.Parse(typeof (Articles), parameter);
            _articles.Add(article);
            return _articles.Select(a => _costs[a]).Sum().ToString();
        }
    }

    enum Articles
    {
        Pommes,
        Cerises,
        Bananes,
    }
}
