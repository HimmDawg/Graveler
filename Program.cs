using System.Diagnostics;
using Graveler;

 var gravelerCalculator = new GravelerCalculator(Random.Shared);
long startTime = Stopwatch.GetTimestamp();
(int maxOnes, int rolls) = await gravelerCalculator.GravelerParallel(1_000_000_000);
TimeSpan endTime = Stopwatch.GetElapsedTime(startTime);

Console.WriteLine("Highest Ones Roll: " + maxOnes);
Console.WriteLine("Number of Roll Sessions: " + rolls);
Console.WriteLine("Time needed: " + endTime);


