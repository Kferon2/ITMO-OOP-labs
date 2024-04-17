using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace Infrastructure.Migrations;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
        """
        create type user_role as enum
        (
            'Admin',
            'User'
        );

        create table Accounts
        (
            acc_id bigint primary key generated always as identity ,
            acc_password integer ,
            user_role user_role not null ,
            acc_balance bigint
        );
        
        create table Admins
        (
            System_Key integer primary key not null
        );
        
        insert INTO Accounts
        VALUES (1, 123, User, 0)
        """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
        "drop table Accounts;";
}
