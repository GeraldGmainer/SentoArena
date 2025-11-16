using System.Collections.Generic;

public class ChatCommandHandler {
    private List<ChatCommand> commands = new List<ChatCommand>();

    public ChatCommandHandler() {
        commands.Add(new ChatCommandBotAdd());
        commands.Add(new ChatCommandBotKick());
    }

    public bool check(string text) {
        foreach (ChatCommand command in commands) {
            if (text.ToLower().Equals(command.name().ToLower())) {
                command.call();
                return true;
            }
        }
        return false;
    }
}
