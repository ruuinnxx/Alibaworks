﻿using Project2_Observer;

var trader1 = new Trader("1");
var trader2 = new Trader("2");
var trader3 = new Trader("3");

var traderBot = new TraderBot(90, 110);

var stockExchange = new StockExchange();
stockExchange.Attach("Apple", trader1);
stockExchange.Attach("Apple", trader2);
stockExchange.Attach("Apple", traderBot);
stockExchange.Attach("Google", trader3);

stockExchange.SetStockPrice("Apple", 120);
stockExchange.SetStockPrice("Google", 95);
stockExchange.SetStockPrice("Apple", 80);