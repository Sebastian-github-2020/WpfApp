int num = 101100;
string seconds = num % 60 > 9 ? Convert.ToString(num % 60) : $"0{num % 60}";
string minuts = (num % 3600 / 60) > 9 ? Convert.ToString(num % 3600 / 60) : $"0{(num % 3600 / 60)}";
string hour = (num / 3600) > 9 ? Convert.ToString(num / 3600) : $"0{(num / 3600)}";
Console.WriteLine($"{hour}:{minuts}:{seconds}");

