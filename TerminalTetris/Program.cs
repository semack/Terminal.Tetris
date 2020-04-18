﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using TerminalTetris.IO;

namespace TerminalTetris
{
    internal static class Program
    {
        private static async Task<int> Main(string[] args)
        {
            using var cancellationTokenSource = new CancellationTokenSource();
            
            var tetris = new Tetris(new TerminalDisplay(),
                new TerminalKeyboard(),
                new TimeSpan(100));

            await tetris.RunAsync(cancellationTokenSource.Token);

            await TerminalHost
                .CreateDefaultBuilder()
                .RunTerminalAsync(options =>
                {
                    options.Title = nameof(TerminalTetris);
                    options.SuppressStatusMessages = true;
                }, cancellationTokenSource.Token);

            return 0;
        }
    }
}