#ifndef CIRCLE_H
#define CIRCLE_H

#include<iostream>


class Circle {
	static const double pai;
private:
	double x;
	double y;
	double r;//radius
public:
	Circle(double x, double y, double r);
	Circle(double r);
	~Circle();
	void SetX(double x);
	void SetY(double y);
	void SetR(double r);
	double GetX(); //const
		double GetY(); //const
		double GetR(); //const
		void PrintCircle();
	double ScopeOfTheCircle(double r);//היקף
	double AreaOfTheCircle(double r);

};
#endif