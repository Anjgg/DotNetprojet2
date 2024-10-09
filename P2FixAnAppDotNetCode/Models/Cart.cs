﻿using Microsoft.AspNetCore.Razor.Language;
using System;
using System.Collections.Generic;
using System.Linq;

namespace P2FixAnAppDotNetCode.Models
{
    /// <summary>
    /// The Cart class
    /// </summary>
    public class Cart : ICart
    {
        
        private List<CartLine> _cartLines = new List<CartLine>();
        
        /// <summary>
        /// Read-only property for display only
        /// </summary>
        public IEnumerable<CartLine> Lines => GetCartLineList();

        /// <summary>
        /// Return the actual cartline list
        /// </summary>
        /// <returns></returns>
        private List<CartLine> GetCartLineList()
        {
            return _cartLines;
        }

        /// <summary>
        /// Adds a product in the cart or increment its quantity in the cart if already added
        /// </summary>//
        public void AddItem(Product product, int quantity)
        {
            // Condition for adding item or incrementing quantity
            if (_cartLines.Exists(x => x.Product.Id == product.Id))
            {
                int indexInList = _cartLines.FindIndex(x => x.OrderLineId == product.Id);
                _cartLines[indexInList].Quantity += quantity;
            }
            else
            {   // Create the line
                CartLine line = new CartLine();         
                line.OrderLineId = product.Id;
                line.Product = product;
                line.Quantity = quantity;
                _cartLines.Add(line);
            }
        }

        /// <summary>
        /// Removes a product form the cart
        /// </summary>
        public void RemoveLine(Product product) =>
            GetCartLineList().RemoveAll(l => l.Product.Id == product.Id);

        /// <summary>
        /// Get total value of a cart
        /// </summary>
        public double GetTotalValue()
        {
            double totalValue = 0;
            for (int i = 0; i < _cartLines.Count; i++)
            {
                totalValue += _cartLines[i].Product.Price * _cartLines[i].Quantity;
            }
            return totalValue;
        }

        /// <summary>
        /// Get average value of a cart
        /// </summary>
        public double GetAverageValue()
        {
            int totalItems = 0;
            for (int i = 0; i < _cartLines.Count; i++)
            {
                totalItems += _cartLines[i].Quantity;
            }
            double averageValue = GetTotalValue() / totalItems;

            return averageValue;
        }

        /// <summary>
        /// Looks after a given product in the cart and returns if it finds it
        /// </summary>
        public Product FindProductInCartLines(int productId)
        {
           int indexInList = _cartLines.FindIndex(x => x.Product.Id == productId);
            if (indexInList == -1)
                return null;
            return _cartLines[indexInList].Product;     
        }

        /// <summary>
        /// Get a specific cartline by its index
        /// </summary>
        public CartLine GetCartLineByIndex(int index)
        {
            return Lines.ToArray()[index];
        }

        /// <summary>
        /// Clears a the cart of all added products
        /// </summary>
        public void Clear()
        {
            List<CartLine> cartLines = GetCartLineList();
            cartLines.Clear();
        }
    }

    public class CartLine
    {
        public int OrderLineId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
