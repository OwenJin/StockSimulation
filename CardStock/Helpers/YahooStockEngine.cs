using Jarloo.CardStock.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Xml.Linq;

namespace Jarloo.CardStock.Helpers
{
    public static class YahooStockEngine
    {
        private static string BaseUrl = ConfigurationManager.AppSettings["BaseUrl"];

        public static void Fetch(IList<Quote> quotes)
        {
            string symbolList = string.Join("%2C", quotes.Select(q => "%22" + q.symbol + "%22").ToArray());
            string url = string.Format(BaseUrl, symbolList);
            
            XDocument doc = XDocument.Load(url);
            Parse(quotes,doc);
        }

        private static void Parse(IList<Quote> quotes, XDocument doc)
        {
            XElement results = doc.Root.Element("results");

            foreach (Quote quote in quotes)
            {
                XElement q = results.Elements("quote").First(w => w.Attribute("symbol").Value == quote.symbol);

                quote.name = q.Element("Name").Value;
                quote.ask = GetDecimal(q.Element("Ask").Value);
                quote.averageDailyVolume = GetDecimal(q.Element("AverageDailyVolume").Value);
                quote.bid = GetDecimal(q.Element("Bid").Value);
                quote.bookValue = GetDecimal(q.Element("BookValue").Value);
                quote.percentChange= GetDecimal(q.Element("PercentChange").Value);
                quote.change = GetDecimal(q.Element("Change").Value);
                quote.currency = q.Element("Currency").Value;
                quote.dividendShare = GetDecimal(q.Element("DividendShare").Value);
                quote.earningsShare = GetDecimal(q.Element("EarningsShare").Value);
                quote.epsEstimateCurrentYear = GetDecimal(q.Element("EPSEstimateCurrentYear").Value);
                quote.epsEstimateNextYear = GetDecimal(q.Element("EPSEstimateNextYear").Value);
                quote.epsEstimateNextQuarter = GetDecimal(q.Element("EPSEstimateNextQuarter").Value);
                quote.dailyLow = GetDecimal(q.Element("DaysLow").Value);
                quote.dailyHigh = GetDecimal(q.Element("DaysHigh").Value);
                quote.yearlyLow = GetDecimal(q.Element("YearLow").Value);
                quote.yearlyHigh = GetDecimal(q.Element("YearHigh").Value);
                quote.marketCapitalization = GetDecimal(q.Element("MarketCapitalization").Value);
                quote.ebitda = GetDecimal(q.Element("EBITDA").Value);
                quote.changeFromYearLow = GetDecimal(q.Element("ChangeFromYearLow").Value);
                quote.percentChangeFromYearLow = GetDecimal(q.Element("PercentChangeFromYearLow").Value);
                quote.changeFromYearHigh = GetDecimal(q.Element("ChangeFromYearHigh").Value);
                quote.percentChangeFromYearHigh = GetDecimal(q.Element("PercebtChangeFromYearHigh").Value);//missspelling in yahoo for field name
                quote.lastTradePrice = GetDecimal(q.Element("LastTradePriceOnly").Value);
                quote.lastTradeDate = GetDateTime(q.Element("LastTradeDate").Value);
                quote.lastTradeTime = GetDateTime(q.Element("LastTradeTime").Value);
                quote.daysRange = q.Element("DaysRange").Value;
                quote.fiftyDayMovingAverage = GetDecimal(q.Element("FiftydayMovingAverage").Value);
                quote.twoHunderedDayMovingAverage = GetDecimal(q.Element("TwoHundreddayMovingAverage").Value);
                quote.changeFromTwoHundredDayMovingAverage = GetDecimal(q.Element("ChangeFromTwoHundreddayMovingAverage").Value);
                quote.changeFromFifthDayMovingAverage = GetDecimal(q.Element("ChangeFromFiftydayMovingAverage").Value);
                quote.percentChangeFromTwoHundredDayMovingAverage = GetDecimal(q.Element("PercentChangeFromTwoHundreddayMovingAverage").Value);
                quote.percentChangeFromFiftyDayMovingAverage = GetDecimal(q.Element("PercentChangeFromFiftydayMovingAverage").Value);
                quote.open = GetDecimal(q.Element("Open").Value);
                quote.previousClose = GetDecimal(q.Element("PreviousClose").Value);
                quote.changeInPercent = GetDecimal(q.Element("ChangeinPercent").Value);
                quote.priceSales = GetDecimal(q.Element("PriceSales").Value);
                quote.priceBook = GetDecimal(q.Element("PriceBook").Value);
                quote.exDividendDate = GetDateTime(q.Element("ExDividendDate").Value);
                quote.peRatio = GetDecimal(q.Element("PERatio").Value);
                quote.pegRatio = GetDecimal(q.Element("PEGRatio").Value);
                quote.dividendPayDate = GetDateTime(q.Element("DividendPayDate").Value);
                quote.priceEpsEstimateCurrentYear = GetDecimal(q.Element("PriceEPSEstimateCurrentYear").Value);
                quote.priceEpsEstimateNextYear = GetDecimal(q.Element("PriceEPSEstimateNextYear").Value);
                quote.shortRatio = GetDecimal(q.Element("ShortRatio").Value);
                quote.oneYearPriceTarget = GetDecimal(q.Element("OneyrTargetPrice").Value);
                quote.volume = GetDecimal(q.Element("Volume").Value);
                quote.yearRange = q.Element("YearRange").Value;
                quote.dividendYield = GetDecimal(q.Element("DividendYield").Value);
                quote.stockExchange = q.Element("StockExchange").Value;
            }
        }

        private static decimal? GetDecimal(string input)
        {
            if (input == null) return null;

            input = input.Replace("%", "");

            decimal value;

            if (Decimal.TryParse(input, out value)) return value;
            return null;
        }

        private static DateTime?  GetDateTime(string input)
        {
            if (input == null) return null;

            DateTime value;

            if (DateTime.TryParse(input, out value)) return value;
            return null;
        }
    }
}