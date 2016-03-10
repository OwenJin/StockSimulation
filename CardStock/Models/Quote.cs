using System;

namespace Jarloo.CardStock.Models
{
    public class Quote// : INotifyPropertyChanged
    {
        //public event PropertyChangedEventHandler PropertyChanged;
        public Quote(string symbol)
        {
            this.symbol = symbol;
        }

        public string symbol;
        public string name;
        public decimal? ask;
        public decimal? averageDailyVolume;
        public decimal? bid;
        public decimal? bookValue;
        public decimal? percentChange;
        public decimal? change;
        public string currency;
        public decimal? dividendShare;
        public decimal? earningsShare;
        public decimal? epsEstimateCurrentYear;
        public decimal? epsEstimateNextYear;
        public decimal? epsEstimateNextQuarter;
        public decimal? dailyLow;
        public decimal? dailyHigh;
        public decimal? yearlyLow;
        public decimal? yearlyHigh;
        public decimal? marketCapitalization;
        public decimal? ebitda;
        public decimal? changeFromYearLow;
        public decimal? percentChangeFromYearLow;
        public decimal? changeFromYearHigh;
        public decimal? percentChangeFromYearHigh;
        public DateTime? lastTradeDate;
        public decimal? lastTradePrice;
        public DateTime? lastTradeTime;
        public string daysRange;
        public decimal? fiftyDayMovingAverage;
        public decimal? twoHunderedDayMovingAverage;
        public decimal? changeFromTwoHundredDayMovingAverage;
        public decimal? changeFromFifthDayMovingAverage;
        public decimal? percentChangeFromFiftyDayMovingAverage;
        public decimal? percentChangeFromTwoHundredDayMovingAverage;
        public decimal? open;
        public decimal? previousClose;
        public decimal? changeInPercent;
        public decimal? priceSales;
        public decimal? priceBook;
        public DateTime? exDividendDate;
        public decimal? peRatio;
        public decimal? pegRatio;
        public DateTime? dividendPayDate;
        public decimal? priceEpsEstimateCurrentYear;
        public decimal? priceEpsEstimateNextYear;
        public decimal? shortRatio;
        public decimal? oneYearPriceTarget;
        public decimal? volume;
        public string yearRange;
        public decimal? dividendYield;
        public string stockExchange;
    }
}