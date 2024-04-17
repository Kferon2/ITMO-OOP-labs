namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee.MessengerAddressee.Telegram;

public interface ITelegram
{
    void SendMessage(string apiKey, long usedId, string message);
}