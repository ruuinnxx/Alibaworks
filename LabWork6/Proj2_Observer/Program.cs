﻿using Project2_Observer;

var weatherStation = new WeatherStation();

var mobileApp = new WeatherDisplay("Мобильное приложение");
var digitalBillboard = new WeatherDisplay("Электронное табло");
var email = new Email("user@example.com");


weatherStation.RegisterObserver(mobileApp);
weatherStation.RegisterObserver(digitalBillboard);
weatherStation.RegisterObserver(email);

weatherStation.SetTemperature(25.0f);
weatherStation.SetTemperature(30.0f);

weatherStation.RemoveObserver(digitalBillboard);
weatherStation.SetTemperature(28.0f);