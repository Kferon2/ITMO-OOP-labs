using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Message;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messenger;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Validators;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee.MessengerAddressee.Telegram;

public class TelegramToMessengerAdapter : IAddressee
{
    private readonly ITelegram _telegram;

    private readonly IMessenger _messenger = new Messenger();

    public TelegramToMessengerAdapter(long usedId, string apiKey, ITelegram telegram)
    {
        if (!new StringValidator().Validate(apiKey))
            throw new BadStringFormatException("Bad api key format");

        if (usedId < 0) throw new NegativeIntArgumentException("Person used Id can't be negative");
        UsedId = usedId;
        ApiKey = apiKey;
        _telegram = telegram ?? throw new ArgumentNullException(nameof(telegram));
    }

    public int Counter { get; private set; }

    public long UsedId { get; }

    public string ApiKey { get; }

    public void GetMessage(Message message)
    {
        if (message == null) throw new ArgumentNullException(nameof(message));
        _telegram.SendMessage(ApiKey, UsedId, message.Text);
        Counter++;
        _messenger.WriteText(message.Text);
    }
}