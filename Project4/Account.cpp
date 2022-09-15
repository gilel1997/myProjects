#include<iostream>
#include<math.h>
#include"Account.h"

using std::cout;
using std::endl;

int Account::count = 0;
Account::Account()
{
}
Account::Account(char* fullName, int amountOfMoney)
{
	Account::count++;
	Account::SetFullName(fullName);
	Account::SetAmountOfMoney(amountOfMoney);
	Account::accountNumber == Account::count;
}
Account::~Account()
{

}
void Account::SetFullName(char* fullName)
{
	Account::fullName = fullName;
}
void Account::SetAmountOfMoney(int amountOfMoney)
{
	Account::amountOfMoney = amountOfMoney;
}
char* Account::GetFullName()
{
	return Account::fullName;
}
int Account::GetAmountOfMoney()
{
	return Account::amountOfMoney;
}
int Account::GetAccountNumber()
{
	return Account::accountNumber;
}
void PrintAccount(char* fullName, int n, int amountOfMoney, int accountNumber)
{
	int i;
	cout << "hello ";
	for (i = 0; i < n; i++)
	{
		cout << fullName[i];
	}
	cout << "the amount of the account number " << accountNumber << "is: " << amountOfMoney << endl;
}