namespace Lab5.Models.Users;

public record User(long Id, int Password, UserRole Role, long Money);