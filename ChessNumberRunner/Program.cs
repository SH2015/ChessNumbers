// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Security.Cryptography;
using ChessNumbers;
using ChessNumbers.ChessPieces;

 
 // register services 

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
builder.Services.AddSingleton<ICoordinatesGenerator,CoordinatesGenerator>();
builder.Services.AddSingleton<INumberFormatter,NumberFormatter>();
// Create factory for Chess Pieces and pass enum to get the right piece , but because of limited time we will leave that implementation for now 
builder.Services.AddSingleton<Rook>();
builder.Services.AddSingleton<Knight>();
var  host = builder.Build(); 
Rook rook = host.Services.GetRequiredService<Rook>();
Knight knight = host.Services.GetRequiredService<Knight>();
INumberFormatter numberFormatter = host.Services.GetRequiredService<INumberFormatter>();    
Console.WriteLine($"First item should be 1 : {BoardInfo.Pad[0, 0]},this value should be 5 : {BoardInfo.Pad[1, 1]} ");

for (int i = 0;i<BoardInfo.Pad.GetLength(0); i++)
{
   for ( int j = 0; j< BoardInfo.Pad.GetLength(1); j++)
    {
        if ( BoardInfo.NoStaringSpots.Concat(BoardInfo.SpotsToAvoid).Any(s=> s.x == i && s.y == j))
        {
            continue;
        }
        Console.Write($"Run for spot : {BoardInfo.Pad[i, j]}");
        string rookNumber  = rook.GetMoveDigits(i, j);
             
        string knightNumber = knight.GetMoveDigits(i, j);
        Console.WriteLine($" Rook Number :{numberFormatter.FormatNumber(rookNumber)}, Knight:{numberFormatter.FormatNumber(knightNumber)}");
    }
   
    
}