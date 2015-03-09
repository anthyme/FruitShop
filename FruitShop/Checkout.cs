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
            {Articles.Apples, 100},
            {Articles.Mele, 100},
            {Articles.Cerises, 75},
            {Articles.Bananes, 150},
        };

        private readonly ICollection<Articles> _articles = new List<Articles>();

        public string Add(string parameter)
        {
            AddArticlesFromParameter(parameter);
            return ApplyReductions(ComputeRawTotal()).ToString();
        }

        private void AddArticlesFromParameter(string parameter)
        {
            parameter.Split(',').Select(p=>p.Trim()).Select(ConvertToArticle)
                .ToList().ForEach(_articles.Add);
        }

        private static Articles ConvertToArticle(string parameter)
        {
            return (Articles) Enum.Parse(typeof (Articles), parameter);
        }

        private int ComputeRawTotal()
        {
            return _articles.Select(a => _costs[a]).Sum();
        }

        private int ApplyReductions(int total)
        {
            return total 
                - Compute2CerisesGot20CentsReduction()
                - Compute2BananesGot1FreeReduction()
                - Compute3ApplesFor200Reduction()
                - Compute2MeleFor100Reduction()
                ;
        }

        private int Compute2MeleFor100Reduction()
        {
            return (Count(Articles.Mele) / 2) * (2 * CostOf(Articles.Mele) - 100);
        }

        private int Compute3ApplesFor200Reduction()
        {
            return (Count(Articles.Apples) / 3) * (3 * CostOf(Articles.Apples) - 200);
        }

        private int Compute2CerisesGot20CentsReduction()
        {
            return (Count(Articles.Cerises) / 2) * 20;
        }

        private int Compute2BananesGot1FreeReduction()
        {
            return (Count(Articles.Bananes) / 2) * CostOf(Articles.Bananes);
        }

        private int Count(Articles article)
        {
            return _articles.Count(a => a == article);
        }

        private int CostOf(Articles article)
        {
            return _costs[article];
        }
    }

    enum Articles
    {
        Pommes,
        Cerises,
        Bananes,
        Apples,
        Mele,
    }
}
