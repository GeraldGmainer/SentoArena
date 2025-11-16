public class ChatCommandBotKick : ChatCommand {
    public string name() {
        return "bot_kick";
    }

    public void call() {
        BotManager.instance.botKickAll();
        Chat.instance.addSystemMessage("kicked all bots");
    }
}
