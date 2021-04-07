using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Interactivity.Extensions;
using System;
using System.Threading.Tasks;

namespace Jatc251Bot.Commands
{
    public class FunCommands : BaseCommandModule
    {
        [Command("ping")]
        [Description("Pong")]
        public async Task Ping(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("Pong").ConfigureAwait(false);
        }

        [Command("add")]
        [Description("Adds two numbers. Additional numbers will be ignored.")]
        public async Task Add(
            CommandContext ctx,
            [Description("First number to add")] int numberOne,
            [Description("Second number to add")] int numberTwo)
        {
            await ctx.Channel
                .SendMessageAsync((numberOne + numberTwo).ToString())
                .ConfigureAwait(false);

        }

        [Command("percent")]
        [Description("Returns a random percentage from your specified range")]
        public async Task Percentage(CommandContext ctx, 
            [Description("Smallest amount to pick from")] int smallRange,
            [Description("Largest amount to pick from")] int bigRange)
        {
            Random randomGen = new Random();
            int randomNumber = randomGen.Next(smallRange, bigRange);

            await ctx.Channel.SendMessageAsync(randomNumber.ToString() + "%").ConfigureAwait(false);

        }

        [Command("echo")]
        [Description("Repeats the next message sent in the channel the command was used in. Maximum of two minutes wait")]
        public async Task Response(CommandContext ctx)
        {
            var interactivity = ctx.Client.GetInteractivity();

            var message = await interactivity.WaitForMessageAsync(x => x.Channel == ctx.Channel).ConfigureAwait(false);

            await ctx.Channel.SendMessageAsync(message.Result.Content);
        }

    }
}
