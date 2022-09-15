#ifndef QUEUEOFACCOUNT
#define QUEUEOFACCOUNT

#include<iostream>
#include"Account.h"

class QueueOfAccounts {
private:
	Account node;
	QueueOfAccounts* next;
public:
	
	QueueOfAccounts(Account node);
	~QueueOfAccounts();
	void AddNode(QueueOfAccounts* coustomer);
	Account GetNode();
	Account TopNode();
	int IsEmpty();
	friend void PrintQueue(QueueOfAccounts* queue);
};
#endif

