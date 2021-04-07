using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;

namespace Jatc251Bot.Commands
{
    class MemberCommands : BaseCommandModule
    {
        [Command("avatar")]
        [Description("Returns your avatar")]
        public async Task AvatarURL(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync(ctx.Member.AvatarUrl).ConfigureAwait(false);

        }

        [Command("datejoined")]
        [Description("Returns the date you joined this server")]
        public async Task DateJoined(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync(ctx.Member.JoinedAt.ToString()).ConfigureAwait(false);

        }

        [Command("color")]
        [Description("Returns your top-most role's color in hex format")]
        public async Task Roles(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync(ctx.Member.Color.ToString()).ConfigureAwait(false);

        }
    }
}
