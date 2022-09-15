#include<iostream>
#include<math.h>
#include"Circle.h"

using std::cout;
using std::endl;

const double Circle::pai = 3.14;


Circle::Circle(double x, double y, double r)
{
	SetX(x);
	SetY(y);
	SetR(r);
}
Circle::Circle(double r)
{
	SetX(0);
	SetY(0);
	SetR(r);

}
Circle::~Circle()
{

}

void Circle::SetX(double x)
{
	Circle::x = x;
}
void Circle::SetY(double y)
{
	Circle::y = y;
}
void Circle::SetR(double r)
{
	Circle::r = r;
}
double Circle::GetX()
{
	return Circle::x;
}
double Circle::GetY()
{
	return Circle::y;
}
double Circle::GetR()
{
	return Circle::r;
}

void Circle::PrintCircle()
{
	cout << "the center of the circle is (" << Circle::x << "," << Circle::y << ")" << endl;
	cout << "the radius of the circle is: " << Circle::r << endl;
}
double Circle::ScopeOfTheCircle(double r)//היקף 
{
	double scope;
	scope = 2 * r * pai;
	return scope;
}
double Circle::AreaOfTheCircle(double r)
{
	double area;
	area = pai * pow(r, 2);
	return area;
}
