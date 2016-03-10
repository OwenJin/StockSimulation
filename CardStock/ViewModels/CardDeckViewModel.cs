using System;
using System.Windows;
using System.Windows.Threading;
using System.Collections.ObjectModel;
using Jarloo.CardStock.Helpers;
using Jarloo.CardStock.Models;
using System.Collections.Generic;

namespace Jarloo.CardStock.ViewModels
{
    public class CardDeckViewModel : DependencyObject
    {
        private readonly DispatcherTimer timer = new DispatcherTimer(DispatcherPriority.Background);

        public IList<Quote> Quotes { get; set; }

        public CardDeckViewModel()
        {
            Quotes = new List<Quote>();

            //Some example tickers
            Quotes.Add(new Quote("AAPL"));
            Quotes.Add(new Quote("MSFT"));
            Quotes.Add(new Quote("INTC"));
            Quotes.Add(new Quote("IBM"));
            Quotes.Add(new Quote("RVBD"));
            Quotes.Add(new Quote("AMZN"));
            Quotes.Add(new Quote("BIDU"));
            Quotes.Add(new Quote("SINA"));
            Quotes.Add(new Quote("THI"));
            Quotes.Add(new Quote("NVDA"));
            Quotes.Add(new Quote("AMD"));
            Quotes.Add(new Quote("DELL"));
            Quotes.Add(new Quote("WMT"));
            Quotes.Add(new Quote("GLD"));
            Quotes.Add(new Quote("SLV"));
            Quotes.Add(new Quote("V"));
            Quotes.Add(new Quote("V"));
            Quotes.Add(new Quote("MCD"));

            //get the data
            YahooStockEngine.Fetch(Quotes);

            //poll every 25 seconds
            timer.Interval = new TimeSpan(0, 0, 1); 
            timer.Tick += (o, e) => YahooStockEngine.Fetch(Quotes);
                              
            timer.Start();
        }
    }
}