using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity.Extensions;
using System.Threading.Tasks;
using static DSharpPlus.Entities.DiscordEmbedBuilder;

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

        [Command("joinrole")]
        [Description("Allows you to join, and only join, the 'Joined Role' in GangstaX")]
        public async Task Join(CommandContext ctx)
        {
            var joinEmbed = new DiscordEmbedBuilder()
            {
                Title = "Join role",
                Color = DiscordColor.Azure
            };

            var joinMessage = await ctx.Channel.SendMessageAsync(embed: joinEmbed).ConfigureAwait(false);

            var thumbsUpEmoji = DiscordEmoji.FromName(ctx.Client, ":+1:");
            var thumbsDownEmoji = DiscordEmoji.FromName(ctx.Client, ":-1:");

            await joinMessage.CreateReactionAsync(thumbsUpEmoji).ConfigureAwait(false);
            await joinMessage.CreateReactionAsync(thumbsDownEmoji).ConfigureAwait(false);

            var interactivity = ctx.Client.GetInteractivity();

            var reactionResult = await interactivity.WaitForReactionAsync(
                x => x.Message == joinMessage && 
                (x.Emoji == thumbsUpEmoji || x.Emoji == thumbsDownEmoji)).ConfigureAwait(false);

            if (reactionResult.Result.Emoji == thumbsUpEmoji)
            {
                var role = ctx.Guild.GetRole(829250390491004948);
                await ctx.Member.GrantRoleAsync(role).ConfigureAwait(false);
            }
        }
    }
}
