using Itmo.ObjectOrientedProgramming.Lab3.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.Addressee.Filters;
using Itmo.ObjectOrientedProgramming.Lab3.Addressee.MessengerAddressee.Telegram;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Message;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Person;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Topic;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class Tests
{
    [Fact]
    public void FirstTestCase()
    {
        // Arrange
        var person = new Person(1, "Egor", "Klimenko");
        var personProxy = new AddresseeProxyFilter(new PersonAddressee(person), new ImportanceLevelFilter(3));
        var topic = new Topic("What to eat today?", personProxy);

        // Act
        topic.GetMessage(new Message("Examples of food", "chicken, beef, pig", 1));

        // Assert
        Assert.False(person.Messages[0].IsRead);
    }

    [Fact]
    public void SecondTestCase()
    {
        // Arrange
        var person = new Person(1, "Egor", "Klimenko");
        var personProxy = new AddresseeProxyFilter(new PersonAddressee(person), new ImportanceLevelFilter(3));
        var topic = new Topic("What to drink today?", personProxy);

        // Act
        topic.GetMessage(new Message("Examples of drinks", "cola, water, coffee", 1));
        person.ReadMessage(0);

        // Assert
        Assert.True(person.Messages[0].IsRead);
    }

    [Fact]
    public void ThirdTestCase()
    {
        // Arrange
        var person = new Person(1, "Egor", "Klimenko");
        var personProxy = new AddresseeProxyFilter(new PersonAddressee(person), new ImportanceLevelFilter(3));
        var topic = new Topic("What to do today?", personProxy);

        // Act
        topic.GetMessage(new Message("Examples of activities", "sleep, work, eat", 2));
        person.ReadMessage(0);

        // Assert
        Assert.Throws<ReadMessageException>(() => person.ReadMessage(0));
    }

    [Fact]
    public void FourthTestCase()
    {
        IAddressee? personAddressee = Substitute.For<IAddressee>();
        var personProxy = new AddresseeProxyFilter(personAddressee, new ImportanceLevelFilter(1));
        var message = new Message("Examples of activities", "sleep, work, eat", 2);

        personProxy.GetMessage(message);

        personAddressee.DidNotReceive().GetMessage(message);
    }

    [Fact]
    public void FifthTestCase()
    {
        IAddressee? personAddressee = Substitute.For<IAddressee>();
        var personProxy = new AddresseeProxyLogger(personAddressee);
        var message = new Message("Examples of activities", "sleep, work, eat", 2);

        personProxy.GetMessage(message);

        Assert.Equal(1, personProxy.Counter);
    }

    [Fact]
    public void SixthTestCase()
    {
        ITelegram? messengerAddressee = Substitute.For<ITelegram>();
        var adapter = new TelegramToMessengerAdapter(1, "aboba", messengerAddressee);
        var message = new Message("Examples of activities", "sleep, work, eat", 2);

        adapter.GetMessage(message);

        messengerAddressee.Received().SendMessage("aboba", 1, message.Text);
        Assert.Equal(1, adapter.Counter);
    }
}