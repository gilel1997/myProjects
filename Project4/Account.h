#ifndef ACCOUNT_H
#define ACCOUNT_H

#include<iostream>

class Account {
	
private:
	char* fullName;
	int amountOfMoney;
	int accountNumber;

public:

	static int count;
	Account(char* fullName, int amountOfMoney);
	Account();
	~Account();
	void SetFullName(char* fullName);
	void SetAmountOfMoney(int amountOfMoney);
	char* GetFullName();
	int GetAmountOfMoney();
	int GetAccountNumber();
	friend void PrintAccount(char* fullName, int n, int amountOfMoney, int accountNumber);
};
#endif
