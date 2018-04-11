# CsBugmenot
This project is a port of [Davide Pastore](https://github.com/DavidePastore)'s java [JBugmenot](https://github.com/DavidePastore/JBugmenot) library to C#. CsBugmenot uses zero (0) external libraries.

## Installation
Build from source code or [download the library](https://github.com/sleeyax/CsBugmenot/releases) and add it as a reference to your project.

## Usage
Usage is very similar to the original library.

To find all accounts for a specific website:
```csharp
List<Account> accounts = CsBugmenot.GetAllAccounts("insertwebsitehere.com");
```

Get login details for the first account:
```csharp
List<Account> accounts = CsBugmenot.GetAllAccounts("insertwebsitehere.com");
Account account = accounts[0];
string username = account.Username;
string password = account.Password;
string other = account.Other;
int stats = account.Stats;
int votes = account.Votes;
DateTime dateAdded = account.AddingDate;
```

Specify minimum success rate:
```csharp
// Set min. success rate of 40%
CsBugmenot.MinimumSuccessRate = 40;

List<Account> accounts = CsBugmenot.GetAllAccounts("insertwebsitehere.com");
```

Vote for an account:
```csharp
List<Account> accounts = CsBugmenot.GetAllAccounts("insertwebsitehere.com");
Account account = accounts[0];

// (True = working, False = not working)
CsBugmenot.Vote(account, true);
// OR
account.Vote(false);
```