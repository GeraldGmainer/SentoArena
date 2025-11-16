public class ChatCommandBotAdd : ChatCommand {

    public string name() {
        return "bot_add";
    }

    public void call() {
        BotManager.instance.botAdd();
        Chat.instance.addSystemMessage("bot added");
    }
}
