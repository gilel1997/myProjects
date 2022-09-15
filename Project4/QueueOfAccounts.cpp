#include<iostream>
#include<math.h>
#include "QueueOfAccount.h"

using std::cout;
using std::endl;

QueueOfAccounts::QueueOfAccounts(Account node)
{
	QueueOfAccounts::node = node;
	QueueOfAccounts::next = NULL;
}
QueueOfAccounts::~QueueOfAccounts()
{

}

void QueueOfAccounts::AddNode(QueueOfAccounts* coustomer)
{
	QueueOfAccounts::next = coustomer;
	coustomer->next = NULL;
}
Account QueueOfAccounts::GetNode()
{
	QueueOfAccounts::next = NULL;
	return QueueOfAccounts::node;
}
Account QueueOfAccounts::TopNode()
{
	return QueueOfAccounts::node;
}
int QueueOfAccounts::IsEmpty()
{

}