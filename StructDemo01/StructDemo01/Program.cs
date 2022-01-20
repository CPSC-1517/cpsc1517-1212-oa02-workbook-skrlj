// See https://aka.ms/new-console-template for more information
using StructDemo01;

Resolution hdResolution = new(1920, 1080);
var cinemaResolution = hdResolution;
cinemaResolution.Width = 2048;
Console.WriteLine($"hd resolution is: {hdResolution.Width} pixels wide and {hdResolution.Height} pixels high");
Console.WriteLine($"cinema resolution is: {cinemaResolution.Width} pixels wide and {cinemaResolution.Height} pixels high");
VideoMode someVideoMode = new();

// if we made the struct a class. the change to 2048 would not be reflected and the output would be the same values.

