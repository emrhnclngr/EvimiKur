using EvimiKur.Entities.Entities;
using System.Collections.Generic;
using System;
using System.Linq;

namespace EvimiKur.UI.Models
{
    public class Cart
    {
        private Dictionary<int, Product> _cart = null;

        public Cart()
        {
            _cart = new Dictionary<int, Product>();
        }

        public List<Product> CartProductList
        {
            get => _cart.Values.ToList();
        }

        /// <summary>
        /// Seçilen ürünü sepete ekler
        /// </summary>
        /// <param name="item"></param>
        public void AddCart(Product item)
        {
            //Eğer o id'ye ait bir item yoksa id ve itemi dictionary içerisine değeri ile atıyoruz
            if (!_cart.ContainsKey(item.Id))
                _cart.Add(item.Id, item);
            else//Eğer o id varsa satın alınacak(sepete eklenecek) miktarı bir arttırır.
                _cart[item.Id].Quantity = _cart[item.Id].Quantity + 1;
        }
        /// <summary>
        /// Seçilen ürünü sepetten siler
        /// </summary>
        /// <param name="id"></param>
        public void RemoveCart(int id)
        {
            _cart.Remove(id);
        }
        /// <summary>
        /// Seçilen ürünün sepetteki adetini bir düşürür, eğer o elemandan daha kalmayacaksa siler.
        /// </summary>
        /// <param name="id"></param>
        public void DecreaseCart(int id)
        {
            //Sepetten bir azaltma
            _cart[id].Quantity = _cart[id].Quantity - 1;

            //Eğer sepette azaltırken başka o elemandan kalmadı ise tamamen sepetten siliyoruz
            if (_cart[id].Quantity <= 0) _cart.Remove(id);
        }
        /// <summary>
        /// Seçilen ürünün adetini bir arttırır.
        /// </summary>
        /// <param name="id"></param>
        public void IncreaseCart(int id)
        {
            //Sepetteki ürünün miktarını bir arttırır.
            _cart[id].Quantity = _cart[id].Quantity + 1;
        }
    }
}
